using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ListObject
{
    class XML_ListObjectSharpSerializer : Tools, ITester
    {
        private List<EmployeeRecord> ListObject;
        private int NumberOfElements;
        private SharpSerializer XML_SharpSerializer;

        public XML_ListObjectSharpSerializer()
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

        public void XML_SerializeListObjectSharpSerializer()
        {
            XML_SharpSerializer.Serialize(ListObject, FileStr);
        }

        public void XML_DeSerializeListObjectSharpSerializer()
        {
            this.ListObject = (List<EmployeeRecord>)XML_SharpSerializer.Deserialize(FileStr);

        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XML_SharpSerializer = new SharpSerializer(false);
            FileStr = new System.IO.FileStream(path + this.GetType().Name + ".xml", System.IO.FileMode.Create);

        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            FileStr = new System.IO.FileStream(path + this.GetType().Name + ".xml", System.IO.FileMode.Open);
        }
        void ITester.SetupWriteEnd()
        {
            FileStr.Close();

        }
        void ITester.SetupReadEnd()
        {
            FileStr.Close();
            ListObject = null;
            XML_SharpSerializer = null;
            FileStr = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeListObjectSharpSerializer();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListObjectSharpSerializer();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
