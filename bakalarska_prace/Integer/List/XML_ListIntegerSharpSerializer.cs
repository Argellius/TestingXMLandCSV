using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ListInteger
{
    class XML_ListIntegerSharpSerializer : Tools, ITester
    {
        private List<System.Int32> ListInteger;
        private int NumberOfElements;
        private SharpSerializer XML_SharpSerializer;
        public XML_ListIntegerSharpSerializer()
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

        public void XML_SerializeListIntegerSharpSerializer()
        {            
            XML_SharpSerializer.Serialize(ListInteger, FileStr);          
        }

        public void XML_DeSerializeListIntegerSharpSerializer()
        {
            this.ListInteger = (List<System.Int32>)XML_SharpSerializer.Deserialize(FileStr);
        }


        void ITester.SetupWriteStart()
        {
            XML_SharpSerializer = new SharpSerializer(false);
            Inicialize(true);
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
            ListInteger = null;
            XML_SharpSerializer = null;
            FileStr = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeListIntegerSharpSerializer();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListIntegerSharpSerializer();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
    }
}
