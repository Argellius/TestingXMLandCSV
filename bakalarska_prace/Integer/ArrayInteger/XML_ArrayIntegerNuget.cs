using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayInteger
{
    class XML_ArrayIntegerNuget : Tools, ITester
    {
        private System.Int32[] ArrayInteger;
        private int NumberOfElements;
        private SharpSerializer XML_SharpSerializer;

        public XML_ArrayIntegerNuget()
        {
            this.NumberOfElements = 0;
            XML_SharpSerializer = new SharpSerializer(false);


        }

        private void Inicialize(bool Write)
        {
            ArrayInteger = new Int32[this.NumberOfElements];
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayInteger[i] = int.MaxValue;
        }

        public void XML_SerializeArrayIntegerNuget()
        {
            XML_SharpSerializer.Serialize(ArrayInteger, FileStr);            
        }

        public void XML_DeSerializeArrayIntegerNuget()
        {            
                this.ArrayInteger = (Int32[])XML_SharpSerializer.Deserialize(FileStr);
            
        }

        void ITester.SetupWriteStart()
        {
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
        }
        void ITester.TestWrite()
        {
            XML_SerializeArrayIntegerNuget();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayIntegerNuget();
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
