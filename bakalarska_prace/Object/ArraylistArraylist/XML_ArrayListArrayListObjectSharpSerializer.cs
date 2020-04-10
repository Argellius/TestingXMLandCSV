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
        private ArrayList ArrayListArrayListObject;
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
            ArrayListArrayListObject = new ArrayList();

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


                    ArrayListArrayListObject.Add(List_Object);
                }
                if (ElementsInLastCollection > 0)
                {
                    ArrayList List_Object = new ArrayList();
                    for (int i = 0; i < ElementsInLastCollection; i++)
                    {
                        var it = new EmployeeRecord(true);
                        List_Object.Add(it);
                    }
                    ArrayListArrayListObject.Add(List_Object);
                }
            }
        }

        public void XML_SerializeListListObjectSharpSerializer()
        {
            XML_SharpSerializer.Serialize(ArrayListArrayListObject, FileStr);
        }

        public void XML_DeSerializeListListObjectSharpSerializer()
        {
            ArrayListArrayListObject = XML_SharpSerializer.Deserialize(FileStr) as ArrayList;
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
            ArrayListArrayListObject = null;
            XML_SharpSerializer = null;
            FileStr = null;
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
        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
