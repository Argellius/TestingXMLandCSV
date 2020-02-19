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
        private RecordOfEmployee[][] ArrayArrayObject;
        
        private SharpSerializer XML_SharpSerializer;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;

        public XML_ArrayArrayObjectNuget(int NumberOfElements)
        {
            this.pocetKolekci = (int)Math.Sqrt(NumberOfElements);
            this.pocetPrvkuVKolekci = NumberOfElements / pocetKolekci;
            this.pocetPrvkuVPosledniKolekci = NumberOfElements % pocetKolekci;
        }

        private void Inicialize(bool Write)
        {
            if (pocetPrvkuVPosledniKolekci > 0)
            {
                ArrayArrayObject = new RecordOfEmployee[this.pocetKolekci + 1][];

                for (int i = 0; i < pocetKolekci; i++)
                    ArrayArrayObject[i] = new RecordOfEmployee[pocetPrvkuVKolekci];
                ArrayArrayObject[pocetKolekci] = new RecordOfEmployee[pocetPrvkuVPosledniKolekci];
            }
            else
            {
                ArrayArrayObject = new RecordOfEmployee[this.pocetKolekci][];

                for (int i = 0; i < pocetKolekci; i++)
                    ArrayArrayObject[i] = new RecordOfEmployee[pocetPrvkuVKolekci];
            }

            if (Write)
            {
                for (int j = 0; j < pocetKolekci; j++)
                    for (int i = 0; i < pocetPrvkuVKolekci; i++)
                        ArrayArrayObject[j][i] = new RecordOfEmployee(true);
                if (pocetPrvkuVPosledniKolekci > 0)
                {
                    for (int j = 0; j < pocetPrvkuVPosledniKolekci; j++)
                        ArrayArrayObject[pocetKolekci][j] = new RecordOfEmployee(true);
                }

            }
        }
        public void XML_SerializeArrayArrayObjectNuget()
        {
            XML_SharpSerializer.Serialize(ArrayArrayObject, FileStr);
        }

        public void XML_DeSerializeArrayArrayObjectNuget()
        {
            this.ArrayArrayObject = (RecordOfEmployee[][])XML_SharpSerializer.Deserialize(FileStr);
            
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
    }
}
