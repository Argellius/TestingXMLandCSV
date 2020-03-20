using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayObject
{
    class XML_ArrayObjectFile : Tools, ITester
    {
        private EmployeeRecord[] ArrayObject;
        private int NumberOfElements;
        

        public XML_ArrayObjectFile()
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

        public void XML_SerializeArrayObjectFile()
        {
            XmlSerializer.Serialize(base.StreamWriter, ArrayObject);
        }


        public void XML_DeSerializeArrayObjectFile()
        {
            ArrayObject = (EmployeeRecord[])XmlSerializer.Deserialize(base.StreamReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayObject.GetType());
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
            ArrayObject = null;
            XmlSerializer = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeArrayObjectFile();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayObjectFile();
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
