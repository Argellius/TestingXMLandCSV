using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayListInteger
{
    class XML_ArrayListIntegerString : Tools, ITester
    {
        private ArrayList ArrayListInteger;
        private int NumberOfElements;

        public XML_ArrayListIntegerString()
        {
            this.NumberOfElements = 0;            
        }

        private void Inicialize(bool write)
        {
            ArrayListInteger = new ArrayList();

            if (write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListInteger.Add(int.MaxValue);
        }

        public void XML_SerializeArrayListIntegerString()
        {
            XmlSerializer.Serialize(base.StringWriter, ArrayListInteger);
        }

        public void XML_DeSerializeArrayListIntegerString()
        {
            ArrayListInteger = (ArrayList)XmlSerializer.Deserialize(base.StringReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayListInteger.GetType(), new Type[] { typeof(int) });
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
            XML_SerializeArrayListIntegerString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayListIntegerString();
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
