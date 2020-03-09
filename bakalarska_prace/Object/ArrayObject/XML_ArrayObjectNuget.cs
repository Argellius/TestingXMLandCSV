using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayObject
{
    class XML_ArrayObjectNuget : Tools, ITester
    {
        private EmployeeRecord[] ArrayObject;
        private int NumberOfElements;
        private SharpSerializer XML_SharpSerializer;

        public XML_ArrayObjectNuget()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayObject = new EmployeeRecord[this.NumberOfElements];
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayObject[i] = new EmployeeRecord(true);

        }

        public void XML_SerializeArrayObjectNuget()
        {
            XML_SharpSerializer.Serialize(ArrayObject, FileStr);
        }

        public void XML_DeSerializeArrayObjectNuget()
        {
            this.ArrayObject = (EmployeeRecord[])XML_SharpSerializer.Deserialize(FileStr);
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
        }
        void ITester.TestWrite()
        {
            XML_SerializeArrayObjectNuget();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayObjectNuget();
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
