using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ListListObject
{
    class XML_ListListObjectSharpSerializer : Tools, ITester
    {
        private List<List<EmployeeRecord>> ListListObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;
        private SharpSerializer XML_SharpSerializer;
        public XML_ListListObjectSharpSerializer()
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

        public void XML_SerializeListListObjectSharpSerializer()
        {
            XML_SharpSerializer.Serialize(ListListObject, FileStr);
        }

        public void XML_DeSerializeListListObjectSharpSerializer()
        {            
            ListListObject = XML_SharpSerializer.Deserialize(FileStr) as List<List<EmployeeRecord>>;           
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            FileStr = new System.IO.FileStream(path + this.GetType().Name + ".xml", System.IO.FileMode.Create);
            XML_SharpSerializer = new SharpSerializer(false);

        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            FileStr = new System.IO.FileStream(path + this.GetType().Name + ".xml", System.IO.FileMode.Open);
            FileStr.Position = 0;
        }
        void ITester.SetupWriteEnd()
        {
            
            FileStr.Close();
            FileStr.Dispose();

        }
        void ITester.SetupReadEnd()
        {
            FileStr.Close();
            FileStr.Dispose();
            ListListObject = null;
            XML_SharpSerializer = null;
            FileStr = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeListListObjectSharpSerializer();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListListObjectSharpSerializer();
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
    }
}
