using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ListListObject
{
    class XML_ListListObjectString : Tools, ITester
    {
        private List<List<RecordOfEmployee>> ListListObject;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;
        public XML_ListListObjectString(int NumberOfElements)
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

        public void XML_SerializeListListObjectString()
        {
            XmlSerializer.Serialize(StringWriter, ListListObject);
        }

        public void XML_DeSerializeListListObjectString()
        {
            ListListObject = (List<List<RecordOfEmployee>>)XmlSerializer.Deserialize(StringReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ListListObject.GetType());
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
            XML_SerializeListListObjectString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListListObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
    }
}
