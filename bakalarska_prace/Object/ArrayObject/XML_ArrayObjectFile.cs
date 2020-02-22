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
        private RecordOfEmployee[] ArrayObject;
        private int NumberOfElements;
        

        public XML_ArrayObjectFile()
        {
            this.NumberOfElements = 0;            
        }

        private void Inicialize(bool Write)
        {
            ArrayObject = new RecordOfEmployee[this.NumberOfElements];
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayObject[i] = new RecordOfEmployee(true);

        }

        public void XML_SerializeListListObjectFile()
        {
            XmlSerializer.Serialize(base.StreamWriter, ArrayObject);
        }

        public void XML_DeSerializeArrayObjectFile()
        {
            ArrayObject = (RecordOfEmployee[])XmlSerializer.Deserialize(base.StreamReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayObject.GetType());
            base.ToolsInicializeStream(this.GetType(), true);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeStream(this.GetType(), false);
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndFile(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndFile(false);
        }
        void ITester.TestWrite()
        {
            XML_SerializeListListObjectFile();
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
