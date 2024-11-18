using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using ExcelDataReader;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text.RegularExpressions;

namespace NewDimension_APP
{
    internal class ReadImport
    {
        private SQLQuery sql_call = new SQLQuery();

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

        #region Carton
        public void ReadCarton(string importfile, DataTable carton_table)
        {
            bool formatok = false;
            List<string> formaterror = new List<string>();
            List<Carton> newcartons = new List<Carton>();
            if (importfile.EndsWith(".csv"))
            {
                (formatok, formaterror, newcartons) = ReadCarton_CSV(importfile, carton_table);
            }
            else if (importfile.EndsWith(".xlsx"))
            {
                (formatok, formaterror, newcartons) = ReadCarton_Excel(importfile, carton_table);
            }
            InsertCartons(formatok, formaterror, newcartons);
        }

        public (bool, List<string>, List<Carton>) ReadCarton_CSV(string importfile, DataTable carton_table)
        {
            var readfile = File.ReadAllLines(importfile);
            var headers = readfile.First().Split(',').Select(h => h.ToUpper()).ToList();
            bool formatok = true;
            List<string> formaterror = new List<string>();
            for (int i = 0; i < carton_table.Columns.Count; i++)
            {
                if (!headers.Contains(carton_table.Columns[i].ColumnName.ToUpper()))
                {
                    formatok = false;
                    string errormsg = $"Header {carton_table.Columns[i].ColumnName.ToUpper()} is required";
                    Logger.Log(Logger.LogLevel.ERROR, $"[import new carton] {errormsg}");
                    formaterror.Add(errormsg);
                }
            }
            if (formatok)
            {
                readfile.Skip(1);
            }
            int counter = 1;
            List<Carton> newcartons = new List<Carton>();
            foreach (var row in readfile)
            {
                counter += 1;
                var items = row.Split(',');
                double lenght_cm;
                double width_cm;
                double height_cm;
                double length_in;
                double width_in;
                double height_in;
                if (!string.IsNullOrEmpty(items[0]) // carton_id
                    && ((double.TryParse(items[1], out lenght_cm)
                    && double.TryParse(items[2], out width_cm)
                    && double.TryParse(items[3], out height_cm))
                    || (double.TryParse(items[4], out length_in)
                    && double.TryParse(items[5], out width_in)
                    && double.TryParse(items[6], out height_in))))
                {
                    Carton newcarton = new Carton();
                    newcarton.Carton_ID = items[0].Trim();
                    if (double.TryParse(items[1], out lenght_cm)
                        && double.TryParse(items[2], out width_cm)
                        && double.TryParse(items[3], out height_cm))
                    {
                        newcarton.Length_CM = lenght_cm;
                        newcarton.Width_CM = width_cm;
                        newcarton.Height_CM = height_cm;
                        if (double.TryParse(items[4], out length_in)
                            && double.TryParse(items[5], out width_in)
                            && double.TryParse(items[6], out height_in))
                        {
                            newcarton.Length_IN = length_in;
                            newcarton.Width_IN = width_in;
                            newcarton.Height_IN = height_in;
                        }
                        else
                        {
                            newcarton.Length_IN = CentimetreToInch(lenght_cm);
                            newcarton.Width_IN = CentimetreToInch(width_cm);
                            newcarton.Height_IN = CentimetreToInch(height_cm);
                        }
                    }
                    else if (double.TryParse(items[4], out length_in)
                        && double.TryParse(items[5], out width_in)
                        && double.TryParse(items[6], out height_in))
                    {
                        newcarton.Length_IN = length_in;
                        newcarton.Width_IN = width_in;
                        newcarton.Height_IN = height_in;
                        if (double.TryParse(items[1], out lenght_cm)
                            && double.TryParse(items[2], out width_cm)
                            && double.TryParse(items[3], out height_cm))
                        {
                            newcarton.Length_CM = InchToCentimetre(length_in);
                            newcarton.Width_CM = InchToCentimetre(width_in);
                            newcarton.Height_CM = InchToCentimetre(height_in);
                        }
                    }
                    if (!string.IsNullOrEmpty(items[7]))
                    {
                        bool active;
                        if (Boolean.TryParse(items[7], out active))
                        {
                            newcarton.Active = active;
                        }
                        else
                        {
                            newcarton.Active = true;
                        }
                    }
                    newcartons.Add(newcarton);
                }
                else
                {
                    string errormsg = $"[import new carton] File line {counter} has invalid value for carton size";
                    Logger.Log(Logger.LogLevel.ERROR, errormsg);
                }
            }
            if (!formatok)
            {
                MessageBox.Show("Error Loading Cartons Data." +
                    $"{System.Environment.NewLine}{string.Join(System.Environment.NewLine, formaterror)}",
                    "Error Import Carton File Format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                var (inserted, insert_errormsg) = sql_call.InsertCartons(newcartons);
                if (string.IsNullOrEmpty(insert_errormsg))
                {
                    MessageBox.Show($"Total {inserted} new carton(s) inserted.", "Inserted",
                        MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("New Carton(s) inserted Failure." +
                        $"{System.Environment.NewLine}Error Message: {insert_errormsg}", "Insert Failure",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return (formatok, formaterror, newcartons);
        }

        public (bool, List<string>, List<Carton>) ReadCarton_Excel(string importfile, DataTable carton_table)
        {
            List<string> formaterror = new List<string>();
            List<Carton> newcartons = new List<Carton>();
            bool formatok = true;
            using (var stream = File.Open(importfile, FileMode.Open, FileAccess.Read))
            {
                using (var items = ExcelReaderFactory.CreateReader(stream))
                {
                    int counter = 0;
                    do
                    {
                        while (items.Read())
                        {
                            if (items.Name.ToUpper().Equals("NEW"))
                            {
                                counter += 1;
                                try
                                {
                                    if (counter.Equals(1))
                                    {
                                        // header
                                        var importedheader = new List<string>();
                                        for (int i = 0; i < items.FieldCount; i++)
                                        {
                                            importedheader.Add(items[i].ToString().ToUpper());
                                        }
                                        for (int i = 0; i < carton_table.Columns.Count; i++)
                                        {
                                            if (!importedheader.Contains(carton_table.Columns[i].ColumnName.ToUpper()))
                                            {
                                                formatok = false;
                                                string errormsg = $"Header {items[i].ToString()} is not valid";
                                                Logger.Log(Logger.LogLevel.ERROR, $"[import new carton] {errormsg}");
                                                formaterror.Add(errormsg);
                                            }
                                        }
                                        if (formatok)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        double lenght_cm;
                                        double width_cm;
                                        double height_cm;
                                        double length_in;
                                        double width_in;
                                        double height_in;
                                        if (!string.IsNullOrEmpty(items[0].ToString()) // carton_id
                                            && ((double.TryParse(items[1].ToString(), out lenght_cm)
                                            && double.TryParse(items[2].ToString(), out width_cm)
                                            && double.TryParse(items[3].ToString(), out height_cm))
                                            || (double.TryParse(items[4].ToString(), out length_in)
                                            && double.TryParse(items[5].ToString(), out width_in)
                                            && double.TryParse(items[6].ToString(), out height_in))))
                                        {
                                            Carton newcarton = new Carton();
                                            newcarton.Carton_ID = items[0].ToString().Trim();
                                            if (double.TryParse(items[1].ToString(), out lenght_cm)
                                                && double.TryParse(items[2].ToString(), out width_cm)
                                                && double.TryParse(items[3].ToString(), out height_cm))
                                            {
                                                newcarton.Length_CM = lenght_cm;
                                                newcarton.Width_CM = width_cm;
                                                newcarton.Height_CM = height_cm;
                                                if (double.TryParse(items[4].ToString(), out length_in)
                                                    && double.TryParse(items[5].ToString(), out width_in)
                                                    && double.TryParse(items[6].ToString(), out height_in))
                                                {
                                                    newcarton.Length_IN = length_in;
                                                    newcarton.Width_IN = width_in;
                                                    newcarton.Height_IN = height_in;
                                                }
                                                else
                                                {
                                                    newcarton.Length_IN = CentimetreToInch(lenght_cm);
                                                    newcarton.Width_IN = CentimetreToInch(width_cm);
                                                    newcarton.Height_IN = CentimetreToInch(height_cm);
                                                }
                                            }
                                            else if (double.TryParse(items[4].ToString(), out length_in)
                                                && double.TryParse(items[5].ToString(), out width_in)
                                                && double.TryParse(items[6].ToString(), out height_in))
                                            {
                                                newcarton.Length_IN = length_in;
                                                newcarton.Width_IN = width_in;
                                                newcarton.Height_IN = height_in;
                                                if (double.TryParse(items[1].ToString(), out lenght_cm)
                                                    && double.TryParse(items[2].ToString(), out width_cm)
                                                    && double.TryParse(items[3].ToString(), out height_cm))
                                                {
                                                    newcarton.Length_CM = InchToCentimetre(length_in);
                                                    newcarton.Width_CM = InchToCentimetre(width_in);
                                                    newcarton.Height_CM = InchToCentimetre(height_in);
                                                }
                                            }
                                            if (!string.IsNullOrEmpty(items[7].ToString()))
                                            {
                                                bool active;
                                                if (Boolean.TryParse(items[7].ToString(), out active))
                                                {
                                                    newcarton.Active = active;
                                                }
                                                else
                                                {
                                                    newcarton.Active = true;
                                                }
                                            }
                                            newcartons.Add(newcarton);
                                        }
                                        else
                                        {
                                            string errormsg = $"[import new carton] File line {counter} has invalid value for carton size";
                                            Logger.Log(Logger.LogLevel.ERROR, errormsg);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(Logger.LogLevel.ERROR, $"ReadCarton_Excel Error: {ex.Message} Line: {counter}");
                                }
                            }
                        }
                    } while (items.NextResult());
                }
            }
            return (formatok, formaterror, newcartons);
        }

        private (int, string) InsertCartons(bool formatok, List<string> formaterror, List<Carton> newcartons)
        {
            int inserted = 0;
            string insert_errormsg = string.Empty;
            if (!formatok)
            {
                MessageBox.Show("Error Loading Carton Data." +
                    $"{System.Environment.NewLine}{string.Join(System.Environment.NewLine, formaterror)}",
                    "Error Import Carton File Format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                (inserted, insert_errormsg) = sql_call.InsertCartons(newcartons);
                if (string.IsNullOrEmpty(insert_errormsg))
                {
                    MessageBox.Show($"Total {inserted} new carton(s) inserted.", "Inserted",
                        MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("New Carton(s) inserted Failure." +
                        $"{System.Environment.NewLine}Error Message: {insert_errormsg}", "Insert Failure",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return (inserted, insert_errormsg);
        }
        #endregion

        #region Product
        public bool ReadProduct(string importfile, DataTable product_table)
        {
            if (!IsFileInUseGeneric(importfile))
            {
                bool formatok = false;
                List<ImportReport> formaterror = new List<ImportReport>();
                List<Product> newproducts = new List<Product>();
                List<Product> updateproducts = new List<Product>();
                List<ImportReport> importreports_insert = new List<ImportReport>();
                List<ImportReport> importreports_update = new List<ImportReport>();
                if (importfile.EndsWith(".csv"))
                {
                    (formatok, formaterror, newproducts, updateproducts) = ReadProduct_CSV(importfile, product_table);
                }
                else if (importfile.EndsWith(".xlsx"))
                {
                    (formatok, formaterror, newproducts, updateproducts) = ReadProduct_Excel(importfile, product_table);
                }
                DialogResult importreport = DialogResult.None;
                if (!newproducts.Count().Equals(0) || !updateproducts.Count().Equals(0))
                {
                    if (!newproducts.Count().Equals(0))
                    {
                        importreports_insert = sql_call.InsertProducts(newproducts);
                    }
                    if (!updateproducts.Count().Equals(0))
                    {
                        importreports_update = sql_call.UpdateProducts(updateproducts);
                    }
                    if (formatok 
                        && importreports_insert.All(i => i.message.All(m => m.Equals("SUCCESS"))) 
                        && importreports_update.All(i => i.message.All(m => m.Equals("SUCCESS"))))
                    {
                        importreport = MessageBox.Show("Import File Completed and Successful." + System.Environment.NewLine +
                            $"{System.Environment.NewLine}Total Rows: {(newproducts.Count() + updateproducts.Count()).ToString()}" +
                            $"{System.Environment.NewLine}Inserted: {importreports_insert.Count().ToString()}" +
                            $"{System.Environment.NewLine}Updated: {importreports_update.Count().ToString()}" +
                            $"{System.Environment.NewLine}{System.Environment.NewLine}" +
                            $"Do you want to download import report?",
                            "Import Completed",
                            MessageBoxButtons.YesNo);
                    }
                    else
                    {
                        int inserted = importreports_insert.Where(i => i.message.All(m => m.Equals("SUCCESS"))).Count();
                        int updated = importreports_update.Where(i => i.message.All(m => m.Equals("SUCCESS"))).Count();
                        importreport = MessageBox.Show("Import File Completed with Warning." + System.Environment.NewLine +
                            $"{System.Environment.NewLine}Total Rows: {(newproducts.Count() + updateproducts.Count()).ToString()}" +
                            $"{System.Environment.NewLine}Inserted: {inserted.ToString()}" +
                            $"{System.Environment.NewLine}Updated: {updated.ToString()}" +
                            $"{System.Environment.NewLine}{System.Environment.NewLine}" +
                            $"Do you want to download import report?",
                            "Import Completed With Error",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    importreport = MessageBox.Show("Import File Completed with Errors."+
                        $"{System.Environment.NewLine}{System.Environment.NewLine}" +
                        $"Do you want to download import report?",
                        "Import Completed With Error",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                if (importreport.Equals(DialogResult.Yes))
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
                    csv.AppendLine("SKU,Command,Message");
                    foreach (var report in formaterror)
                    {
                        string row = $"{report.SKU},{report.Command},\"{string.Join(";", report.message.Select(m => m.Replace("\"", "\"\"")))}\"";
                        csv.AppendLine(row);
                    }
                    foreach (var report in importreports_insert)
                    {
                        string row = $"{report.SKU},{report.Command},\"{string.Join(";", report.message.Select(m => m.Replace("\"", "\"\"")))}\"";
                        csv.AppendLine(row);
                    }
                    foreach (var report in importreports_update)
                    {
                        string row = $"{report.SKU},{report.Command},\"{string.Join(";", report.message.Select(m => m.Replace("\"", "\"\"")))}\"";
                        csv.AppendLine(row);
                    }
                    string savefilename = downloadsPath + @"\" + $"Import_Report_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
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
                    Logger.Log(Logger.LogLevel.INFO, $"Import Report saved: {savefilename}");
                }
                return true;
            }
            else
            {
                MessageBox.Show("File In USED." +
                    $"{System.Environment.NewLine}Please close the import file before proceed import.", 
                    "Insert Failure",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool IsFileInUseGeneric(string filename)
        {
            try
            {
                using (var stream = File.Open(filename, FileMode.Open))
                {
                }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        private (bool, List<ImportReport>, List<Product>, List<Product>) ReadProduct_CSV(string importfile, DataTable product_table)
        {
            var readfile = File.ReadAllLines(importfile);
            var headers = readfile.First().ToUpper().Split(',').Select(h => h.Replace("_", " "));
            bool formatok = true;
            ProductTemplate headerindexs = new ProductTemplate();
            List<ImportReport> formaterrors = new List<ImportReport>();
            List<Product> newproducts = new List<Product>();
            List<Product> updateproducts = new List<Product>();
            List<string> headererrors = new List<string>();
            (formatok, headerindexs, headererrors) = ValidateHeader(headers.ToList(), product_table);
            if (formatok)
            {
                int counter = 0;
                foreach (var row in readfile)
                {
                    counter += 1;
                    if (counter.Equals(1))
                    {
                        continue;
                    }
                    var items = row.Split(',');
                    Product newprod = new Product();
                    bool formatok_row = false;
                    string command = string.Empty;
                    ImportReport formaterror_row = new ImportReport();
                    (formatok_row, newprod, command, formaterror_row) = ReadRow(counter, items.ToList(), headerindexs);
                    if (formatok_row)
                    {
                        if (newprod != null)
                        {
                            if (command.ToUpper().Equals("NEW"))
                            {
                                newproducts.Add(newprod);
                            }
                            else if (command.ToUpper().Equals("UPDATE"))
                            {
                                updateproducts.Add(newprod);
                            }
                        }
                    }
                    else
                    {
                        formatok = formatok_row;
                        formaterrors.Add(formaterror_row);
                    }
                }
            }
            else
            {
                ImportReport header = new ImportReport();
                header.message = headererrors;
                formaterrors.Add(header);
            }
            return (formatok, formaterrors, newproducts, updateproducts);
        }

        private (bool, List<ImportReport>, List<Product>, List<Product>) ReadProduct_Excel(string importfile, DataTable product_table)
        {
            List<ImportReport> formaterrors = new List<ImportReport>();
            List<Product> newproducts = new List<Product>();
            List<Product> updateproducts = new List<Product>();
            bool formatok = true;
            ProductTemplate headerindexs = new ProductTemplate();
            using (var stream = File.Open(importfile, FileMode.Open, FileAccess.Read))
            {
                using (var items = ExcelReaderFactory.CreateReader(stream))
                {
                    int counter = 0;
                    do
                    {
                        while (items.Read())
                        {
                            if (items.Name.ToUpper().Equals("NEW"))
                            {
                                counter += 1;
                                try
                                {
                                    if (counter.Equals(1))
                                    {
                                        // header
                                        var importedheader = new List<string>();
                                        for (int i = 0; i < items.FieldCount; i++)
                                        {
                                            importedheader.Add(items[i].ToString().ToUpper().Replace("_", " "));
                                        }
                                        bool formatok_header = false;
                                        List<string> headererrors = new List<string>();
                                        (formatok_header, headerindexs, headererrors) = ValidateHeader(importedheader, product_table);
                                        if (formatok_header)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            formatok = formatok_header;
                                            ImportReport header = new ImportReport();
                                            header.message = headererrors;
                                            formaterrors.Add(header);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        List<string> row = new List<string>();
                                        for (int i = 0; i < items.FieldCount; i++)
                                        {
                                            row.Add(items[i] != null ? items[i].ToString() : string.Empty);
                                        }
                                        Product newprod = new Product();
                                        bool formatok_row = false;
                                        string command = string.Empty;
                                        ImportReport formaterror_row = new ImportReport();
                                        (formatok_row, newprod, command, formaterror_row) = ReadRow(counter, row, headerindexs);
                                        if (formatok_row)
                                        {
                                            if (newprod != null)
                                            {
                                                if (command.ToUpper().Equals("NEW"))
                                                {
                                                    newproducts.Add(newprod);
                                                }
                                                else if (command.ToUpper().Equals("UPDATE"))
                                                {
                                                    updateproducts.Add(newprod);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            formatok = formatok_row;
                                            formaterrors.Add(formaterror_row);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(Logger.LogLevel.ERROR, $"ReadProduct_Excel Error: {ex.Message} Line: {counter}");
                                }
                            }
                        }
                    } while (items.NextResult());
                }
            }
            return (formatok, formaterrors, newproducts, updateproducts);
        }

        private (bool, ProductTemplate, List<string>) ValidateHeader(List<string> headers, DataTable product_table)
        {
            bool formatok = true;
            ProductTemplate producttemplate = new ProductTemplate();
            List<string> formaterror = new List<string>();
            producttemplate.SetIndex("COMMAND", headers.IndexOf("COMMAND"));
            for (int i = 0; i < product_table.Columns.Count; i++)
            {
                if (product_table.Columns[i].ColumnName.ToUpper().Equals("DEFAULT CARTON")
                    || product_table.Columns[i].ColumnName.ToUpper().Contains("UNITOFMEASURE"))
                {
                    continue;
                }
                if (!headers.Contains(product_table.Columns[i].ColumnName.ToUpper()))
                {
                    if (!product_table.Columns[i].ColumnName.ToUpper().Contains("UPC")
                        && !product_table.Columns[i].ColumnName.ToUpper().Contains("PRODUCT NAME") 
                        && !product_table.Columns[i].ColumnName.ToUpper().Contains("SHOE TYPE"))
                    {
                        formatok = false;
                        string errormsg = $"Header {product_table.Columns[i].ColumnName.ToUpper()} is required";
                        Logger.Log(Logger.LogLevel.ERROR, $"[import new product] {errormsg}");
                        formaterror.Add(errormsg);
                    }
                }
                else
                {
                    producttemplate.SetIndex(product_table.Columns[i].ColumnName, headers.IndexOf(product_table.Columns[i].ColumnName.ToUpper()));
                }
            }
            return (formatok, producttemplate, formaterror);
        }

        private (bool, Product, string, ImportReport) ReadRow(int counter, List<string> items, ProductTemplate headerindexs)
        {
            bool formatok = true;
            Product newprod = new Product();
            ImportReport importformat = new ImportReport();
            string prodcommand = string.Empty;
            double package_length;
            double package_width;
            double package_height;
            double package_weight;
            if (!string.IsNullOrEmpty(items[headerindexs.sku.index]))
            {
                string sku = items[headerindexs.sku.index].Trim();
                importformat.SKU = sku;
                if (items[headerindexs.sku.index].Trim().Length > 50)
                {
                    formatok = false;
                    string error = $"The Length of SKU cannot longer than 50 characters. {sku} is not accepted.";
                    importformat.message.Add(error);
                    Logger.Log(Logger.LogLevel.ERROR, error);
                }
                else
                {
                    newprod.SKU = sku.ToUpper();
                }
            }
            else
            {
                formatok = false;
                string error = "SKU cannot be empty";
                importformat.message.Add(error);
                Logger.Log(Logger.LogLevel.ERROR, error);
            }
            if (!string.IsNullOrEmpty(items[headerindexs.command.index]))
            {
                string command = items[headerindexs.command.index].Trim();
                if (!headerindexs.Validate(headerindexs.command.header, command, out prodcommand))
                {
                    formatok = false;
                    string error = $"Command column only accept NEW and UPDATE value. {command} is not accepted.";
                    importformat.message.Add(error);
                    Logger.Log(Logger.LogLevel.ERROR, error);
                }
                importformat.Command = command;
            }
            else
            {
                formatok = false;
                string error = "Command cannot be empty";
                importformat.message.Add(error);
                Logger.Log(Logger.LogLevel.ERROR, error);
            }
            if (headerindexs.shoe_type != null)
            {
                string shoetype = items[headerindexs.shoe_type.index].Trim();
                string updatedshoetype;
                if (!string.IsNullOrEmpty(shoetype))
                {
                    if (!headerindexs.Validate(headerindexs.shoe_type.header, shoetype, out updatedshoetype))
                    {
                        formatok = false;
                        string error = $"Shoe Type column only accept MensWomens and Childrens value. {shoetype} is not accepted.";
                        importformat.message.Add(error);
                        Logger.Log(Logger.LogLevel.ERROR, error);
                    }
                    else
                    {
                        newprod.Shoe_Type = updatedshoetype;
                    }
                }
                else
                {
                    newprod.Shoe_Type = "MensWomens";
                }
            }
            else
            {
                newprod.Shoe_Type = "MensWomens";
            }
            if (!string.IsNullOrEmpty(items[headerindexs.package_length.index]))
            {
                if (double.TryParse(items[headerindexs.package_length.index], out package_length))
                {
                    if (package_length <= 0 || package_length > 100)
                    {
                        formatok = false;
                        string error = "Package Length should be 0 - 100 IN";
                        importformat.message.Add(error);
                        Logger.Log(Logger.LogLevel.ERROR, error);
                    }
                    newprod.Package_Length = Math.Round(package_length, 2);
                }
                else
                {
                    formatok = false;
                    string error = "Invalid value for Package Length";
                    importformat.message.Add(error);
                    Logger.Log(Logger.LogLevel.ERROR, error);
                }
            }
            else
            {
                formatok = false;
                string error = "Package Length cannot be empty";
                importformat.message.Add(error);
                Logger.Log(Logger.LogLevel.ERROR, error);
            }
            if (!string.IsNullOrEmpty(items[headerindexs.package_width.index]))
            {
                if (double.TryParse(items[headerindexs.package_width.index], out package_width))
                {
                    if (package_width <= 0 || package_width > 100)
                    {
                        formatok = false;
                        string error = "Package Width should be 0 - 100 IN";
                        importformat.message.Add(error);
                        Logger.Log(Logger.LogLevel.ERROR, error);
                    }
                    newprod.Package_Width = Math.Round(package_width, 2);
                }
                else
                {
                    formatok = false;
                    string error = "Invalid value for Package Width";
                    importformat.message.Add(error);
                    Logger.Log(Logger.LogLevel.ERROR, error);
                }
            }
            else
            {
                formatok = false;
                string error = "Package Width cannot be empty";
                importformat.message.Add(error);
                Logger.Log(Logger.LogLevel.ERROR, error);
            }
            if (!string.IsNullOrEmpty(items[headerindexs.package_height.index]))
            {
                if (double.TryParse(items[headerindexs.package_height.index], out package_height))
                {
                    if (package_height <= 0 || package_height > 100)
                    {
                        formatok = false;
                        string error = "Package Height should be 0 - 100 IN";
                        importformat.message.Add(error);
                        Logger.Log(Logger.LogLevel.ERROR, error);
                    }
                    newprod.Package_Height = Math.Round(package_height, 2);
                }
                else
                {
                    formatok = false;
                    string error = "Invalid value for Package Height";
                    importformat.message.Add(error);
                    Logger.Log(Logger.LogLevel.ERROR, error);
                }
            }
            else
            {
                formatok = false;
                string error = "Package Height cannot be empty";
                importformat.message.Add(error);
                Logger.Log(Logger.LogLevel.ERROR, error);
            }
            if (!string.IsNullOrEmpty(items[headerindexs.package_weight.index]))
            {
                if (double.TryParse(items[headerindexs.package_weight.index], out package_weight))
                {
                    if (package_weight <= 0 || package_weight > 100)
                    {
                        formatok = false;
                        string error = "Package Weight should be 0 - 100 LB";
                        importformat.message.Add(error);
                        Logger.Log(Logger.LogLevel.ERROR, error);
                    }
                    newprod.Package_Weight = Math.Round(package_weight, 2);
                }
                else
                {
                    formatok = false;
                    string error = "Invalid value for Package Weight";
                    importformat.message.Add(error);
                    Logger.Log(Logger.LogLevel.ERROR, error);
                }
            }
            else
            {
                formatok = false;
                string error = "Package Weight cannot be empty";
                importformat.message.Add(error);
                Logger.Log(Logger.LogLevel.ERROR, error);
            }
            if (headerindexs.upc != null)
            {
                if (!string.IsNullOrEmpty(items[headerindexs.upc.index].ToString().Trim()))
                {
                    string upc = items[headerindexs.upc.index].ToString().Trim();
                    if (Regex.IsMatch(upc, @"^\d{11,20}$"))
                    {
                        newprod.UPC = upc;
                    }
                    else
                    {
                        formatok = false;
                        string error = $"Inputed Product UPC {upc} is invalid. Must be 11 to 20 numeric characters.";
                        importformat.message.Add(error);
                        Logger.Log(Logger.LogLevel.ERROR, error);
                    }
                }
            }
            if (headerindexs.product_name != null)
            {
                if (!string.IsNullOrEmpty(items[headerindexs.product_name.index].ToString().Trim()))
                {
                    string productname = items[headerindexs.product_name.index].Trim();
                    if (items[headerindexs.product_name.index].Trim().Length > 200)
                    {
                        formatok = false;
                        string error = $"The Length of Product Name cannot longer than 200 characters. {productname} is not accepted.";
                        importformat.message.Add(error);
                        Logger.Log(Logger.LogLevel.ERROR, error);
                    }
                    else
                    {
                        newprod.Product_Name = productname;
                    }
                }
            }
            return (formatok, newprod, prodcommand, importformat);
        }
        #endregion
    }
}
