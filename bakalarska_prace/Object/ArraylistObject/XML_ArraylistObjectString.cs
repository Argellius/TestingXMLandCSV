using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayListObject
{
    class XML_ArrayListObjectString : Tools, ITester
    {
        private ArrayList ArrayListObject;
        private int NumberOfElements;

        public XML_ArrayListObjectString(int Pocet_Prvku)
        {
            this.NumberOfElements = Pocet_Prvku;            
        }

        private void Inicialize(bool Write)
        {
            ArrayListObject = new ArrayList();

            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListObject.Add(new RecordOfEmployee(true));
        }

        public void XML_SerializeArrayListObjectString()
        {
            XmlSerializer.Serialize(base.StringWriter, ArrayListObject);
        }

        public void XML_DeSerializeArrayListObjectString()
        {
            ArrayListObject = (ArrayList)XmlSerializer.Deserialize(base.StringReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayListObject.GetType(), new Type[] { typeof(RecordOfEmployee) });
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
            XML_SerializeArrayListObjectString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayListObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
    }
}
