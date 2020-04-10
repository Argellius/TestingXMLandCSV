using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ListListObject
{
    class XML_ListListObjectFile : Tools, ITester
    {
        private List<List<EmployeeRecord>> ListListObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;
        public XML_ListListObjectFile()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ListListObject = new List<List<EmployeeRecord>>();

            if (Write)
            {
                List<EmployeeRecord> List_Object = new List<EmployeeRecord>();
                for (int i = 0; i < ElementsInCollection; i++)
                    List_Object.Add(new EmployeeRecord(true));

                for (int i = 0; i < NumberOfCollections; i++)
                    ListListObject.Add(new List<EmployeeRecord>(List_Object));
                List_Object.Clear();
                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        List_Object.Add(new EmployeeRecord(true));
                    ListListObject.Add(new List<EmployeeRecord>(List_Object));
                }
            }
        }
        public void XML_SerializeListListObjectFile()
        {
            XmlSerializer.Serialize(base.StreamWriter,ListListObject);
        }

        public void XML_DeSerializeListListObjectFile()
        {
           ListListObject = (List<List<EmployeeRecord>>)XmlSerializer.Deserialize(StreamReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ListListObject.GetType());
            base.ToolsInicializeFile(this.GetType(), true);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeFile(this.GetType(), false);
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndFile(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndFile(false);
            ListListObject = null;
            XmlSerializer = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeListListObjectFile();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListListObjectFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }
        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
