using Polenter.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayArrayObject
{

    class XML_ArrayArrayObjectNuget : Tools, ITester
    {
        private EmployeeRecord[][] ArrayArrayObject;
        
        private SharpSerializer XML_SharpSerializer;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public XML_ArrayArrayObjectNuget()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            if (ElementsInLastCollection > 0)
            {
                ArrayArrayObject = new EmployeeRecord[this.NumberOfCollections + 1][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArrayObject[i] = new EmployeeRecord[ElementsInCollection];
                ArrayArrayObject[NumberOfCollections] = new EmployeeRecord[ElementsInLastCollection];
            }
            else
            {
                ArrayArrayObject = new EmployeeRecord[this.NumberOfCollections][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArrayObject[i] = new EmployeeRecord[ElementsInCollection];
            }

            if (Write)
            {
                for (int j = 0; j < NumberOfCollections; j++)
                    for (int i = 0; i < ElementsInCollection; i++)
                        ArrayArrayObject[j][i] = new EmployeeRecord(true);
                if (ElementsInLastCollection > 0)
                {
                    for (int j = 0; j < ElementsInLastCollection; j++)
                        ArrayArrayObject[NumberOfCollections][j] = new EmployeeRecord(true);
                }

            }
        }
        public void XML_SerializeArrayArrayObjectNuget()
        {
            XML_SharpSerializer.Serialize(ArrayArrayObject, FileStr);
        }

        public void XML_DeSerializeArrayArrayObjectNuget()
        {
            this.ArrayArrayObject = (EmployeeRecord[][])XML_SharpSerializer.Deserialize(FileStr);
            
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
            XML_SerializeArrayArrayObjectNuget();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayArrayObjectNuget();
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
