using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ListListObject
{
    class XML_ListListObjectString : Tools, ITester
    {
        private List<List<EmployeeRecord>> ListListObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;
        public XML_ListListObjectString()
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

        public void XML_SerializeListListObjectString()
        {
            XmlSerializer.Serialize(StringWriter, ListListObject);
        }

        public void XML_DeSerializeListListObjectString()
        {
            ListListObject = (List<List<EmployeeRecord>>)XmlSerializer.Deserialize(StringReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ListListObject.GetType());
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
            ListListObject = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeListListObjectString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListListObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }
    }
}
