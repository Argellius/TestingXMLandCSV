using Polenter.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayArrayInteger
{

    class XML_ArrayArrayIntegerSharpSerializer : Tools, ITester
    {
        private System.Int32[][] ArrayArray_Integer;        
        private SharpSerializer XML_SharpSerializer;        
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public XML_ArrayArrayIntegerSharpSerializer()
        {
            NumberOfCollections = 0;
            ElementsInCollection = 0;
            ElementsInLastCollection = 0;           
        }
        private void Inicialize(bool Write)
        {
            if (ElementsInLastCollection > 0)
            {
                ArrayArray_Integer = new Int32[this.NumberOfCollections + 1][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArray_Integer[i] = new int[ElementsInCollection];
                ArrayArray_Integer[NumberOfCollections] = new int[ElementsInLastCollection];
            }
            else
            {
                ArrayArray_Integer = new Int32[this.NumberOfCollections][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArray_Integer[i] = new int[ElementsInCollection];
            }

            if (Write)
            {
                for (int j = 0; j < NumberOfCollections; j++)
                    for (int i = 0; i < ElementsInCollection; i++)
                        ArrayArray_Integer[j][i] = int.MaxValue;
                if (ElementsInLastCollection > 0)
                {
                    for (int j = 0; j < ElementsInLastCollection; j++)
                        ArrayArray_Integer[NumberOfCollections][j] = int.MaxValue;
                }

            }
        }
        public void XML_SerializeArrayArrayIntegerSharpSerializer()
        {
           
            XML_SharpSerializer.Serialize(ArrayArray_Integer, FileStr);
        }

        public void XML_DeSerializeArrayArrayIntegerSharpSerializer()
        {
            this.ArrayArray_Integer = (Int32[][])XML_SharpSerializer.Deserialize(FileStr);
            
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XML_SharpSerializer = new SharpSerializer(false);
            FileStr = new System.IO.FileStream(path + this.GetType().Name + ".xml", System.IO.FileMode.Create);

        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            FileStr = new System.IO.FileStream(path + this.GetType().Name + ".xml", System.IO.FileMode.Open);
        }
        void ITester.SetupWriteEnd()
        {
            FileStr.Close();

        }
        void ITester.SetupReadEnd()
        {
            FileStr.Close();
        }
        void ITester.TestWrite()
        {
            XML_SerializeArrayArrayIntegerSharpSerializer();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayArrayIntegerSharpSerializer();
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
