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

    class XML_ArrayListIntegerNuget : Tools, ITester
    {
        private ArrayList ArrayListInteger;
        private int NumberOfElements;
        private SharpSerializer XML_SharpSerializer;


        public XML_ArrayListIntegerNuget(int Pocet_Prvku)
        {
            this.NumberOfElements = Pocet_Prvku;
            XML_SharpSerializer = new SharpSerializer(false);

        }

        private void Inicialize(bool Write)
        {
            ArrayListInteger = new ArrayList();

            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListInteger.Add(int.MaxValue);
        }

        public void XML_SerializeArrayIntegerNuget()
        {
            XML_SharpSerializer.Serialize(ArrayListInteger, FileStr);
        }

        public void XML_DeSerializeArrayIntegerNuget()
        {
            this.ArrayListInteger = (ArrayList)XML_SharpSerializer.Deserialize(FileStr);

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
    }
}
