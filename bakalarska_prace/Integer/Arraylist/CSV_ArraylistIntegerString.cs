using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListInteger
{
    class CSV_ArrayListIntegerString : Tools, ITester
    {
        private ArrayList ArrayListInteger;
        private int NumberOfElements;

        public CSV_ArrayListIntegerString()
        {           
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool write)
        {
            ArrayListInteger = new ArrayList();

            if (write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListInteger.Add(int.MaxValue);
        }
        public void CSV_WriteArraylistIntegerString()
        {
            StringBuilder.AppendLine("Integer");
            foreach (int it in ArrayListInteger)
            {
                StringBuilder.AppendLine(it.ToString());
            }
            StringWriter.Write(StringBuilder);
        }

        public void CSV_ReadArraylistIntegerString()
        {
            //read header
            StringReader.ReadLine();

            //read records
            //try catch bool, int exc
            while (StringReader.Peek() > 0)
            {
                var line = StringReader.ReadLine();
                ArrayListInteger.Add(Convert.ToInt32(line));

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
            ArrayListInteger = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteArraylistIntegerString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArraylistIntegerString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
