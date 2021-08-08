using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GenerateJSModelFromSQL
{
    public class clsModelBuilder
    {
        public clsSettings settings { get; set; }
        public clsConnections connection { get; set; }
        public string connectionString { get; set; }
        private SqlConnection con { get; set; }

        List<TableStructure> dbStruct { get; set; }

        public class TableStructure
        {
            public string TableName { get; set; }
            public List<ColumnStructure> Columns { get; set; }
        }
        public class ColumnStructure
        {
            public string ColumnName { get; set; }
            public string ColumnType { get; set; }
            public string ColumnDescription { get; set; }
        }
        private class TableImage
        {
            public String TableName { get; set; }
            public Bitmap TableImg { get; set; }
            public List<ColumnImage> Columns { get; set; }
        }

        private class ColumnImage
        {
            public String ColumnName { get; set; }
            public Bitmap ColumnImg { get; set; }
        }

        public bool ConnectionValid()
        {
            bool valid = false;
            try
            {
                Defaults();

                con.Open();
                con.Close();
                con.Dispose();

                valid = true;
            }
            catch (Exception ex)
            {

            }

            return valid;
        }

        public void BuildModels(clsSettings settingsX, clsConnections connectionX)
        {
            settings = settingsX;
            connection = connectionX;

            Defaults();
            getDBStructure();
            BuildFiles();
        }

        private void Defaults()
        {
            con = new SqlConnection(connectionString);
        }

        public void getDBStructure()
        {
            getTables();
            GetColumns();
        }

        private void getTables()
        {
            DataTable dt = new DataTable();

            string strQuery = @"USE WriteTrack SELECT i.TABLE_NAME TableName
                FROM INFORMATION_SCHEMA.TABLES i
                WHERE i.TABLE_TYPE = 'BASE TABLE'";

            con.Open();

            SqlCommand cmd = new SqlCommand(strQuery, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            con.Close();
            da.Dispose();

            dbStruct = dt.AsEnumerable().Select(x => new TableStructure()
            {
                TableName = (string) x["TableName"],
                Columns = new List<ColumnStructure>()

            }).ToList();

            dt.Dispose();
        }

        private void GetColumns()
        {
            foreach (TableStructure table in dbStruct)
            {
                DataTable dt = new DataTable();

                string strQuery = $@"SELECT c.COLUMN_NAME ColumnName, c.DATA_TYPE + ' ' + CASE WHEN CONVERT(VARCHAR, c.CHARACTER_MAXIMUM_LENGTH) IS NULL THEN '' WHEN CONVERT(VARCHAR, c.CHARACTER_MAXIMUM_LENGTH) IS NOT NULL THEN '(' + CONVERT(VARCHAR, c.CHARACTER_MAXIMUM_LENGTH) + ')' ELSE CONVERT(VARCHAR, c.CHARACTER_MAXIMUM_LENGTH) END ColumnType,
                    ISNULL(p.value, '') ColumnDescription
                    FROM INFORMATION_SCHEMA.COLUMNS c
                    LEFT OUTER JOIN sys.extended_properties p ON p.major_id = OBJECT_ID(c.TABLE_SCHEMA+'.'+c.TABLE_NAME) AND p.minor_id = c.ORDINAL_POSITION AND p.name = 'MS_Description' 
                    WHERE c.TABLE_NAME = '{table.TableName}'";

                con.Open();

                SqlCommand cmd = new SqlCommand(strQuery, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                con.Close();
                da.Dispose();

                table.Columns = dt.AsEnumerable().Select(x => new ColumnStructure()
                {
                    ColumnName = (string)x["ColumnName"],
                    ColumnType = (string)x["ColumnType"],
                    ColumnDescription = (string)x["ColumnDescription"]
                }).ToList();

                dt.Dispose();
            }
        }

        public void BuildFiles()
        {
            string DataModelGenPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string DataModelGenSolutionPath = DataModelGenPath.Split(new string[] { "GenerateJSModelFromEntitySQL" }, StringSplitOptions.None)[0];

            string LastUpdated = "Last Updated: " + DateTime.Now.ToString();

            string WarningMsg = $@"/**
* Do Not Edit
* Generate JS Model From Entity SQL {LastUpdated}
* This file was generated programmatically using GenerateJSModelFromEntitySQL via the Entity Model & Rule Sets
* Do Not Edit
*/" + Environment.NewLine;

            string DataModelString = "";
            DataModelString += "TableName|ColumnName|DataType|ColumnDescription" + Environment.NewLine;
            string jsDataStructure = WarningMsg;

            string Tables = Environment.NewLine + "--Start of Tables--" + Environment.NewLine + Environment.NewLine;

            //Image Building Data
            List<TableImage> tableImages = new List<TableImage>();

            foreach (TableStructure table in dbStruct)
            {
                if (table.TableName == "sysdiagram" || table.TableName == "sysdiagrams")
                {
                    continue;
                }

                //Image Building Data
                TableImage tableImage = new TableImage();
                tableImage.Columns = new List<ColumnImage>();
                tableImage.TableName = table.TableName;

                Tables += table.TableName + Environment.NewLine;

                jsDataStructure += "class cls" + table.TableName + Environment.NewLine;
                jsDataStructure += "{" + Environment.NewLine + "\t" + "constructor()" + Environment.NewLine + "\t" + "{" + Environment.NewLine;

                foreach (ColumnStructure column in table.Columns)
                {
                    DataModelString += table.TableName + "|" + column.ColumnName + "|" + column.ColumnType + "|" + column.ColumnDescription + Environment.NewLine;

                    //Image Building Data
                    ColumnImage columnImage = new ColumnImage();
                    columnImage.ColumnName = column.ColumnName + " " + column.ColumnType;
                    tableImage.Columns.Add(columnImage);

                    jsDataStructure += "\t\tthis." + column.ColumnName;
                    if (column.ColumnType == "boolean")
                    {
                        jsDataStructure += " = " + "false";
                    }
                    else if (column.ColumnType == "string")
                    {
                        jsDataStructure += " = " + "''";
                    }
                    else if (column.ColumnType == "int")
                    {
                        //FileContents += " = " + "0";
                        jsDataStructure += " = " + "null";
                    }
                    else if (column.ColumnType == "datetime")
                    {
                        //FileContents += " = " + "new Date()";
                        jsDataStructure += " = " + "null";
                    }
                    else if (column.ColumnType == "double")
                    {
                        //FileContents += " = " + "new Number(0)";
                        jsDataStructure += " = " + "null";
                    }
                    else if (column.ColumnType == "decimal")
                    {
                        //FileContents += " = " + "new Number(0)";
                        jsDataStructure += " = " + "null";
                    }
                    else if (column.ColumnType == "collections")
                    {
                        //FileContents += "";
                        jsDataStructure += " = " + "null";
                    }
                    else if (column.ColumnType == "datamodels")
                    {
                        //FileContents += "";
                        jsDataStructure += " = " + "null";
                    }
                    else
                    {
                        //FileContents += "";
                        jsDataStructure += " = " + "null";
                    }
                    jsDataStructure += ";";
                    jsDataStructure += Environment.NewLine;
                }

                jsDataStructure += "\t}" + Environment.NewLine;
                jsDataStructure += "}" + Environment.NewLine;

                //Image Building Data
                tableImages.Add(tableImage);
            }

            Tables += Environment.NewLine + "--End of Tables--" + Environment.NewLine + Environment.NewLine;

            DataModelString = WarningMsg + Tables + DataModelString;

            DataModelString += WarningMsg;

            jsDataStructure += WarningMsg;

            System.IO.File.WriteAllText(Path.Combine(connection.ProjectPath, "DataModelInfo" + ".txt"), DataModelString);

            System.IO.File.WriteAllText(Path.Combine(connection.ProjectPath, "clsDataModel" + ".js"), jsDataStructure);

            //Image Building Data
            CreateTableImages(tableImages, DataModelGenSolutionPath);
        }

        private void CreateTableImages(List<TableImage> tableImages, String path)
        {
            int LowestFontSize = GetLowestFontSize(tableImages);

            foreach (TableImage tableImage in tableImages)
            {
                tableImage.TableImg = CreateTableNameImage(tableImage.TableName, LowestFontSize);

                foreach (ColumnImage columnImage in tableImage.Columns)
                {
                    columnImage.ColumnImg = CreateTableColumnNameImage(columnImage.ColumnName, LowestFontSize);

                    int width = tableImage.TableImg.Width;
                    int height = tableImage.TableImg.Height + columnImage.ColumnImg.Height;

                    Bitmap newImg = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(newImg);

                    //Table Image
                    g.DrawImage(tableImage.TableImg, new PointF(0, 0));

                    //Column Image
                    PointF newLocation = new PointF(0, tableImage.TableImg.Height);
                    g.DrawImage(columnImage.ColumnImg, newLocation);

                    tableImage.TableImg = newImg;
                }

                string FileName = tableImage.TableName + ".jpg";
                string FilePath = Path.Combine(Path.Combine(connection.ProjectPath, settings.ImagesPath), FileName);

                ImageFormat imgFrmt = ImageFormat.Jpeg;

                tableImage.TableImg.Save(FilePath, imgFrmt);
            }

        }

        private int GetLowestFontSize(List<TableImage> tableImages)
        {
            int LowestFontSize = 999999;

            foreach (TableImage tableImage in tableImages)
            {
                int newTableFontSize = GetFontSizes(tableImage.TableName);

                if (newTableFontSize < LowestFontSize)
                {
                    LowestFontSize = newTableFontSize;
                }

                foreach (ColumnImage columnImage in tableImage.Columns)
                {
                    int newColFontSize = GetFontSizes(columnImage.ColumnName);

                    if (newColFontSize < LowestFontSize)
                    {
                        LowestFontSize = newColFontSize;
                    }
                }
            }

            return LowestFontSize;
        }

        private int GetFontSizes(string Text)
        {
            int fontSize = 1;

            string path = Path.Combine(settings.AppPath, "Resources", "TableName.jpg");
            Bitmap img = new Bitmap(path);

            Graphics g = Graphics.FromImage(img);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Font font = new Font("Arial", fontSize);
            Brush brush = Brushes.White;

            //Confine text to image dimensions
            var stringSize = g.MeasureString(Text, font);
            while (stringSize.Width < img.Width && stringSize.Height < img.Height)
            {
                font = new Font("Arial", fontSize + 1);
                stringSize = g.MeasureString(Text, font);
                fontSize = fontSize + 1;
            }
            fontSize--;

            return fontSize;
        }

        private Bitmap CreateTableNameImage(string TableName, int fontSize)
        {
            string path = Path.Combine(settings.AppPath, "Resources", "TableName.jpg");
            Bitmap img = new Bitmap(path);

            Graphics g = Graphics.FromImage(img);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Font font = new Font("Arial", fontSize);
            Brush brush = Brushes.White;

            //Align text center
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;

            //Create a rectabgle to bound text to
            RectangleF rect = new RectangleF(0, 0, img.Width, img.Height);

            g.DrawString(TableName, font, brush, rect, strFormat);

            return img;
        }
        private Bitmap CreateTableColumnNameImage(string ColumnName, int fontSize)
        {
            string path = Path.Combine(settings.AppPath, "Resources", "Column.jpg");
            Bitmap img = new Bitmap(path);

            Graphics g = Graphics.FromImage(img);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Font font = new Font("Arial", fontSize);
            Brush brush = Brushes.Black;

            //Align text center
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Near;
            strFormat.LineAlignment = StringAlignment.Center;

            //Create a rectabgle to bound text to
            RectangleF rect = new RectangleF(0, 0, img.Width, img.Height);

            g.DrawString(ColumnName, font, brush, rect, strFormat);

            return img;
        }
    }
}
