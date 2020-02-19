using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ListListObject
{
    class XML_ListListObjectFile : Tools, ITester
    {
        private List<List<RecordOfEmployee>> ListListObject;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;
        public XML_ListListObjectFile(int NumberOfElements)
        {
            this.pocetKolekci = (int)Math.Sqrt(NumberOfElements);
            this.pocetPrvkuVKolekci = NumberOfElements / pocetKolekci;
            this.pocetPrvkuVPosledniKolekci = NumberOfElements % pocetKolekci;
        }

        private void Inicialize(bool Write)
        {
            ListListObject = new List<List<RecordOfEmployee>>();

            if (Write)
            {
                List<RecordOfEmployee> List_Object = new List<RecordOfEmployee>();
                for (int i = 0; i < pocetPrvkuVKolekci; i++)
                    List_Object.Add(new RecordOfEmployee(true));

                for (int i = 0; i < pocetKolekci; i++)
                    ListListObject.Add(new List<RecordOfEmployee>(List_Object));
                List_Object.Clear();
                if (pocetPrvkuVPosledniKolekci > 0)
                {
                    for (int i = 0; i < pocetPrvkuVPosledniKolekci; i++)
                        List_Object.Add(new RecordOfEmployee(true));
                    ListListObject.Add(new List<RecordOfEmployee>(List_Object));
                }
            }
        }
        public void XML_SerializeListListObjectFile()
        {
            XmlSerializer.Serialize(base.StreamWriter,ListListObject);
        }

        public void XML_DeSerializeListListObjectFile()
        {
           ListListObject = (List<List<RecordOfEmployee>>)XmlSerializer.Deserialize(StreamReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ListListObject.GetType());
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
            XML_SerializeListListObjectFile();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListListObjectFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
