using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ListListInteger
{
    class XML_ListListIntegerString : Tools, ITester
    {
        private List<List<System.Int32>> ListListInteger;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;

        public XML_ListListIntegerString()
        {
            this.pocetKolekci = 0;
            this.pocetPrvkuVKolekci = 0;
            this.pocetPrvkuVPosledniKolekci = 0;
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
        public void XML_SerializeListList_IntegerString()
        {
            XmlSerializer.Serialize(base.StringWriter, ListListInteger);
        }

        public void XML_DeSerializeListList_IntegerString()
        {
            
            ListListInteger = (List<List<System.Int32>>)XmlSerializer.Deserialize(base.StringReader);
            
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ListListInteger.GetType());
            base.ToolsInicializeString(true);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeString(false, base.StringData);
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndString(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndString(false);
        }
        void ITester.TestWrite()
        {
            XML_SerializeListList_IntegerString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListList_IntegerString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.pocetKolekci = (int)Math.Sqrt(NumberOfElements);
            this.pocetPrvkuVKolekci = NumberOfElements / pocetKolekci;
            this.pocetPrvkuVPosledniKolekci = NumberOfElements % pocetKolekci;
        }
    }
}
