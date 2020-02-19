using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace.ArrayArrayInteger
{
    class XML_ArrayArrayIntegerString : Tools, ITester
    {
        private System.Int32[][] ArrayArray_Integer;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;

        public XML_ArrayArrayIntegerString(int NumberOfElements)
        {
            this.pocetKolekci = (int)Math.Sqrt(NumberOfElements);
            this.pocetPrvkuVKolekci = NumberOfElements / pocetKolekci;
            this.pocetPrvkuVPosledniKolekci = NumberOfElements % pocetKolekci;
        }

        private void Inicialize(bool Write)
        {
            if (pocetPrvkuVPosledniKolekci > 0)
            {
                ArrayArray_Integer = new Int32[this.pocetKolekci + 1][];

                for (int i = 0; i < pocetKolekci; i++)
                    ArrayArray_Integer[i] = new int[pocetPrvkuVKolekci];
                ArrayArray_Integer[pocetKolekci] = new int[pocetPrvkuVPosledniKolekci];
            }
            else
            {
                ArrayArray_Integer = new Int32[this.pocetKolekci][];

                for (int i = 0; i < pocetKolekci; i++)
                    ArrayArray_Integer[i] = new int[pocetPrvkuVKolekci];
            }

            if (Write)
            {
                for (int j = 0; j < pocetKolekci; j++)
                    for (int i = 0; i < pocetPrvkuVKolekci; i++)
                        ArrayArray_Integer[j][i] = int.MaxValue;
                if (pocetPrvkuVPosledniKolekci > 0)
                {
                    for (int j = 0; j < pocetPrvkuVPosledniKolekci; j++)
                        ArrayArray_Integer[pocetKolekci][j] = int.MaxValue;
                }

            }
        }
        public void XML_SerializeArrayArray_IntegerString()
        {
            XmlSerializer.Serialize(base.StringWriter, ArrayArray_Integer);
        }

        public void XML_DeSerializeArrayArray_IntegerString()
        {
            ArrayArray_Integer = (Int32[][])XmlSerializer.Deserialize(base.StringReader);
        }

        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            XmlSerializer = new XmlSerializer(ArrayArray_Integer.GetType(), new Type[] { typeof(int) });
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
            XML_SerializeArrayArray_IntegerString();
        }
        void ITester.TestRead()
        {
            XML_DeSerializeArrayArray_IntegerString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
    }
}
