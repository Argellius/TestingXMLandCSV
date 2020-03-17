using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayListObject
{
    class XML_ArrayListObjectFile : Tools, ITester
    {
        private ArrayList ArrayListObject;
        private int NumberOfElements;


        public XML_ArrayListObjectFile()
        {
            this.NumberOfElements = 0;            
        }
        private void Inicialize(bool Write)
        {
            ArrayListObject = new ArrayList();

            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListObject.Add(new EmployeeRecord(true));
        }

        public void XML_SerializeArrayListObjectFile()
        {
            XmlSerializer.Serialize(base.StreamWriter, ArrayListObject);
        }

        public void XML_DeSerializeArrayListObjectFile()
        {
            ArrayListObject = (ArrayList)XmlSerializer.Deserialize(base.StreamReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayListObject.GetType(), new Type[] { typeof(EmployeeRecord) });
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
            XML_SerializeArrayListObjectFile();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayListObjectFile();
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
