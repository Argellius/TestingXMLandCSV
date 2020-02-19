using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayListInteger
{
    class XML_ArrayListIntegerFile : Tools, ITester
    {
        private ArrayList ArrayListInteger;
        private int NumberOfElements;


        public XML_ArrayListIntegerFile(int Pocet_Prvku)
        {
            this.NumberOfElements = Pocet_Prvku;            
        }
        private void Inicialize(bool write)
        {
            ArrayListInteger = new ArrayList();

            if (write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListInteger.Add(int.MaxValue);
        }

        public void XML_SerializeArrayIntegerFile()
        {
            XmlSerializer.Serialize(base.StreamWriter, ArrayListInteger);
        }

        public void XML_DeSerializeArrayIntegerFile()
        {
            ArrayListInteger = (ArrayList)XmlSerializer.Deserialize(base.StreamReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayListInteger.GetType(), new Type[] { typeof(int) });
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
    }
}
