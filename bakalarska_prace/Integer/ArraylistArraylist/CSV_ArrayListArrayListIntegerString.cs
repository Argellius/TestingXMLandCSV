using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListArrayListInteger
{
    class CSV_ArrayListArrayListIntegerString : Tools, ITester
    {
        private ArrayList ArrayListArrayListInteger;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;


        public CSV_ArrayListArrayListIntegerString()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayListArrayListInteger = new ArrayList();

            if (Write)
            {
                ArrayList ArrayListIntreger = new ArrayList();
                for (int i = 0; i < ElementsInCollection; i++)
                    ArrayListIntreger.Add(System.Int32.MaxValue);

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayListArrayListInteger.Add(new ArrayList(ArrayListIntreger));
                ArrayListIntreger.Clear();
                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        ArrayListIntreger.Add(Int32.MaxValue);
                    ArrayListArrayListInteger.Add(new ArrayList(ArrayListIntreger));
                }

            }
        }

        public void CSV_WriteArrayListArrayListIntegerString()
        {
            foreach (ArrayList list in ArrayListArrayListInteger)
            {
                int count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    StringBuilder.Append(list[i]);
                    if (i + 1 < count)
                        StringBuilder.Append(";");
                }
                StringBuilder.AppendLine();
            }
            StringWriter.Write(StringBuilder);
        }

        public void CSV_ReadArrayListArrayListIntegerString()
        {
            while (StringReader.Peek() > 0)
            {
                string line = StringReader.ReadLine();                
                ArrayListArrayListInteger.Add(new ArrayList(Array.ConvertAll(line.Split(';'), int.Parse)));
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
            ArrayListArrayListInteger = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayListArrayListIntegerString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayListArrayListIntegerString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }
    }
}
