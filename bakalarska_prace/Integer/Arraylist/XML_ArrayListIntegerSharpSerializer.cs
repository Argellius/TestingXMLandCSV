﻿

using Polenter.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayListInteger
{

    class XML_ArrayListIntegerSharpSerializer : Tools, ITester
    {
        private ArrayList ArrayListInteger;
        private int NumberOfElements;
        private SharpSerializer XML_SharpSerializer;


        public XML_ArrayListIntegerSharpSerializer()
        {
            this.NumberOfElements = 0;

        }

        private void Inicialize(bool Write)
        {
            ArrayListInteger = new ArrayList();

            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListInteger.Add(int.MaxValue);
        }

        public void XML_SerializeArrayIntegerSharpSerializer()
        {
            XML_SharpSerializer.Serialize(ArrayListInteger, FileStr);
        }

        public void XML_DeSerializeArrayIntegerSharpSerializer()
        {
            this.ArrayListInteger = (ArrayList)XML_SharpSerializer.Deserialize(FileStr);

        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            FileStr = new System.IO.FileStream(path + this.GetType().Name + ".xml", System.IO.FileMode.Create);
            this.XML_SharpSerializer = new SharpSerializer(false);
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
            ArrayListInteger = null;
            XML_SharpSerializer = null;
            FileStr = null;
        }
        void ITester.TestWrite()
        {
            XML_SerializeArrayIntegerSharpSerializer();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayIntegerSharpSerializer();
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
