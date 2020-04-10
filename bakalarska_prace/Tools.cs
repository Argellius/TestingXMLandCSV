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

        protected void SetPath (string path)
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
                lengthFile =  new FileInfo(FileName + ".csv").Length;
            }
            else if (File.Exists(FileName + ".xml"))
            {
                lengthFile = new FileInfo(FileName + ".xml").Length;
            }
            else
                return 0;

            if (StreamReader != null)
            {
                StreamWriter = null;
                StreamReader = null;
                StringBuilder.Clear();
            }

            return lengthFile;

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
            if (StringReader != null)
            {
                this.StringData = null;
                StringWriter = null;
                StringReader = null;
                StringBuilder = null;            
            }
            return length;   
        }



    }
    /*
    abstract class Tools
    {
        //protected string XML_Text;
        //protected string CSV_Text;
        protected string path = @"..\..\..\Testing_Files\";

        protected RecordOfEmployee _Zamestnanci_With_Data;
               

        public Tools()
        {
            // Casove_Zaznamy_Testu = new List<double>();
            _Zamestnanci_With_Data = new RecordOfEmployee(true);
        }
        /*
        protected void Turn_Testing(ref double time)
        {

            watch.Start();
            MyTestingHandler.Invoke();
            watch.Stop();
            time = watch.Elapsed.TotalMilliseconds;
            watch.Reset();
        }*/



    /*  protected void Init_Collections_Objects(dynamic obj)
      {
          if (obj is List<RecordOfEmployee> || obj is ArrayList)
          {
              for (int i = 0; i < Pocet_Prvku; i++)
                  obj.Add(_Zamestnanci_With_Data);
          }
          else if (obj is RecordOfEmployee[])
          {

              for (int i = 0; i < Pocet_Prvku; i++)
                  obj[i] = _Zamestnanci_With_Data;
          }
          else if (obj is RecordOfEmployee[][])
          {
              for (int i = 0; i < Pocet_Prvku; i++)
              {
                  obj[i] = new RecordOfEmployee[Pocet_Prvku];
              }

              for (int i = 0; i < Pocet_Prvku; i++)
              {
                  for (int j = 0; j < Pocet_Prvku; j++)
                  {
                      obj[i][j] = _Zamestnanci_With_Data;
                  }
              }

          }
          else if (obj is List<List<RecordOfEmployee>>)
          {
              List<RecordOfEmployee> it = new List<RecordOfEmployee>();
              for (int i = 0; i < Pocet_Prvku; i++)
                  it.Add(_Zamestnanci_With_Data);


              for (int i = 0; i < Pocet_Prvku; i++)
                  obj.Add(it);

          }



      }*/

    /* protected void Init_Collections_Integer(dynamic obj)
     {
         if (obj is System.Int32[])
         {
             for (int i = 0; i < Pocet_Prvku; i++)
                 obj[i] = int.MaxValue;
         }
         else if (obj is System.Int32[][])
         {
             for (int i = 0; i < Pocet_Prvku; i++)
             {
                 obj[i] = new int[Pocet_Prvku];
             }

             for (int i = 0; i < Pocet_Prvku; i++)
             {
                 for (int j = 0; j < Pocet_Prvku; j++)
                 {
                     obj[i][j] = int.MaxValue;
                 }
             }
         }
         else if (obj is List<int> || obj is ArrayList)
         {
             for (int i = 0; i < Pocet_Prvku; i++)
                 obj.Add(int.MaxValue);
         }

         else if (obj is List<List<int>>)
         {
             List<int> it = new List<int>();
             for (int i = 0; i < Pocet_Prvku; i++)
                 it.Add(int.MaxValue);


             for (int i = 0; i < Pocet_Prvku; i++)
                 obj.Add(it);

         }


     } */

    /* public void Init_Dictionary(dynamic obj)
     {
         if (obj is MySerializableDictionary<int, List<int>>)
         {
             List<int> List_Int = new List<int>();
             Init_Collections_Integer(List_Int);
             for (int i = 0; i < Pocet_Prvku; i++)
             {
                 obj.Add(int.MaxValue, List_Int);
             }
         }

         else if (obj is MySerializableDictionary<RecordOfEmployee, List<RecordOfEmployee>>)
         {
             List<RecordOfEmployee> List_Obj = new List<RecordOfEmployee>();
             Init_Collections_Objects(List_Obj);
             for (int i = 0; i < Pocet_Prvku; i++)
             {
                 obj.Add(_Zamestnanci_With_Data, List_Obj);
             }
        }
     }

    public abstract void Create_Test_String(ref string Nazev_Testu, ref double time);
        public abstract void Read_Test_String(ref string Nazev_Testu, ref double time);

        public abstract void Create_Test_Disk(ref string Nazev_Testu, ref double time);
        public abstract void Read_Test_Disk(ref string Nazev_Testu, ref double time);

    }

    */
}

