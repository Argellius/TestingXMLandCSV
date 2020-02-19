using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayArrayObject
{
    class XML_ArrayArrayObjectFile : Tools, ITester
    {
        private RecordOfEmployee[][] ArrayArrayObject;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;

        public XML_ArrayArrayObjectFile(int NumberOfElements)
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
        public void XML_SerializeArrayArrayObjectFile()
        {
            XmlSerializer.Serialize(base.StreamWriter, ArrayArrayObject);
        }

        public void XML_DeSerializeArrayArrayObjectFile()
        {
            ArrayArrayObject = (RecordOfEmployee[][])XmlSerializer.Deserialize(base.StreamReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayArrayObject.GetType());
            base.ToolsInicializeStream(this.GetType(), true);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeStream(this.GetType(), false);
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndFile(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndFile(false);
        }
        void ITester.TestWrite()
        {
            XML_SerializeArrayArrayObjectFile();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayArrayObjectFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
