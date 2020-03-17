﻿using Polenter.Serialization;
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
        private List<List<System.Int32>> ListListInteger;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;
        private SharpSerializer XML_SharpSerializer;

        public XML_ArrayListArrayListIntegerSharpSerializer()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
            XML_SharpSerializer = new SharpSerializer(false);
        }

        private void Inicialize(bool Write)
        {
            ListListInteger = new List<List<System.Int32>>();
            if (Write)
            {
                List<int> ListInteger = new List<int>();
                for (int i = 0; i < ElementsInCollection; i++)
                    ListInteger.Add(System.Int32.MaxValue);

                for (int i = 0; i < NumberOfCollections; i++)
                    ListListInteger.Add(new List<int>(ListInteger));
                ListInteger.Clear();
                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        ListInteger.Add(Int32.MaxValue);
                    ListListInteger.Add(new List<int>(ListInteger));
                }

            }
        }
        public void XML_SerializeArrayListArrayListIntegerSharpSerializer()
        {
           
            XML_SharpSerializer.Serialize(ListListInteger, FileStr);
            
        }

        public void XML_DeSerializeArrayListArrayListIntegerSharpSerializer()
        {
            ListListInteger = (List<List<Int32>>)XML_SharpSerializer.Deserialize(FileStr);
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
            FileStr.Dispose();
        }
        void ITester.SetupReadEnd()
        {
            FileStr.Close();
            FileStr.Dispose();
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
