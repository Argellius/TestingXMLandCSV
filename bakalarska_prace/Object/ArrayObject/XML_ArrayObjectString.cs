using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayObject
{
    class XML_ArrayObjectString : Tools, ITester
    {
        private RecordOfEmployee[] ArrayObject;
        private int NumberOfElements;

        public XML_ArrayObjectString(int Pocet_Prvku)
        {
            this.NumberOfElements = Pocet_Prvku;            
        }

        private void Inicialize(bool Write)
        {
            ArrayObject = new RecordOfEmployee[this.NumberOfElements];
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayObject[i] = new RecordOfEmployee(true);

        }

        public void XML_SerializeListListObjectString()
        {
            XmlSerializer.Serialize(base.StringWriter, ArrayObject);
        }

        public void XML_DeSerializeArrayObjectString()
        {
            ArrayObject = (RecordOfEmployee[])XmlSerializer.Deserialize(base.StringReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayObject.GetType());
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
            XML_SerializeListListObjectString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
    }
}
