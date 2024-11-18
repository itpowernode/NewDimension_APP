using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDimension_APP
{
    public partial class CartonDimension : Form
    {
        private SQLQuery sql_call = new SQLQuery();
        private List<Carton> ls_carton = new List<Carton>();

        private decimal maximal_in = 100;
        private decimal maximal_cm = 100;
        private static bool _addednew = false;

        public CartonDimension(string mode, List<Carton> ls_existed, Carton carton = null)
        {
            InitializeComponent();
            ls_carton = ls_existed;
            maximal_cm = Convert.ToDecimal(InchToCentimetre((double)maximal_in));
            if (mode.ToLower().Equals("new"))
            {
                this.Text = "New Carton";
                textBox_cartonid.ReadOnly = false;
                checkBox_inactive.Checked = false;
                button_insertupdate.Text = "Insert";
                this.ActiveControl = textBox_cartonid;
            }
            else if (mode.ToLower().Equals("update"))
            {
                this.Text = "Update Carton";
                textBox_cartonid.ReadOnly = true;
                button_insertupdate.Text = "Update";
                button_clear.Enabled = false;
                button_clear.Visible = false;
                if (carton.Carton_ID != null)
                {
                    textBox_cartonid.Text = carton.Carton_ID;
                    numericUpDown_length_in.Value = (decimal)carton.Length_IN;
                    numericUpDown_width_in.Value = (decimal)carton.Width_IN;
                    numericUpDown_height_in.Value = (decimal)carton.Height_IN;
                    numericUpDown_length_cm.Value = (decimal)carton.Length_CM;
                    numericUpDown_width_cm.Value = (decimal)carton.Width_CM;
                    numericUpDown_height_cm.Value = (decimal)carton.Height_CM;
                    checkBox_inactive.Checked = !carton.Active;
                }
                this.ActiveControl = numericUpDown_length_in;
                numericUpDown_length_in.Select(0, Convert.ToDouble(numericUpDown_length_in.Value).ToString("0.00").Length);
            }
        }

        private double InchToCentimetre(double inch)
        {
            double centimetre = inch * 2.54;
            return Math.Round(centimetre, 2);
        }

        private double CentimetreToInch(double centimetre)
        {
            double inch = centimetre / 2.54;
            return Math.Round(inch, 2);
        }

        private (bool, bool) InsertUpdate()
        {
            bool issuccess = false;
            bool _continue = false;
            try
            {
                bool validated = true;
                Carton newcarton = new Carton();
                newcarton.Carton_ID = textBox_cartonid.Text.Trim();
                newcarton.Length_IN = (double)numericUpDown_length_in.Value;
                newcarton.Width_IN = (double)numericUpDown_width_in.Value;
                newcarton.Height_IN = (double)numericUpDown_height_in.Value;
                newcarton.Length_CM = (double)numericUpDown_length_cm.Value;
                newcarton.Width_CM = (double)numericUpDown_width_cm.Value;
                newcarton.Height_CM = (double)numericUpDown_height_cm.Value;
                newcarton.Active = !checkBox_inactive.Checked;
                if (string.IsNullOrEmpty(newcarton.Carton_ID))
                {
                    validated = false;
                    string errormsg = "[Carton] Please enter a Carton ID";
                    Logger.Log(Logger.LogLevel.ERROR, errormsg);
                    MessageBox.Show(errormsg, "Error Input Carton ID",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (newcarton.Length_IN.Equals(0)
                    || newcarton.Width_IN.Equals(0)
                    || newcarton.Height_IN.Equals(0)
                    || newcarton.Length_CM.Equals(0)
                    || newcarton.Width_CM.Equals(0)
                    || newcarton.Height_CM.Equals(0)
                    )
                {
                    validated = false;
                    string errormsg = "[Carton] Please enter valid dimension value. Dimension size must larger than zero.";
                    Logger.Log(Logger.LogLevel.ERROR, errormsg);
                    MessageBox.Show(errormsg, "Error Input Dimension",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.Text.Equals("New Carton") // IF insert new carton, then check duplication
                    && (ls_carton.Any(c => c.Carton_ID.Equals(newcarton.Carton_ID))
                    || (ls_carton.Any(c => c.Length_IN.Equals(newcarton.Length_IN))
                    && ls_carton.Any(c => c.Width_IN.Equals(newcarton.Width_IN))
                    && ls_carton.Any(c => c.Height_IN.Equals(newcarton.Height_IN)))
                    || (ls_carton.Any(c => c.Length_CM.Equals(newcarton.Length_CM))
                    && ls_carton.Any(c => c.Width_CM.Equals(newcarton.Width_CM))
                    && ls_carton.Any(c => c.Height_CM.Equals(newcarton.Height_CM)))))
                {
                    validated = false;
                    if (ls_carton.Any(c => c.Carton_ID.Equals(newcarton.Carton_ID)))
                    {
                        string errormsg = $"[Carton] Carton ID {newcarton.Carton_ID} existed";
                        Logger.Log(Logger.LogLevel.ERROR, errormsg);
                        MessageBox.Show(errormsg, "Duplicate Carton ID",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string errormsg = $"[Carton] Inputed carton dimension have already existed";
                        Logger.Log(Logger.LogLevel.ERROR, errormsg);
                        MessageBox.Show(errormsg, "Duplicate Carton Dimension",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (validated)
                {
                    if (button_insertupdate.Text.ToLower().Equals("insert"))
                    {
                        var (inserted, insert_errormsg) = sql_call.InsertCarton(newcarton);
                        if (inserted)
                        {
                            DialogResult havemore = MessageBox.Show($"New Carton {newcarton.Carton_ID} inserted." +
                                $"{System.Environment.NewLine}Do you want to add more new carton dimension?", 
                                "Inserted",
                                MessageBoxButtons.YesNo);
                            if (havemore.Equals(DialogResult.Yes))
                            {
                                _continue = true;
                            }
                            issuccess = true;
                        }
                        else
                        {
                            MessageBox.Show($"New Carton {newcarton.Carton_ID} inserted Failure." +
                                $"{System.Environment.NewLine}Error Message: {insert_errormsg}", "Insert Failure",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (button_insertupdate.Text.ToLower().Equals("update"))
                    {
                        var (updated, error_msg) = sql_call.UpdateCarton(newcarton);
                        if (updated && string.IsNullOrEmpty(error_msg))
                        {
                            MessageBox.Show($"Carton {textBox_cartonid.Text} updated.", "Updated",
                                MessageBoxButtons.OK);
                            issuccess = true;
                        }
                        else
                        {
                            MessageBox.Show("Error Update Conton." +
                                $"{System.Environment.NewLine}{error_msg}", "Error Update Conton",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"CartonDimension - InsertUpdate Error: {ex.Message}");
            }
            return (issuccess, _continue);
        }

        private void ClearAll()
        {
            textBox_cartonid.Clear();
            numericUpDown_length_in.Value = 0;
            numericUpDown_width_in.Value = 0;
            numericUpDown_height_in.Value = 0;
            numericUpDown_length_cm.Value = 0;
            numericUpDown_width_cm.Value = 0;
            numericUpDown_height_cm.Value = 0;
            checkBox_inactive.Checked = false;
            this.ActiveControl = textBox_cartonid;
        }

        private void CartonDimension_Load(object sender, EventArgs e)
        {
            Logger.Log(Logger.LogLevel.INFO, "===== New Carton Dimension Form Open =====");
        }

        private void CartonDimension_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_addednew)
            {
                this.DialogResult = DialogResult.OK;
            }
            Logger.Log(Logger.LogLevel.INFO, "===== New Carton Dimension Form Closed =====");
        }

        private void button_insertupdate_Click(object sender, EventArgs e)
        {
            Logger.Log(Logger.LogLevel.INFO, $"INSERTUPDATE button clicked . {button_insertupdate.Text}");
            var (issuccess, _continue) = InsertUpdate();
            if (issuccess)
            {
                _addednew = true;
                if (_continue)
                {
                    ClearAll();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void numericUpDown_length_in_Leave(object sender, EventArgs e)
        {
            if (!numericUpDown_length_in.Value.Equals(0))
            {
                numericUpDown_length_cm.Value = Convert.ToDecimal(InchToCentimetre((double)numericUpDown_length_in.Value));
            }
        }

        private void numericUpDown_width_in_Leave(object sender, EventArgs e)
        {
            if (!numericUpDown_width_in.Value.Equals(0))
            {
                numericUpDown_width_cm.Value = Convert.ToDecimal(InchToCentimetre((double)numericUpDown_width_in.Value));
            }
        }

        private void numericUpDown_height_in_Leave(object sender, EventArgs e)
        {
            if (!numericUpDown_height_in.Value.Equals(0))
            {
                numericUpDown_height_cm.Value = Convert.ToDecimal(InchToCentimetre((double)numericUpDown_height_in.Value));
            }
        }

        private void numericUpDown_length_cm_Leave(object sender, EventArgs e)
        {
            if (!numericUpDown_length_cm.Value.Equals(0))
            {
                numericUpDown_length_in.Value = Convert.ToDecimal(CentimetreToInch((double)numericUpDown_length_cm.Value));
            }
        }

        private void numericUpDown_width_cm_Leave(object sender, EventArgs e)
        {
            if (!numericUpDown_width_cm.Value.Equals(0))
            {
                numericUpDown_width_in.Value = Convert.ToDecimal(CentimetreToInch((double)numericUpDown_width_cm.Value));
            }
        }

        private void numericUpDown_height_cm_Leave(object sender, EventArgs e)
        {
            if (!numericUpDown_height_cm.Value.Equals(0))
            {
                numericUpDown_height_in.Value = Convert.ToDecimal(CentimetreToInch((double)numericUpDown_height_cm.Value));
            }
        }

        private void textBox_cartonid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                textBox_cartonid.Clear();
            }
        }

        private void textBox_cartonid_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9]");
            if (regex.IsMatch(e.KeyChar.ToString()) && !e.KeyChar.Equals((char)8))
            {
                e.Handled = true;
            }
        }

        private void numericUpDown_length_in_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    numericUpDown_length_in.Value = 0;
                    numericUpDown_length_cm.Value = 0;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"Length IN enter invalid value. Error: {ex.Message}");
                MessageBox.Show($"Please enter proper Length value in IN.", "Insert Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown_width_in_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                numericUpDown_width_in.Value = 0;
                numericUpDown_width_cm.Value = 0;
            }
        }

        private void numericUpDown_height_in_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                numericUpDown_height_in.Value = 0;
                numericUpDown_height_cm.Value = 0;
            }
        }

        private void numericUpDown_length_cm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                numericUpDown_length_in.Value = 0;
                numericUpDown_length_cm.Value = 0;
            }
        }

        private void numericUpDown_width_cm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                numericUpDown_width_in.Value = 0;
                numericUpDown_width_cm.Value = 0;
            }
        }

        private void numericUpDown_height_cm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                numericUpDown_height_in.Value = 0;
                numericUpDown_height_cm.Value = 0;
            }
        }

        private void numericUpDown_length_in_Enter(object sender, EventArgs e)
        {
            numericUpDown_length_in.Select(0, Convert.ToDouble(numericUpDown_length_in.Value).ToString("0.00").Length);
        }

        private void numericUpDown_width_in_Enter(object sender, EventArgs e)
        {
            numericUpDown_width_in.Select(0, Convert.ToDouble(numericUpDown_width_in.Value).ToString("0.00").Length);
        }

        private void numericUpDown_height_in_Enter(object sender, EventArgs e)
        {
            numericUpDown_height_in.Select(0, Convert.ToDouble(numericUpDown_height_in.Value).ToString("0.00").Length);
        }

        private void numericUpDown_length_cm_Enter(object sender, EventArgs e)
        {
            numericUpDown_length_cm.Select(0, Convert.ToDouble(numericUpDown_length_cm.Value).ToString("0.00").Length);
        }

        private void numericUpDown_width_cm_Enter(object sender, EventArgs e)
        {
            numericUpDown_width_cm.Select(0, Convert.ToDouble(numericUpDown_width_cm.Value).ToString("0.00").Length);
        }

        private void numericUpDown_height_cm_Enter(object sender, EventArgs e)
        {
            numericUpDown_height_cm.Select(0, Convert.ToDouble(numericUpDown_height_cm.Value).ToString("0.00").Length);
        }

        private void numericUpDown_length_in_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown_length_in.Value > maximal_in)
                {
                    numericUpDown_length_in.Value = maximal_in;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"Length IN enter invalid value. Error: {ex.Message}");
                MessageBox.Show($"Please enter proper Length value in IN.", "Insert Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown_width_in_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown_width_in.Value > maximal_in)
                {
                    numericUpDown_width_in.Value = maximal_in;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"Width IN enter invalid value. Error: {ex.Message}");
                MessageBox.Show($"Please enter proper Width value in IN.", "Insert Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown_height_in_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown_height_in.Value > maximal_in)
                {
                    numericUpDown_height_in.Value = maximal_in;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"Height IN enter invalid value. Error: {ex.Message}");
                MessageBox.Show($"Please enter proper Height value in IN.", "Insert Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown_length_cm_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown_length_cm.Value > maximal_cm)
                {
                    numericUpDown_length_cm.Value = maximal_cm;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"Length CM enter invalid value. Error: {ex.Message}");
                MessageBox.Show($"Please enter proper Length value in CM.", "Insert Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown_width_cm_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown_width_cm.Value > maximal_cm)
                {
                    numericUpDown_width_cm.Value = maximal_cm;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"Width CM enter invalid value. Error: {ex.Message}");
                MessageBox.Show($"Please enter proper Width value in CM.", "Insert Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown_height_cm_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown_height_cm.Value > maximal_cm)
                {
                    numericUpDown_height_cm.Value = maximal_cm;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"Height CM enter invalid value. Error: {ex.Message}");
                MessageBox.Show($"Please enter proper Height value in CM.", "Insert Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
