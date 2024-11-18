using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewDimension_APP
{
    internal class SQLQuery
    {
        private static string db_connection = ConfigurationManager.ConnectionStrings["DBCONNECTION"].ConnectionString;
        private static string tb_productdimension = ConfigurationManager.AppSettings["TB_PRODUCTDIMENSION"];
        private static string tb_cartondimension = ConfigurationManager.AppSettings["TB_CARTONDIMENSION"];
        private static string tb_holiday = ConfigurationManager.AppSettings["TB_HOLIDAY"];

        #region Carton
        public (List<Carton>, DataTable, string) GetCartons(string sql = null)
        {
            List<Carton> ls_carton = new List<Carton>();
            DataTable carton_table = new DataTable();
            string error_msg = string.Empty;
            try
            {
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    if (string.IsNullOrEmpty(sql))
                    {
                        sql = $"select * from {tb_cartondimension}";
                    }
                    //string sql = $"select * from {tb_cartondimension}";
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Carton carton = new Carton();
                                carton.Carton_ID = reader[0].ToString().Trim();
                                carton.Length_CM = Convert.ToDouble(reader[1].ToString().Trim());
                                carton.Width_CM = Convert.ToDouble(reader[2].ToString().Trim());
                                carton.Height_CM = Convert.ToDouble(reader[3].ToString().Trim());
                                carton.Length_IN = Convert.ToDouble(reader[4].ToString().Trim());
                                carton.Width_IN = Convert.ToDouble(reader[5].ToString().Trim());
                                carton.Height_IN = Convert.ToDouble(reader[6].ToString().Trim());
                                carton.Active = Convert.ToBoolean(reader[7].ToString().Trim());
                                ls_carton.Add(carton);
                            }
                        }
                    }
                    using (SqlDataAdapter adp = new SqlDataAdapter(sql, cnn))
                    {
                        adp.Fill(carton_table);
                    }
                }
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - GetCartons Error: {ex.Message}");
            }
            return (ls_carton, carton_table, error_msg);
        }

        public (bool, string) UpdateCarton(Carton updatecarton)
        {
            bool issuccess = false;
            string error_msg = string.Empty;
            try
            {
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    string isactive = updatecarton.Active ? "1" : "0";
                    string sql = $"update {tb_cartondimension} set Active = '{isactive}', " +
                        $"Length_CM = '{updatecarton.Length_CM}', Width_CM = '{updatecarton.Width_CM}', " +
                        $"Height_CM = '{updatecarton.Height_CM}', " +
                        $"Length_IN = '{updatecarton.Length_IN}', Width_IN = '{updatecarton.Width_IN}', " +
                        $"Height_IN = '{updatecarton.Height_IN}' " +
                        $"where Carton_ID = '{updatecarton.Carton_ID}'";
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        if (cmd.ExecuteNonQuery().Equals(1))
                        {
                            issuccess = true;
                            Logger.Log(Logger.LogLevel.INFO, $"[UPDATE] Carton ID : {updatecarton.Carton_ID} updated");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - UpdateCarton Error: {ex.Message}");
            }
            return (issuccess, error_msg);
        }

        public (bool, string) InsertCarton(Carton newcarton)
        {
            bool issuccess = false;
            string error_msg = string.Empty;
            try
            {
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    string sql = $"insert into {tb_cartondimension} " +
                        $"(Carton_ID,Length_CM,Width_CM,Height_CM,Length_IN,Width_IN,Height_IN,Active) select " +
                        $"'{newcarton.Carton_ID}','{newcarton.Length_CM}','{newcarton.Width_CM}','{newcarton.Height_CM}'," +
                        $"'{newcarton.Length_IN}','{newcarton.Width_IN}','{newcarton.Height_IN}', " +
                        $"'1' " +
                        $"where not exists (select Carton_ID from {tb_cartondimension} where Carton_ID = '{newcarton.Carton_ID}')";
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        if (cmd.ExecuteNonQuery().Equals(1))
                        {
                            issuccess = true;
                            Logger.Log(Logger.LogLevel.INFO, $"[NEW] Carton ID : {newcarton.Carton_ID} inserted");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - InsertCarton Error: {ex.Message}");
            }
            return (issuccess, error_msg);
        }

        public (int, string) InsertCartons(List<Carton> newcartons)
        {
            int counter = 0;
            string error_msg = string.Empty;
            try
            {
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    foreach (var newcarton in newcartons)
                    {
                        string sql = $"insert into {tb_cartondimension} " +
                            $"(Carton_ID,Length_CM,Width_CM,Height_CM,Length_IN,Width_IN,Height_IN,Active) select " +
                            $"'{newcarton.Carton_ID}','{newcarton.Length_CM}','{newcarton.Width_CM}','{newcarton.Height_CM}'," +
                            $"'{newcarton.Length_IN}','{newcarton.Width_CM}','{newcarton.Height_IN}', " +
                            $"'1' " +
                            $"where not exists (select Carton_ID from {tb_cartondimension} where Carton_ID = '{newcarton.Carton_ID}')";
                        using (SqlCommand cmd = new SqlCommand(sql, cnn))
                        {
                            if (cmd.ExecuteNonQuery().Equals(1))
                            {
                                counter += 1;
                                Logger.Log(Logger.LogLevel.INFO, $"[NEW IMPORT] Carton ID : {newcarton.Carton_ID} inserted");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - InsertCartons Error: {ex.Message}");
            }
            return (counter, error_msg);
        }

        private string GetDefaultCarton(List<Carton> ls_carton, Product prod)
        {
            string default_cartonid = "NULL";
            try
            {
                List<double> ls_dim = new List<double>() { prod.Package_Length, prod.Package_Width, prod.Package_Height };
                double length = ls_dim.OrderByDescending(d => d).First();
                double width = ls_dim.OrderByDescending(d => d).ToList()[1];
                foreach (var carton in ls_carton)
                {
                    if ((carton.Length_IN >= length && carton.Width_IN >= width)
                        || (carton.Width_IN >= length && carton.Length_IN >= width))
                    {
                        default_cartonid = "'" + carton.Carton_ID + "'";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - GetDetailCarton Error: {ex.Message}");
            }
            return default_cartonid;
        }

        public void RefreshDefaultCarton()
        {
            try
            {
                var (ls_carton, carton_table, error_msg_getcartons) = GetCartons($"select * from {tb_cartondimension} where Active = '1'");
                ls_carton = ls_carton.OrderBy(c => c.Length_IN).ThenBy(c => c.Width_IN).ToList();
                var (ls_product, product_table, error_msg_getproducts) = GetProducts();
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    foreach (var prod in ls_product)
                    {
                        string default_cartonid = GetDefaultCarton(ls_carton, prod);
                        string sql = $"update {tb_productdimension} set " +
                            $"Default_Carton = {default_cartonid} " +
                            $"where SKU = '{prod.SKU}'";
                        using (SqlCommand cmd = new SqlCommand(sql, cnn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - RefreshDefaultCarton Error: {ex.Message}");
            }
        }
        #endregion

        #region Product
        public (List<Product>, DataTable, string) GetProducts()
        {
            List<Product> ls_products = new List<Product>();
            DataTable product_table = new DataTable();
            string error_msg = string.Empty;
            try
            {
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    string sql = $"select * from {tb_productdimension}";
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product prod = new Product();
                                prod.Shoe_Type = reader[0].ToString().Trim();
                                prod.SKU = reader[1].ToString().Trim();
                                prod.UPC = reader[2].ToString().Trim();
                                prod.Product_Name = reader[3].ToString().Trim();
                                prod.Package_Length = string.IsNullOrEmpty(reader[8].ToString()) ? 0 : Math.Round(Convert.ToDouble(reader[8].ToString().Trim()), 2);
                                prod.Package_Width = string.IsNullOrEmpty(reader[9].ToString()) ? 0 : Math.Round(Convert.ToDouble(reader[9].ToString().Trim()), 2);
                                prod.Package_Height = string.IsNullOrEmpty(reader[10].ToString()) ? 0 : Math.Round(Convert.ToDouble(reader[10].ToString().Trim()), 2);
                                prod.Package_Length_UnitOfMeasure = reader[11].ToString().Trim();
                                prod.Package_Weight = string.IsNullOrEmpty(reader[11].ToString()) ? 0 : Math.Round(Convert.ToDouble(reader[12].ToString().Trim()), 2);
                                prod.Weight_UnitOfMeasure = reader[13].ToString().Trim();
                                prod.Default_Carton = reader[14].ToString().Trim();
                                ls_products.Add(prod);
                            }
                        }
                    }
                    //using (SqlDataAdapter adp = new SqlDataAdapter(sql, cnn))
                    //{
                    //    adp.Fill(product_table);
                    //}
                    PropertyInfo[] Props = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo prop in Props)
                    {
                        //Setting column names as Property names
                        product_table.Columns.Add(prop.Name.Replace("_", " "));
                    }
                    foreach (var item in ls_products)
                    {
                        var values = new object[Props.Length];
                        for (int i = 0; i < Props.Length; i++)
                        {
                            //inserting property values to datatable rows
                            values[i] = Props[i].GetValue(item, null);
                        }
                        product_table.Rows.Add(values);
                    }
                }
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - GetProducts Error: {ex.Message}");
            }
            return (ls_products, product_table, error_msg);
        }

        public List<ImportReport> InsertProducts(List<Product> newproducts)
        {
            List<ImportReport> importreport = new List<ImportReport>();
            try
            {
                var (ls_carton, carton_table, error_msg_getcartons) = GetCartons($"select * from {tb_cartondimension} where Active = '1'");
                ls_carton = ls_carton.OrderBy(c => c.Length_IN).ThenBy(c => c.Width_IN).ToList();
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    foreach (var newproduct in newproducts)
                    {
                        try
                        {
                            string default_cartonid = GetDefaultCarton(ls_carton, newproduct);
                            string upc = "NULL";
                            string productname = "NULL";
                            if (!string.IsNullOrEmpty(newproduct.UPC))
                            {
                                upc = "'" + newproduct.UPC + "'";
                            }
                            if (!string.IsNullOrEmpty(newproduct.Product_Name))
                            {
                                productname = "'" + newproduct.Product_Name + "'";
                            }
                            string sql = $"insert into {tb_productdimension} " +
                                $"(Shoe_Type,SKU,UPC,Product_Name," +
                                $"Package_Length,Package_Width,Package_Height,Package_Length_UnitOfMeasure," +
                                $"Package_Weight,Weight_UnitOfMeasure,Default_Carton) select " +
                                $"'{newproduct.Shoe_Type}','{newproduct.SKU}',{upc},{productname}," +
                                $"'{newproduct.Package_Length}','{newproduct.Package_Width}','{newproduct.Package_Height}','IN', " +
                                $"'{newproduct.Package_Weight}','LB',{default_cartonid} " +
                                $"where not exists (select SKU from {tb_productdimension} where SKU = '{newproduct.SKU}')";
                            using (SqlCommand cmd = new SqlCommand(sql, cnn))
                            {
                                if (cmd.ExecuteNonQuery().Equals(1))
                                {
                                    ImportReport item = new ImportReport();
                                    item.SKU = newproduct.SKU;
                                    item.message.Add("SUCCESS");
                                    importreport.Add(item);
                                    Logger.Log(Logger.LogLevel.INFO, $"[NEW IMPORT] Product SKU : {newproduct.SKU} inserted");
                                }
                                else
                                {
                                    ImportReport item = new ImportReport();
                                    item.SKU = newproduct.SKU;
                                    item.message.Add("ERROR. SKU existed");
                                    importreport.Add(item);
                                    Logger.Log(Logger.LogLevel.ERROR, $"[NEW IMPORT] Product SKU : {newproduct.SKU} existed");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ImportReport item = new ImportReport();
                            item.SKU = newproduct.SKU;
                            item.message.Add($"ERROR. {ex.Message}");
                            importreport.Add(item);
                            Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - InsertProducts SKU: {newproduct.SKU} Error: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - InsertProducts Error: {ex.Message}");
            }
            return importreport;
        }

        public List<ImportReport> UpdateProducts(List<Product> updateproducts)
        {
            List<ImportReport> importreport = new List<ImportReport>();
            try
            {
                var (ls_carton, carton_table, error_msg_getcartons) = GetCartons($"select * from {tb_cartondimension} where Active = '1'");
                ls_carton = ls_carton.OrderBy(c => c.Length_IN).ThenBy(c => c.Width_IN).ToList();
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    foreach (var updateproduct in updateproducts)
                    {
                        try
                        {
                            string default_cartonid = GetDefaultCarton(ls_carton, updateproduct);
                            string sql = $"update {tb_productdimension} set " +
                                $"Package_Length = '{updateproduct.Package_Length}', " +
                                $"Package_Width = '{updateproduct.Package_Width}', " +
                                $"Package_Height = '{updateproduct.Package_Height}', " +
                                $"Package_Weight = '{updateproduct.Package_Weight}', " +
                                $"Default_Carton = {default_cartonid} " +
                                $"where SKU = '{updateproduct.SKU}'";
                            using (SqlCommand cmd = new SqlCommand(sql, cnn))
                            {
                                if (cmd.ExecuteNonQuery().Equals(1))
                                {
                                    ImportReport item = new ImportReport();
                                    item.SKU = updateproduct.SKU;
                                    item.message.Add("SUCCESS");
                                    importreport.Add(item);
                                    Logger.Log(Logger.LogLevel.INFO, $"[UPDATE IMPORT] Product SKU : {updateproduct.SKU} updated");
                                }
                                else
                                {
                                    ImportReport item = new ImportReport();
                                    item.SKU = updateproduct.SKU;
                                    item.message.Add("ERROR. SKU is not existed");
                                    importreport.Add(item);
                                    Logger.Log(Logger.LogLevel.ERROR, $"[NEW IMPORT] Product SKU : {updateproduct.SKU} existed");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ImportReport item = new ImportReport();
                            item.SKU = updateproduct.SKU;
                            item.message.Add($"ERROR. {ex.Message}");
                            importreport.Add(item);
                            Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - UpdateProducts SKU: {updateproduct.SKU} Error: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - InsertProducts Error: {ex.Message}");
            }
            return importreport;
        }
        #endregion

        #region Holiday
        public (List<DateTime>, string) GetHolidays(int year)
        {
            string error_msg = string.Empty;
            List<DateTime> ls_holiday = new List<DateTime>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    (ls_holiday, error_msg) = GetHolidays(year, cnn);
                }
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - GetHolidays Error: {ex.Message}");
            }
            return (ls_holiday, error_msg);
        }

        public (List<DateTime>, string) AddHoliday(DateTime holiday)
        {
            string error_msg = string.Empty;
            List<DateTime> ls_holiday = new List<DateTime>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    string insert = $"insert into {tb_holiday} (holiday_date) " +
                        $"select '{holiday.ToString("yyyy-MM-dd")}' " +
                        $"where not exists (select * from {tb_holiday} " +
                        $"where holiday_date = '{holiday.ToString("yyyy-MM-dd")}')";
                    using (SqlCommand cmd = new SqlCommand(insert, cnn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    // get current
                    (ls_holiday, error_msg) = GetHolidays(holiday.Year, cnn);
                }
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - AddHoliday Error: {ex.Message}");
            }
            return (ls_holiday, error_msg);
        }

        public (List<DateTime>, string) RemoveHoliday(DateTime holiday)
        {
            string error_msg = string.Empty;
            List<DateTime> ls_holiday = new List<DateTime>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(db_connection))
                {
                    cnn.Open();
                    string insert = $"delete from {tb_holiday} " +
                        $"where holiday_date = '{holiday.ToString("yyyy-MM-dd")}'";
                    using (SqlCommand cmd = new SqlCommand(insert, cnn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    // get current
                    (ls_holiday, error_msg) = GetHolidays(holiday.Year, cnn);
                }
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - RemoveHoliday Error: {ex.Message}");
            }
            return (ls_holiday, error_msg);
        }

        private (List<DateTime>, string) GetHolidays(int year, SqlConnection cnn)
        {
            List<DateTime> ls_holiday = new List<DateTime>();
            string error_msg = string.Empty;
            try
            {
                DateTime picked = new DateTime(year, 1, 1);
                DateTime picked_end = new DateTime(year, 12, 31);
                string sql = $"select * from {tb_holiday} " +
                    $"where holiday_date >= '{picked.ToString("yyyy-MM-dd")}' " +
                    $"and holiday_date <= '{picked_end.ToString("yyyy-MM-dd")}'";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ls_holiday.Add(DateTime.Parse(reader[0].ToString().Trim()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                Logger.Log(Logger.LogLevel.ERROR, $"SQLQuery - GetHolidays Error: {ex.Message}");
            }
            return (ls_holiday, error_msg);
        }
        #endregion
    }
}
