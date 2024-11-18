using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDimension_APP
{
    public partial class ProductDimension : Form
    {
        private SQLQuery sql_call = new SQLQuery();
        private List<Product> ls_product = new List<Product>();

        private decimal maximal = 100;
        private static bool _addednew = false;

        public ProductDimension(string mode, List<Product> ls_exist, Product product = null)
        {
            InitializeComponent();
            comboBox_shoetype.SelectedIndex = 0;
            ls_product = ls_exist;
            if (mode.ToLower().Equals("new"))
            {
                this.Text = "New Product";
                button_insertupdate.Text = "Insert";
                button_clear.Enabled = true;
                button_clear.Visible = true;
                comboBox_shoetype.Enabled = true;
                textBox_sku.ReadOnly = false;
                textBox_upc.ReadOnly = false;
                textBox_productname.ReadOnly = false;
                numericUpDown_length_in.Value = 0;
                numericUpDown_width_in.Value = 0;
                numericUpDown_height_in.Value = 0;
            }
            else if (mode.ToLower().Equals("update"))
            {
                this.Text = "Update Product";
                button_insertupdate.Text = "Update";
                button_clear.Enabled = false;
                button_clear.Visible = false;
                comboBox_shoetype.Enabled = false;
                textBox_sku.ReadOnly = true;
                textBox_upc.ReadOnly = true;
                textBox_productname.ReadOnly = true;
                if (product != null)
                {
                    comboBox_shoetype.SelectedIndex = comboBox_shoetype.Items.IndexOf(product.Shoe_Type);
                    textBox_sku.Text = product.SKU;
                    textBox_upc.Text = product.UPC;
                    textBox_productname.Text = product.Product_Name;
                    numericUpDown_length_in.Value = (decimal)product.Package_Length;
                    numericUpDown_width_in.Value = (decimal)product.Package_Width;
                    numericUpDown_height_in.Value = (decimal)product.Package_Height;
                    numericUpDown_weight_lb.Value = (decimal)product.Package_Weight;
                }
            }
        }

        private (bool, bool) InsertUpdate()
        {
            bool issuccess = false;
            bool _continue = false;
            try
            {
                bool validated = true;
                Product newprod = new Product();
                newprod.Shoe_Type = comboBox_shoetype.SelectedItem.ToString();
                newprod.SKU = textBox_sku.Text.Trim();
                newprod.UPC = textBox_upc.Text.Trim();
                newprod.Product_Name = textBox_productname.Text.Trim();
                newprod.Package_Length = (double)numericUpDown_length_in.Value;
                newprod.Package_Width = (double)numericUpDown_width_in.Value;
                newprod.Package_Height = (double)numericUpDown_height_in.Value;
                newprod.Package_Weight = (double)numericUpDown_weight_lb.Value;
                if (string.IsNullOrEmpty(newprod.SKU))
                {
                    validated = false;
                    string errormsg = "[Product] Please enter a product SKU";
                    Logger.Log(Logger.LogLevel.ERROR, errormsg);
                    MessageBox.Show(errormsg, "Error Input SKU",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (newprod.Package_Length.Equals(0)
                    || newprod.Package_Width.Equals(0)
                    || newprod.Package_Height.Equals(0)
                    || newprod.Package_Weight.Equals(0)
                    )
                {
                    validated = false;
                    string errormsg = "[Product] Please enter valid dimension value. Dimension size must larger than zero.";
                    Logger.Log(Logger.LogLevel.ERROR, errormsg);
                    MessageBox.Show(errormsg, "Error Input Dimension",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.Text.Equals("New Product") // IF insert new product, then check duplication
                    && ls_product.Any(c => c.SKU.Equals(newprod.SKU)))
                {
                    validated = false;
                    string errormsg = $"[Product] New Product SKU {newprod.SKU} existed";
                    Logger.Log(Logger.LogLevel.ERROR, errormsg);
                        MessageBox.Show(errormsg, "Duplicate Product SKU",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (validated)
                {
                    if (button_insertupdate.Text.ToLower().Equals("insert"))
                    {
                        var importreport = sql_call.InsertProducts(new List<Product>() { newprod });
                        if (importreport.All(i => i.message.All(m => m.Equals("SUCCESS"))))
                        {
                            DialogResult havemore = MessageBox.Show($"New Product {newprod.SKU} inserted." +
                                $"{System.Environment.NewLine}Do you want to add more new product dimension?",
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
                            string errormsg = string.Join(";", importreport.Where(i => !i.message.All(m => m.Equals("SUCCESS"))));
                            MessageBox.Show($"New Product Dimension {newprod.SKU} inserted Failure." +
                                $"{System.Environment.NewLine}Error Message: {errormsg}", "Insert Failure",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (button_insertupdate.Text.ToLower().Equals("update"))
                    {
                        var importreport = sql_call.UpdateProducts(new List<Product>() { newprod });
                        if (importreport.All(i => i.message.All(m => m.Equals("SUCCESS"))))
                        {
                            MessageBox.Show($"Product {textBox_sku.Text} updated.", "Updated",
                                MessageBoxButtons.OK);
                            issuccess = true;
                        }
                        else
                        {
                            string errormsg = string.Join(";", importreport.Where(i => !i.message.All(m => m.Equals("SUCCESS"))));
                            MessageBox.Show("Error Update Product." +
                                $"{System.Environment.NewLine}{errormsg}", "Error Update Product",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"ProductDimension - InsertUpdate Error: {ex.Message}");
            }
            return (issuccess, _continue);
        }

        private void ClearAll()
        {
            comboBox_shoetype.SelectedIndex = 0;
            textBox_sku.Clear();
            textBox_upc.Clear();
            textBox_productname.Clear();
            numericUpDown_length_in.Value = 0;
            numericUpDown_width_in.Value = 0;
            numericUpDown_height_in.Value = 0;
            numericUpDown_weight_lb.Value = 0;
            this.ActiveControl = comboBox_shoetype;
        }

        private void button_insertupdate_Click(object sender, EventArgs e)
        {
            Logger.Log(Logger.LogLevel.INFO, "INSERT button clicked");
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

        private void ProductDimension_Load(object sender, EventArgs e)
        {
            Logger.Log(Logger.LogLevel.INFO, "===== New Product Dimension Form Open =====");
            this.ActiveControl = comboBox_shoetype;
        }

        private void ProductDimension_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_addednew)
            {
                this.DialogResult = DialogResult.OK;
            }
            Logger.Log(Logger.LogLevel.INFO, "===== New Product Dimension Form Closed =====");
        }

        private void textBox_sku_Enter(object sender, EventArgs e)
        {
            textBox_sku.SelectAll();
        }

        private void textBox_upc_Enter(object sender, EventArgs e)
        {
            textBox_upc.SelectAll();
        }

        private void textBox_productname_Enter(object sender, EventArgs e)
        {
            textBox_productname.SelectAll();
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

        private void numericUpDown_weight_lb_Enter(object sender, EventArgs e)
        {
            numericUpDown_weight_lb.Select(0, Convert.ToDouble(numericUpDown_weight_lb.Value).ToString("0.00").Length);
        }

        private void textBox_sku_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                textBox_sku.Clear();
            }
        }

        private void textBox_upc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                textBox_upc.Clear();
            }
        }

        private void textBox_productname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                textBox_productname.Clear();
            }
        }

        private void numericUpDown_length_in_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    numericUpDown_length_in.Value = 0;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"Please enter proper Length value in IN.", "Insert Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown_width_in_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                numericUpDown_width_in.Value = 0;
            }
        }

        private void numericUpDown_height_in_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                numericUpDown_height_in.Value = 0;
            }
        }

        private void numericUpDown_weight_lb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                numericUpDown_weight_lb.Value = 0;
            }
        }

        private void textBox_upc_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^0-9]");
            if (regex.IsMatch(e.KeyChar.ToString()) && !e.KeyChar.Equals((char)8))
            {
                e.Handled = true;
            }
        }

        private void numericUpDown_length_in_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown_length_in.Value > maximal)
                {
                    numericUpDown_length_in.Value = maximal;
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
                if (numericUpDown_width_in.Value > maximal)
                {
                    numericUpDown_width_in.Value = maximal;
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
                if (numericUpDown_height_in.Value > maximal)
                {
                    numericUpDown_height_in.Value = maximal;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"Height IN enter invalid value. Error: {ex.Message}");
                MessageBox.Show($"Please enter proper Height value in IN.", "Insert Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown_weight_lb_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown_weight_lb.Value > maximal)
                {
                    numericUpDown_weight_lb.Value = maximal;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"Weight IN enter invalid value. Error: {ex.Message}");
                MessageBox.Show($"Please enter proper Weight value in LB.", "Insert Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
