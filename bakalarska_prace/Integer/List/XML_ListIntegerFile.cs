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

        public XML_ListIntegerFile()
        {
            this.NumberOfElements = 0;            
        }

        private void Inicialize(bool Write)
        {
            ListInteger = new List<Int32>();
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ListInteger.Add(int.MaxValue);

        }

        public void XML_SerializeListIntegerFile()
        {
            XmlSerializer.Serialize(StreamWriter, ListInteger);
        }


        public void XML_DeSerializeListIntegerFile()
        {
            ListInteger = (List<System.Int32>)XmlSerializer.Deserialize(StreamReader);
        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ListInteger.GetType());
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
            ListInteger = null;
            XmlSerializer = null;

        }
        void ITester.TestWrite()
        {
            XML_SerializeListIntegerFile();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListIntegerFile();
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
