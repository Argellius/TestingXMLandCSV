using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListInteger
{
    class CSV_ListIntegerString : Tools, ITester
    {
        private List<System.Int32> ListInteger;
        private int Number;


        public CSV_ListIntegerString(int Number)
        {
            this.Number = Number;
        }

        private void Inicialize(bool Write)
        {
            ListInteger = new List<Int32>();
            if (Write)
                for (int i = 0; i < Number; i++)
                    ListInteger.Add(int.MaxValue);

        }

        public void CSV_WriteListIntegerString()
        {
            StringBuilder.AppendLine("Integer");
            foreach (int it in ListInteger)
            {
                StringBuilder.AppendLine(it.ToString());
            }
            StringWriter.Write(StringBuilder);
        }
        public void CSV_ReadListIntegerString()
        {
            //read header
            StringReader.ReadLine();

            //read records
            //try catch bool, int exc
            while (StringReader.Peek() > 0)
            {
                var line = StringReader.ReadLine();
                ListInteger.Add(Convert.ToInt32(line));

            }
        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
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
            CSV_WriteListIntegerString();
        }
        void ITester.TestRead()
        {
            CSV_ReadListIntegerString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
    }
}
