using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ListObject
{
    class XML_ListObjectString : Tools, ITester
    {
        private List<EmployeeRecord> ListObject;
        private int NumberOfElements;

        public XML_ListObjectString()
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
        public void XML_SerializeListObjectString()
        {
            XmlSerializer.Serialize(StringWriter, ListObject);
        }

        public void XML_DeSerializeListObjectString()
        {
            ListObject = (List<EmployeeRecord>)XmlSerializer.Deserialize(StringReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ListObject.GetType());
            base.ToolsInicializeString(true);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeString(false, base.StringData);
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndString(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndString(false);
            ListObject = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeListObjectString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
    }
}
