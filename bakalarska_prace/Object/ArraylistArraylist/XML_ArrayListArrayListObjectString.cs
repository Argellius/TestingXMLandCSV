using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayListArrayListObject
{
    class XML_ArrayListArrayListObjectString : Tools, ITester
    {
        private ArrayList ArrayListArrayListObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public XML_ArrayListArrayListObjectString()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayListArrayListObject = new ArrayList();

            if (Write)
            {
                ArrayList ArrayListIntreger = new ArrayList();

                for (int i = 0; i < ElementsInCollection; i++)
                    ArrayListIntreger.Add(new EmployeeRecord(true));

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayListArrayListObject.Add(new ArrayList(ArrayListIntreger));

                ArrayListIntreger.Clear();

                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        ArrayListIntreger.Add(new EmployeeRecord(true));
                    ArrayListArrayListObject.Add(new ArrayList(ArrayListIntreger));
                }

            }
        }
        public void XML_SerializeArrayListArrayListObjectString()
        {
            XmlSerializer.Serialize(base.StringWriter, ArrayListArrayListObject);
        }

        public void XML_DeSerializeArrayListArrayListObjectString()
        {            
            ArrayListArrayListObject = (ArrayList)XmlSerializer.Deserialize(base.StringReader);                       
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayListArrayListObject.GetType(), new Type[] { typeof(EmployeeRecord) });
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
            XML_SerializeArrayListArrayListObjectString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayListArrayListObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile();
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }
    }
}
