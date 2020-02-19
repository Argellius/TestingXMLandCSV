﻿using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ListObject
{
    class XML_ListObjectNuget : Tools, ITester
    {
        private List<RecordOfEmployee> ListObject;
        private int NumberOfElements;
        private SharpSerializer XML_SharpSerializer;

        public XML_ListObjectNuget(int Pocet_Prvku)
        {            
            this.NumberOfElements = Pocet_Prvku;
        }

        private void Inicialize(bool Write)
        {
            ListObject = new List<RecordOfEmployee>();
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ListObject.Add(new RecordOfEmployee(true));

        }

        public void XML_SerializeListObjectNuget()
        {
            XML_SharpSerializer.Serialize(ListObject, FileStr);
        }

        public void XML_DeSerializeListObjectNuget()
        {
            this.ListObject = (List<RecordOfEmployee>)XML_SharpSerializer.Deserialize(FileStr);

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
            XML_SerializeListObjectNuget();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListObjectNuget();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}