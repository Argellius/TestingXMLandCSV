using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace
{

    abstract class Tools
    {
        protected StringBuilder StringData;

        //protected string path = @"..\..\..\TestResults\";
        protected string path = @"C:\TestResults\";

        //XMLSerializer
        protected XmlSerializer XmlSerializer;

        //String test tools
        protected StringBuilder StringBuilder;

        protected StringWriter StringWriter;
        protected StringReader StringReader;

        //File test tools
        protected StreamWriter StreamWriter;
        protected StreamReader StreamReader;

        //CSVHelper
        protected CsvWriter csvWriter;
        protected CsvReader csvReader;

        //SharpSerializer
        protected FileStream FileStr;

        public Tools()
        {
            StringBuilder = new StringBuilder();
        }

        protected void SetPath(string path)
        {
            this.path = path;

            var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(path));
            if (!destinationDirectory.Exists)
                destinationDirectory.Create();
        }


        //File tools
        protected void ToolsInicializeFile(Type obj, bool Write)
        {

            string ClassName = obj.Name;
            if (Write)
            {
                if (ClassName.Substring(0, 3).ToLower() == "csv")
                {
                    if (File.Exists(path + ClassName + ".csv"))
                        File.Delete(path + ClassName + ".csv");

                    this.StreamWriter = new StreamWriter(this.path + ClassName + ".csv");
                }
                else
                {
                    if (File.Exists(path + ClassName + ".xml"))
                    {
                        File.Delete(path + ClassName + ".xml");
                    }
                    this.StreamWriter = new StreamWriter(this.path + ClassName + ".xml");
                }
            }

            else
            {
                if (ClassName.Substring(0, 3).ToLower() == "csv")
                    this.StreamReader = new StreamReader(this.path + ClassName + ".csv");
                else
                    this.StreamReader = new StreamReader(this.path + ClassName + ".xml");

            }
            StringBuilder.Clear();
        }

        protected void ToolsSetupEndFile(bool Write)
        {
            if (Write)
            {
                if (StringBuilder.Length > 0)
                    StringBuilder.Clear();
                this.StreamWriter.Flush();
                this.StreamWriter.Close();
                this.StreamWriter.Dispose();

            }
            else
            {
                if (StringBuilder.Length > 0)
                    StringBuilder.Clear();
                this.StreamReader.BaseStream.Flush();
                this.StreamReader.Close();
                this.StreamReader.Dispose();
            }
        }
        protected long ToolsGetSizeOfFile(Type obj)
        {
            if (StringBuilder == null)
                StringBuilder = new StringBuilder();

            string FileName = this.path + obj.Name;
            long lengthFile;
            if (File.Exists(FileName + ".csv"))
            {
                lengthFile = new FileInfo(FileName + ".csv").Length;
            }
            else if (File.Exists(FileName + ".xml"))
            {
                lengthFile = new FileInfo(FileName + ".xml").Length;
            }
            else
                return 0;
            #region vyčištění
            if (StreamReader != null)
            {
                StreamWriter = null;
                StreamReader = null;
                StringBuilder.Clear();
            }

            return lengthFile;
            #endregion
        }


        //String tools
        protected void ToolsInicializeString(bool Write, StringBuilder data = null)
        {
            if (StringBuilder == null)
                StringBuilder = new StringBuilder();
            if (Write)
                this.StringWriter = new StringWriter();
            else
                this.StringReader = new StringReader(StringWriter.ToString());
        }

        protected void ToolsSetupEndString(bool Write)
        {
            if (Write)
            {
                StringBuilder.Clear();
                StringWriter.Close();
                StringWriter.Flush();
            }
            else
            {
                this.StringData = null;
                this.StringBuilder.Clear();
                this.StringReader.Close();
            }
        }

        protected long ToolsGetSizeOfString()
        {
            var length = StringWriter.GetStringBuilder().Length;
            #region flush
            if (StringReader != null)
            {
                this.StringData = null;
                StringWriter = null;
                StringReader = null;
                StringBuilder = null;
            }
            #endregion
            return length;
        }        

    }
}
