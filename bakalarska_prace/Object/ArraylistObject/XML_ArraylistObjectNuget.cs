using Polenter.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayListObject
{

    class XML_ArrayListObjectNuget : Tools, ITester
    {
        private ArrayList ArrayListObject;
        private int NumberOfElements;
        private SharpSerializer XML_SharpSerializer;


        public XML_ArrayListObjectNuget()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayListObject = new ArrayList();

            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListObject.Add(new EmployeeRecord(true));
        }

        public void XML_SerializeArrayListObjectNuget()
        {
            XML_SharpSerializer.Serialize(ArrayListObject, FileStr);
        }

        public void XML_DeSerializeArrayListObjectNuget()
        {
            this.ArrayListObject = (ArrayList)XML_SharpSerializer.Deserialize(FileStr);

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
        }
        void ITester.TestWrite()
        {
            XML_SerializeArrayListObjectNuget();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayListObjectNuget();
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
