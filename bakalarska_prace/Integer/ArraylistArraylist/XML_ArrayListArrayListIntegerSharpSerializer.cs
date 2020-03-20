using Polenter.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayListArrayListInteger
{

    class XML_ArrayListArrayListIntegerSharpSerializer : Tools, ITester
    {
        private ArrayList ArrayListArrayListInteger;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;
        private SharpSerializer XML_SharpSerializer;

        public XML_ArrayListArrayListIntegerSharpSerializer()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayListArrayListInteger = new ArrayList();

            if (Write)
            {
                ArrayList ArrayListIntreger = new ArrayList();
                for (int i = 0; i < ElementsInCollection; i++)
                    ArrayListIntreger.Add(System.Int32.MaxValue);

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayListArrayListInteger.Add(new ArrayList(ArrayListIntreger));
                ArrayListIntreger.Clear();
                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        ArrayListIntreger.Add(Int32.MaxValue);
                    ArrayListArrayListInteger.Add(new ArrayList(ArrayListIntreger));
                }

            }
        }
        public void XML_SerializeArrayListArrayListIntegerSharpSerializer()
        {
           
            XML_SharpSerializer.Serialize(ArrayListArrayListInteger, FileStr);
            
        }

        public void XML_DeSerializeArrayListArrayListIntegerSharpSerializer()
        {
            ArrayListArrayListInteger = (ArrayList)XML_SharpSerializer.Deserialize(FileStr);
        }

        void ITester.SetupWriteStart()
        {
            
            Inicialize(true);
            FileStr = new System.IO.FileStream(path + this.GetType().Name + ".xml", System.IO.FileMode.Create);
            XML_SharpSerializer = new SharpSerializer(false);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            FileStr = new System.IO.FileStream(path + this.GetType().Name + ".xml", System.IO.FileMode.Open);
        }
        void ITester.SetupWriteEnd()
        {
            FileStr.Close();
            FileStr.Dispose();
        }
        void ITester.SetupReadEnd()
        {
            FileStr.Close();
            FileStr.Dispose();

            ArrayListArrayListInteger = null;
            XML_SharpSerializer = null;
            FileStr = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeArrayListArrayListIntegerSharpSerializer();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayListArrayListIntegerSharpSerializer();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }

    }
}
