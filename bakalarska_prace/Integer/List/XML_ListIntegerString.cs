using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ListInteger
{
    class XML_ListIntegerString : Tools, ITester
    {
        private List<System.Int32> ListInteger;
        private int NumberOfElements;

        public XML_ListIntegerString()
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
        public void XML_SerializeListIntegerString()
        {
            XmlSerializer.Serialize(StringWriter, ListInteger);
        }

        public void XML_DeSerializeListIntegerString()
        {
            ListInteger = (List<Int32>)XmlSerializer.Deserialize(StringReader);
        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ListInteger.GetType());
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
            ListInteger = null;
            XmlSerializer = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeListIntegerString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListIntegerString();
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
