using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDimension_APP
{
    public partial class Form1 : Form
    {
        private static string product_template = ConfigurationManager.AppSettings["PRODUCT_TEMPLATE"];

        private SQLQuery sql_call = new SQLQuery();
        private ReadImport readimport = new ReadImport();

        private List<Carton> ls_carton = new List<Carton>();
        private DataTable carton_table = new DataTable();

        private List<Product> ls_product = new List<Product>();
        private DataTable product_table = new DataTable();

        private static bool updated_carton = false;
        private static bool updated_product = false;

        private static int current_year = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadCartons();
            ReloadProducts();
            numericUpDown_holiday_year.Value = DateTime.Today.Year;
            monthCalendar_holiday.Refresh();
            dataGridView_holiday.AutoSize = true;
            current_year = DateTime.Now.Year;
        }

        private void tabControl_home_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_home.SelectedTab != null)
            {
                if (tabControl_home.SelectedTab.Text.ToLower().Equals("carton"))
                {
                    string error_msg = string.Empty;
                    (ls_carton, carton_table, error_msg) = sql_call.GetCartons();
                }
                else if (tabControl_home.SelectedTab.Text.ToLower().Equals("product"))
                {
                    string error_msg = string.Empty;
                    if (updated_carton)
                    {
                        ReloadProducts();
                    }
                    else
                    {
                        (ls_product, product_table, error_msg) = sql_call.GetProducts();
                    }
                }
            }
        }

        #region Carton
        private void ReloadCartons()
        {
            string error_msg = string.Empty;
            (ls_carton, carton_table, error_msg) = sql_call.GetCartons();
            dataGridView_carton.Rows.Clear();
            if (string.IsNullOrEmpty(error_msg))
            {
                foreach (var carton in ls_carton.OrderByDescending(c => c.Active).ThenBy(c => c.Carton_ID))
                {
                    object[] row = { carton.Active, carton.Carton_ID,
                        carton.Length_IN, carton.Width_IN, carton.Height_IN,
                        carton.Length_CM, carton.Width_CM, carton.Height_CM };
                    dataGridView_carton.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Error Loading Cartons Data." +
                    $"{System.Environment.NewLine}{error_msg}", "Error Loading Carton Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void button_newcarton_Click(object sender, EventArgs e)
        {
            CartonDimension cartonform = new CartonDimension("new", ls_carton);
            if (cartonform.ShowDialog().Equals(DialogResult.OK))
            {
                sql_call.RefreshDefaultCarton();
                ReloadCartons();
            }
        }

        private void dataGridView_carton_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!e.RowIndex.Equals(-1))
            {
                if (!dataGridView_carton.SelectedRows.Count.Equals(0))
                {
                    DataGridViewRow selected = dataGridView_carton.SelectedRows[0];
                    string cartonid = selected.Cells[Column_cartonid.Index].Value.ToString();
                    var updatecarton = ls_carton.Find(c => c.Carton_ID.Equals(cartonid));
                    if (updatecarton != null)
                    {
                        CartonDimension cartonform = new CartonDimension("update", ls_carton, updatecarton);
                        if (cartonform.ShowDialog().Equals(DialogResult.OK))
                        {
                            updated_carton = true;
                            sql_call.RefreshDefaultCarton();
                            ReloadCartons();
                            foreach (DataGridViewRow row in dataGridView_carton.Rows)
                            {
                                if (row.Cells[Column_cartonid.Index].Value.ToString().Equals(cartonid))
                                {
                                    row.Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Product
        private void ReloadProducts()
        {
            string error_msg = string.Empty;
            (ls_product, product_table, error_msg) = sql_call.GetProducts();
            if (string.IsNullOrEmpty(error_msg))
            {
                product_table.DefaultView.Sort = "Shoe Type DESC, SKU ASC";
                dataGridView_product.DataSource = product_table;
            }
            else
            {
                MessageBox.Show("Error Loading Products Data." +
                    $"{System.Environment.NewLine}{error_msg}", "Error Loading Product Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            updated_carton = false;
        }

        private void ApplyFilter()
        {
            if (!string.IsNullOrEmpty(textBox_product_sku.Text))
            {
                string rowFilter = string.Format("[{0}] like '%{1}%'", "SKU", textBox_product_sku.Text.Trim());
                (dataGridView_product.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else
            {
                (dataGridView_product.DataSource as DataTable).DefaultView.RowFilter = null;
            }
        }

        private void button_product_new_Click(object sender, EventArgs e)
        {
            ProductDimension productdimension = new ProductDimension("new", ls_product);
            if (productdimension.ShowDialog().Equals(DialogResult.OK))
            {
                ReloadProducts();
                ApplyFilter();
            }
        }

        private void button_product_newimport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openimport = new OpenFileDialog();
            openimport.Filter = "csv files (*.csv)|*.csv|Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openimport.ShowDialog().Equals(DialogResult.OK))
            {
                Cursor.Current = Cursors.WaitCursor;
                string importfile = openimport.FileName;
                Logger.Log(Logger.LogLevel.INFO, $"User selected import product file: {importfile}");
                if (readimport.ReadProduct(importfile, product_table))
                {
                    ReloadProducts();
                    ApplyFilter();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void button_product_export_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string mydocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var previouspath = new DirectoryInfo(mydocumentPath).Parent.FullName;
                var downloadsPath = System.IO.Path.Combine(previouspath, "Downloads");
                if (!Directory.Exists(downloadsPath))
                {
                    SaveFileDialog savefiledialog = new SaveFileDialog();
                    savefiledialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                    savefiledialog.FilterIndex = 2;
                    savefiledialog.RestoreDirectory = true;
                    if (savefiledialog.ShowDialog().Equals(DialogResult.OK))
                    {
                        downloadsPath = savefiledialog.FileName;
                    }
                }
                var csv = new StringBuilder();
                List<string> csv_column = new List<string>() 
                { 
                    "SKU", 
                    "Command", 
                    "Package Length", 
                    "Package Width", 
                    "Package Height", 
                    "Package Weight" 
                };
                csv.AppendLine(string.Join(",", csv_column));
                foreach (var prod in ls_product)
                {
                    csv.AppendLine($"{prod.SKU},UPDATE," +
                        $"{prod.Package_Length},{prod.Package_Width},{prod.Package_Height}," +
                        $"{prod.Package_Weight}");
                }
                string savefilename = downloadsPath + @"\" + $"Export_ProductDimension_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
                if (File.Exists(savefilename + ".csv"))
                {
                    int file_subfix = 1;
                    while (File.Exists(savefilename + $" ({file_subfix.ToString()}).csv"))
                    {
                        file_subfix += 1;
                    }
                    savefilename = savefilename + $" ({file_subfix.ToString()})";
                }
                savefilename = savefilename + ".csv";
                File.WriteAllText(savefilename, csv.ToString());
                Logger.Log(Logger.LogLevel.INFO, $"Product Dimension export saved : {savefilename}");
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Product Dimension Exported.",
                            "Product Dimension Export",
                            MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"Product Dimension export Error : {ex.Message}");
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Error occur while export product dimensions.",
                            "Product Dimension Export Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_product_reload_Click(object sender, EventArgs e)
        {
            ReloadProducts();
            ApplyFilter();
        }

        private void label_product_downloadtemplate_Click(object sender, EventArgs e)
        {
            string current_template = string.Empty;
            string savedirectory = string.Empty;
            string mydocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var previouspath = new DirectoryInfo(mydocumentPath).Parent.FullName;
            var downloadsPath = System.IO.Path.Combine(previouspath, "Downloads");
            if (Directory.Exists(downloadsPath))
            {
                savedirectory = downloadsPath;
            }
            else
            {
                SaveFileDialog savefiledialog = new SaveFileDialog();
                savefiledialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                savefiledialog.FilterIndex = 2;
                savefiledialog.RestoreDirectory = true;
                if (savefiledialog.ShowDialog().Equals(DialogResult.OK))
                {
                    savedirectory = savefiledialog.FileName;
                }
            }
            if (Directory.Exists(savedirectory))
            {
                bool template_download = false;
                string savefilename = savedirectory + @"\product_dimension_template";
                if (File.Exists(product_template))
                {
                    savefilename += ".xlsx";
                    if (File.Exists(savefilename))
                    {
                        int index = 2;
                        while (File.Exists(savedirectory + @"\product_dimension_template" + $" ({index}).xlsx"))
                        {
                            index += 1;
                        }
                        savefilename = savedirectory + @"\product_dimension_template" + $" ({index}).xlsx";
                    }
                    File.Copy(product_template, savefilename, true);
                    Logger.Log(Logger.LogLevel.INFO, $"Product Dimension Template saved I: {savefilename}");
                    template_download = true;
                }
                else
                {
                    savefilename += ".csv";
                    if (File.Exists(savefilename))
                    {
                        int index = 2;
                        while (File.Exists(savedirectory + @"\product_dimension_template" + $" ({index}).csv"))
                        {
                            index += 1;
                        }
                        savefilename = savedirectory + @"\product_dimension_template" + $" ({index}).csv";
                    }
                    var csv = new StringBuilder();
                    List<string> columns = new List<string>();
                    foreach (DataColumn col in product_table.Columns)
                    {
                        if (col.ColumnName.ToUpper().Equals("DEFAULT CARTON")
                            || col.ColumnName.ToUpper().Contains("UNITOFMEASURE"))
                        {
                            continue;
                        }
                        columns.Add(col.ColumnName);
                    }
                    csv.AppendLine(string.Join(",", columns));
                    int counter = 0;
                    foreach (var prod in ls_product.Where(p => p.Shoe_Type.ToUpper().Contains("MENSWOMENS")))
                    {
                        if (counter.Equals(0))
                        {
                            csv.AppendLine($"{prod.Shoe_Type},{prod.SKU},{prod.UPC},{prod.Product_Name}," +
                                $"{prod.Package_Length},{prod.Package_Width},{prod.Package_Height}," +
                                $"{prod.Package_Weight}");
                        }
                        else if (counter.Equals(1))
                        {
                            csv.AppendLine($"{prod.Shoe_Type},{prod.SKU},,," +
                                $"{prod.Package_Length},{prod.Package_Width},{prod.Package_Height}," +
                                $"{prod.Package_Weight}");
                        }
                        counter += 1;
                        if (counter >= 2)
                        {
                            break;
                        }
                    }
                    foreach (var prod in ls_product.Where(p => p.Shoe_Type.ToUpper().Contains("CHILDRENS")))
                    {
                        if (counter.Equals(2))
                        {
                            csv.AppendLine($"{prod.Shoe_Type},{prod.SKU},{prod.UPC},{prod.Product_Name}," +
                                $"{prod.Package_Length},{prod.Package_Width},{prod.Package_Height}," +
                                $"{prod.Package_Weight}");
                        }
                        else if (counter.Equals(3))
                        {
                            csv.AppendLine($"{prod.Shoe_Type},{prod.SKU},,," +
                                $"{prod.Package_Length},{prod.Package_Width},{prod.Package_Height}," +
                                $"{prod.Package_Weight}");
                        }
                        counter += 1;
                        if (counter >= 4)
                        {
                            break;
                        }
                    }
                    File.WriteAllText(savefilename, csv.ToString());
                    Logger.Log(Logger.LogLevel.INFO, $"Product Dimension Template saved II: {savefilename}");
                    template_download = true;
                }
                if (template_download)
                {
                    MessageBox.Show($"Product Template Downloaded.",
                        "Product Template",
                        MessageBoxButtons.OK);
                }
            }
        }

        private void textBox_product_sku_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void textBox_product_sku_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                textBox_product_sku.Clear();
            }
        }

        private void dataGridView_product_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!e.RowIndex.Equals(-1))
            {
                if (!dataGridView_product.SelectedRows.Count.Equals(0))
                {
                    DataGridViewRow selected = dataGridView_product.SelectedRows[0];
                    string sku = selected.Cells["SKU"].Value.ToString();
                    var updateproduct = ls_product.Find(c => c.SKU.Equals(sku));
                    if (updateproduct != null)
                    {
                        ProductDimension productform = new ProductDimension("update", ls_product, updateproduct);
                        if (productform.ShowDialog().Equals(DialogResult.OK))
                        {
                            updated_product = true;
                            sql_call.RefreshDefaultCarton();
                            ReloadProducts();
                            ApplyFilter();
                            foreach (DataGridViewRow row in dataGridView_product.Rows)
                            {
                                if (row.Cells["SKU"].Value.ToString().Equals(sku))
                                {
                                    row.Selected = true;
                                    dataGridView_product.FirstDisplayedCell = row.Cells["SKU"];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Holiday
        private DateTime dateselected = DateTime.Now;

        private void ReloadHoliday(List<DateTime> ls_holiday)
        {
            dataGridView_holiday.Rows.Clear();
            foreach (var holiday in ls_holiday.OrderBy(h => h))
            {
                dataGridView_holiday.Rows.Add(holiday.ToString("yyyy-MM-dd"));
            }
            dataGridView_holiday.Refresh();
        }

        private void monthCalendar_holiday_Enter(object sender, EventArgs e)
        {
            button_holiday_add.Enabled = true;
            button_holiday_remove.Enabled = false;
        }

        private void dataGridView_holiday_Enter(object sender, EventArgs e)
        {
            button_holiday_add.Enabled = false;
            button_holiday_remove.Enabled = true;
        }

        private void monthCalendar_holiday_DateSelected(object sender, DateRangeEventArgs e)
        {
            dateselected = e.End;
            if (!dateselected.Year.Equals(current_year))
            {
                numericUpDown_holiday_year.Value = dateselected.Year;
                current_year = dateselected.Year;
            }
        }

        private void monthCalendar_holiday_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateselected = e.End;
            if (!dateselected.Year.Equals(current_year))
            {
                numericUpDown_holiday_year.Value = dateselected.Year;
                current_year = dateselected.Year;
            }
        }

        private void button_holiday_add_Click(object sender, EventArgs e)
        {
            bool holiday_existed = false;
            foreach (DataGridViewRow row in dataGridView_holiday.Rows)
            {
                DateTime rowdate;
                if (DateTime.TryParse(row.Cells[Column_holiday.Index].Value.ToString(), out rowdate))
                {
                    if (rowdate.Date.Equals(dateselected.Date))
                    {
                        holiday_existed = true;
                        break;
                    }
                }
            }
            if (holiday_existed)
            {
                MessageBox.Show($"Holiday existed {dateselected.ToString("yyyy-MM-dd")}",
                    "Existed Holiday",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var (ls_holiday, error_msg) = sql_call.AddHoliday(dateselected);
                if (string.IsNullOrEmpty(error_msg))
                {
                    Logger.Log(Logger.LogLevel.INFO, $"New Holiday added: {dateselected.ToString("yyyy-MM-dd")}");
                    if (Convert.ToInt32(numericUpDown_holiday_year.Value).Equals(dateselected.Year))
                    {
                        ReloadHoliday(ls_holiday);
                    }
                    else
                    {
                        numericUpDown_holiday_year.Value = dateselected.Year;
                    }
                    foreach (DataGridViewRow row in dataGridView_holiday.Rows)
                    {
                        if (row.Cells[Column_holiday.Index].Value.ToString().Equals(dateselected.ToString("yyyy-MM-dd")))
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void button_holiday_remove_Click(object sender, EventArgs e)
        {
            if (!dataGridView_holiday.SelectedRows.Count.Equals(0))
            {
                var removedate = DateTime.Parse(dataGridView_holiday.SelectedRows[0].Cells[Column_holiday.Index].Value.ToString());
                DialogResult remove = MessageBox.Show($"Are you sure to remove holiday {removedate.ToString("yyyy-MM-dd")}",
                    "Remove Holiday",
                    MessageBoxButtons.YesNo);
                if (remove.Equals(DialogResult.Yes))
                {
                    var (ls_holiday, error_msg) = sql_call.RemoveHoliday(removedate);
                    if (string.IsNullOrEmpty(error_msg))
                    {
                        Logger.Log(Logger.LogLevel.INFO, $"Holiday removed: {removedate.ToString("yyyy-MM-dd")}");
                        ReloadHoliday(ls_holiday);
                    }
                }
            }
        }

        private void numericUpDown_holiday_year_ValueChanged(object sender, EventArgs e)
        {
            Logger.Log(Logger.LogLevel.INFO, $"Year Picker set year: {numericUpDown_holiday_year.Value}");
            int year = Convert.ToInt32(numericUpDown_holiday_year.Value);
            monthCalendar_holiday.SetDate(new DateTime(year, 1, 1));
            monthCalendar_holiday.Update();
            var (ls_holiday, error_msg) = sql_call.GetHolidays(year);
            if (string.IsNullOrEmpty(error_msg))
            {
                ReloadHoliday(ls_holiday);
            }
        }

        #endregion
    }
}
