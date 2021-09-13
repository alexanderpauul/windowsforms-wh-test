using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WinCSVTest.Models;

namespace WinCSVTest.Services
{
    public class DataService
    {
        public static DataTable RemoveBlankColumn(DataTable dt)
        {
            try
            {
                dt = dt.Rows
                    .Cast<DataRow>()
                    .Where(row => !row.ItemArray.All(f => f is DBNull ||
                           string.IsNullOrEmpty(f as string ?? f.ToString())))
                    .CopyToDataTable();

                return dt;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return dt;
            }
        }

        public static DataTable ConvertCsvToDataTable(string path)
        {
            try
            {
                string[] rows = File.ReadAllLines(path);     // Reading all file lines                    
                DataTable dtData = new DataTable();

                if (rows.Length > 0)
                {
                    foreach (string columnName in rows[0].Split(','))
                    {
                        _ = dtData.Columns.Add(columnName);  // Adding column from file.
                    }
                }

                // start at 1 to avoid file header
                for (int item = 1; item < rows.Length; item++)
                {
                    string[] row = rows[item].Split(',');    // Line values
                    DataRow dr = dtData.NewRow();
                    dr.ItemArray = row;
                    dtData.Rows.Add(dr);
                }


                //dtData = dtData.Rows
                // .Cast<DataRow>()
                // .Where(row => !row.ItemArray.All(f => f is DBNull ||
                //                  string.IsNullOrEmpty(f as string ?? f.ToString())))
                // .CopyToDataTable();

                dtData = RemoveBlankColumn(dtData);

                return dtData;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsNumericOrDate(string value)
        {
            bool isValid;
            try
            {
                // Regular expression to validate values like numbers, decimals and dates.            
                string _patter = @"(^[0-9]+$)|(^[1-9]+\.[0-9]*$)|(^[0-9]{4}-[0-9]{2}-[0-9]{2}$)";
                isValid = (Regex.IsMatch(value, _patter));
            }
            catch
            {
                return false;
            }

            return isValid;
        }

        public static string RewriteValue(string value, string replece, string replacement)
        {
            string rewrite;
            try
            {

                rewrite = Regex.Replace(value, replece, replacement, RegexOptions.IgnoreCase);
            }
            catch
            {
                return string.Empty;
            }

            return rewrite;
        }

        public static List<WHClassification> GetClassifications()
        {
            DataTable dtClassification = ConvertCsvToDataTable(ConfigurationManager.AppSettings["ClassificationPath"]);

            List<WHClassification> Classifications = new List<WHClassification>();

            //foreach (DataRow row in dtClassification.Rows)
            //{
            //    Classifications.Add(new WHClassification
            //    {
            //        Id = Convert.ToInt32(row["Id"]),
            //        Name = row["name"].ToString()
            //    });
            //}

            Classifications = (from DataRow item in dtClassification.Rows
                               select new WHClassification
                               {
                                   Id = Convert.ToInt32(item["Id"]),
                                   Name = Convert.ToString(item["Name"])
                               }).ToList();

            return Classifications;
        }

        public static bool SaveChangeCSV(DataTable data, string path)
        {
            try
            {
                data = RemoveBlankColumn(data);

                //checked for the datatable dtCSV not empty
                if (data != null && data.Rows.Count > 0)
                {
                    // create object for the StringBuilder class
                    StringBuilder sb = new StringBuilder();

                    // Get name of columns from datatable and assigned to the string array
                    string[] columnNames = data.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();

                    // Create comma sprated column name based on the items contains string array columnNames
                    sb.AppendLine(string.Join(CultureInfo.CurrentCulture.TextInfo.ListSeparator, columnNames));

                    // Fatch rows from datatable and append values as comma saprated to the object of StringBuilder class 
                    foreach (DataRow row in data.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("", field.ToString(), ""));
                            sb.AppendLine(string.Join(CultureInfo.CurrentCulture.TextInfo.ListSeparator, fields));
                        }
                    }

                    // save the file
                    File.WriteAllText(path, sb.ToString());
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
