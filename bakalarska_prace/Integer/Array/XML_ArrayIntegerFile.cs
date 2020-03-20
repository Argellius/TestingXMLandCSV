using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayInteger
{
    class XML_ArrayIntegerFile : Tools, ITester
    {
        private System.Int32[] ArrayInteger;
        private int NumberOfElements;
        

        public XML_ArrayIntegerFile()
        {
            this.NumberOfElements = 0;            
        }

        private void Inicialize(bool Write)
        {
            ArrayInteger = new Int32[this.NumberOfElements];
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayInteger[i] = int.MaxValue;
        }

        public void XML_SerializeArrayIntegerFile()
        {
            XmlSerializer.Serialize(base.StreamWriter, ArrayInteger);
        }

        public void XML_DeSerializeArrayIntegerFile()
        {
            ArrayInteger = (System.Int32[])XmlSerializer.Deserialize(base.StreamReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayInteger.GetType());
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
            ArrayInteger = null;
            XmlSerializer = null;            
        }
        void ITester.TestWrite()
        {
            XML_SerializeArrayIntegerFile();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayIntegerFile();
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
