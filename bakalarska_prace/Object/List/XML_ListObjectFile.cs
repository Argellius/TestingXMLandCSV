using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ListObject
{
    class XML_ListObjectFile : Tools, ITester
    {
        private List<EmployeeRecord> ListObject;
        private int NumberOfElements;

        public XML_ListObjectFile()
        {
            this.NumberOfElements = 0;            
        }

        private void Inicialize(bool Write)
        {
            ListObject = new List<EmployeeRecord>();
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ListObject.Add(new EmployeeRecord(true));

        }
        public void XML_SerializeListObjectFile()
        {
            XmlSerializer.Serialize(base.StreamWriter, ListObject);
        }

        public void XML_DeSerializeListObjectFile()
        {
            ListObject = (List<EmployeeRecord>)XmlSerializer.Deserialize(StreamReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ListObject.GetType());
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
            ListObject = null;
            XmlSerializer = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeListObjectFile();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListObjectFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
    }
}
