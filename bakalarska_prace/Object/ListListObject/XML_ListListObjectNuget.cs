using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bakalarska_prace.ListListObject
{
    class XML_ListListObjectNuget : Tools, ITester
    {
        private List<List<RecordOfEmployee>> ListListObject;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;
        private SharpSerializer XML_SharpSerializer;
        public XML_ListListObjectNuget()
        {
            this.pocetKolekci = 0;
            this.pocetPrvkuVKolekci = 0;
            this.pocetPrvkuVPosledniKolekci = 0;
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

        public void XML_SerializeListListObjectNuget()
        {
            XML_SharpSerializer.Serialize(ListListObject, FileStr);
        }

        public void XML_DeSerializeListListObjectNuget()
        {
            ;
            ListListObject = XML_SharpSerializer.Deserialize(FileStr) as List<List<RecordOfEmployee>>;           
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
            XML_SerializeListListObjectNuget();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeListListObjectNuget();
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
