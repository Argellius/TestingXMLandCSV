using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayInteger
{
    class XML_ArrayIntegerString : Tools, ITester
    {
        private System.Int32[] ArrayInteger;
        private int NumberOfElements;

        public XML_ArrayIntegerString()
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

        public void XML_SerializeArrayIntegerString()
        {
            XmlSerializer.Serialize(base.StringWriter, ArrayInteger);
        }

        public void XML_DeSerializeArrayIntegerString()
        {
            ArrayInteger = (System.Int32[])XmlSerializer.Deserialize(base.StringReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayInteger.GetType());
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
        }
        void ITester.TestWrite()
        {
            XML_SerializeArrayIntegerString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayIntegerString();
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
