using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ListInteger
{
    class XML_ListIntegerFile : Tools, ITester
    {
        private List<System.Int32> ListInteger;
        private int NumberOfElements;

        public XML_ListIntegerFile(int Pocet_Prvku)
        {
            this.NumberOfElements = Pocet_Prvku;            
        }

        private void Inicialize(bool Write)
        {
            ListInteger = new List<Int32>();
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ListInteger.Add(int.MaxValue);

        }

        public void XML_SerializeArrayIntegerFile()
        {
            XmlSerializer.Serialize(base.StreamWriter, ListInteger);
        }

        public void XML_DeSerializeArrayIntegerFile()
        {
            ListInteger = (List<System.Int32>)XmlSerializer.Deserialize(StreamReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ListInteger.GetType());
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
