using Polenter.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ListListInteger
{

    class XML_ListListIntegerNuget : Tools, ITester
    {
        private List<List<System.Int32>> ListListInteger;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;
        private SharpSerializer XML_SharpSerializer;

        public XML_ListListIntegerNuget()
        {
            this.pocetKolekci = 0;
            this.pocetPrvkuVKolekci = 0;
            this.pocetPrvkuVPosledniKolekci = 0;
            XML_SharpSerializer = new SharpSerializer(false);
        }

        private void Inicialize(bool Write)
        {
            ListListInteger = new List<List<System.Int32>>();
            if (Write)
            {
                List<int> ListInteger = new List<int>();
                for (int i = 0; i < pocetPrvkuVKolekci; i++)
                    ListInteger.Add(System.Int32.MaxValue);

                for (int i = 0; i < pocetKolekci; i++)
                    ListListInteger.Add(new List<int>(ListInteger));
                ListInteger.Clear();
                if (pocetPrvkuVPosledniKolekci > 0)
                {
                    for (int i = 0; i < pocetPrvkuVPosledniKolekci; i++)
                        ListInteger.Add(Int32.MaxValue);
                    ListListInteger.Add(new List<int>(ListInteger));
                }

            }
        }
        public void XML_SerializeListListIntegerNuget()
        {
           
            XML_SharpSerializer.Serialize(ListListInteger, FileStr);
            
        }

        public void XML_DeSerializeListListIntegerNuget()
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
            XML_SerializeListListIntegerNuget();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListListIntegerNuget();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.pocetKolekci = (int)Math.Sqrt(NumberOfElements);
            this.pocetPrvkuVKolekci = NumberOfElements / pocetKolekci;
            this.pocetPrvkuVPosledniKolekci = NumberOfElements % pocetKolekci;
        }

    }
}
