using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDimension_APP
{
    public class Carton
    {
        public string Carton_ID { get; set; }
        public double Length_IN { get; set; }
        public double Width_IN { get; set; }
        public double Height_IN { get; set; }
        public double Length_CM{ get; set; }
        public double Width_CM { get; set; }
        public double Height_CM { get; set; }
        public bool Active { get; set; }
    }

    public class Product
    {
        public string Shoe_Type { get; set; }
        public string SKU { get; set; }
        public string UPC { get; set; }
        public string Product_Name { get; set; }
        public double Package_Length { get; set; }
        public double Package_Width { get; set; }
        public double Package_Height { get; set; }
        public string Package_Length_UnitOfMeasure { get; set; }
        public double Package_Weight { get; set; }
        public string Weight_UnitOfMeasure { get; set; }
        public string Default_Carton { get; set; }
    }

    public class HeaderIndex
    {
        public int index { get; set; }
        public string header { get; set; }
    }

    public class ProductTemplate
    {
        public void SetIndex(string headername, int index)
        {
            if (headername.ToUpper().Equals("SHOE TYPE"))
            {
                shoe_type = new HeaderIndex()
                {
                    header = headername,
                    index = index
                };
            }
            else if (headername.ToUpper().Equals("SKU"))
            {
                sku = new HeaderIndex()
                {
                    header = headername,
                    index = index
                };
            }
            else if (headername.ToUpper().Equals("COMMAND"))
            {
                command = new HeaderIndex()
                {
                    header = headername,
                    index = index
                };
            }
            else if (headername.ToUpper().Equals("UPC"))
            {
                upc = new HeaderIndex()
                {
                    header = headername,
                    index = index
                };
            }
            else if (headername.ToUpper().Equals("PRODUCT NAME"))
            {
                product_name = new HeaderIndex()
                {
                    header = headername,
                    index = index
                };
            }
            else if (headername.ToUpper().Equals("PACKAGE LENGTH"))
            {
                package_length = new HeaderIndex()
                {
                    header = headername,
                    index = index
                };
            }
            else if (headername.ToUpper().Equals("PACKAGE WIDTH"))
            {
                package_width = new HeaderIndex()
                {
                    header = headername,
                    index = index
                };
            }
            else if (headername.ToUpper().Equals("PACKAGE HEIGHT"))
            {
                package_height = new HeaderIndex()
                {
                    header = headername,
                    index = index
                };
            }
            else if (headername.ToUpper().Equals("PACKAGE WEIGHT"))
            {
                package_weight = new HeaderIndex()
                {
                    header = headername,
                    index = index
                };
            }
        }

        public bool Validate(string headername, string value, out string updated)
        {
            bool validated = false;
            updated = string.Empty;
            if (headername.ToUpper().Equals("SHOE TYPE"))
            {
                if (value.ToLower().Equals("menswomens")
                    || value.ToLower().Equals("childrens"))
                {
                    validated = true;
                    if (value.ToLower().Equals("menswomens"))
                    {
                        updated = "MensWomens";
                    }
                    else if (value.ToLower().Equals("childrens"))
                    {
                        updated = "Childrens";
                    }
                }
            }
            else if (headername.ToUpper().Equals("COMMAND"))
            {
                if (value.ToLower().Equals("new")
                    || value.ToLower().Equals("update"))
                {
                    validated = true;
                    if (value.ToLower().Equals("new"))
                    {
                        updated = "NEW";
                    }
                    else if (value.ToLower().Equals("update"))
                    {
                        updated = "UPDATE";
                    }
                }
            }
            return validated;
        }

        public HeaderIndex shoe_type { get; set; }
        public HeaderIndex sku { get; set; }
        public HeaderIndex command { get; set; }
        public HeaderIndex upc { get; set; }
        public HeaderIndex product_name { get; set; }
        public HeaderIndex package_length { get; set; }
        public HeaderIndex package_width { get; set; }
        public HeaderIndex package_height { get; set; }
        public HeaderIndex package_weight { get; set; }
    }

    public class ImportReport
    {
        public ImportReport()
        {
            message = new List<string>();
        }
        public string SKU { get; set; }
        public string Command { get; set; }
        public List<string> message { get; set; }
    }
}
