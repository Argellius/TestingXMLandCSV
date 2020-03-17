using Polenter.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayListArrayListObject
{
    class XML_ArrayListArrayListObjectSharpSerializer : Tools, ITester
    {
        private ArrayList ListListObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;
        private SharpSerializer XML_SharpSerializer;
        public XML_ArrayListArrayListObjectSharpSerializer()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ListListObject = new ArrayList();

            if (Write)
            {
                for (int i = 0; i < NumberOfCollections; i++)
                {
                    ArrayList List_Object = new ArrayList();
                    for (int k = 0; k < ElementsInCollection; k++)
                    {
                        var it = new EmployeeRecord(true);
                        List_Object.Add(it);
                    }


                    ListListObject.Add(List_Object);
                }
                if (ElementsInLastCollection > 0)
                {
                    ArrayList List_Object = new ArrayList();
                    for (int i = 0; i < ElementsInLastCollection; i++)
                    {
                        var it = new EmployeeRecord(true);
                        List_Object.Add(it);
                    }
                    ListListObject.Add(List_Object);
                }
            }
        }

        public void XML_SerializeListListObjectSharpSerializer()
        {
            XML_SharpSerializer.Serialize(ListListObject, FileStr);
        }

        public void XML_DeSerializeListListObjectSharpSerializer()
        {
            ListListObject = XML_SharpSerializer.Deserialize(FileStr) as ArrayList;
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
            FileStr.Position = 0;
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
            XML_SerializeListListObjectSharpSerializer();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListListObjectSharpSerializer();
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
