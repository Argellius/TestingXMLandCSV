using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayArrayInteger
{
    class XML_ArrayArrayIntegerString : Tools, ITester
    {
        private System.Int32[][] ArrayArray_Integer;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public XML_ArrayArrayIntegerString()
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
        public void XML_SerializeArrayArrayIntegerString()
        {
            XmlSerializer.Serialize(base.StringWriter, ArrayArray_Integer);
        }

        public void XML_DeSerializeArrayArrayIntegerString()
        {
            ArrayArray_Integer = (Int32[][])XmlSerializer.Deserialize(base.StringReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayArray_Integer.GetType(), new Type[] { typeof(int) });
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
            XML_SerializeArrayArrayIntegerString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayArrayIntegerString();
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
