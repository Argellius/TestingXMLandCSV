using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListListInteger
{
    class CSV_ListListIntegerFile : Tools, ITester
    {
        private List<List<System.Int32>> ListListInteger;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public CSV_ListListIntegerFile()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ListListInteger = new List<List<System.Int32>>();

            if (Write)
            {
                List<int> ListInteger = new List<int>();
                for (int i = 0; i < ElementsInCollection; i++)
                    ListInteger.Add(System.Int32.MaxValue);

                for (int i = 0; i < NumberOfCollections; i++)
                    ListListInteger.Add(new List<int>(ListInteger));
                ListInteger.Clear();
                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        ListInteger.Add(Int32.MaxValue);
                    ListListInteger.Add(new List<int>(ListInteger));
                }                
            }
        }
        public void CSV_WriteListListIntegerFile()
        {
            foreach (List<Int32> list in ListListInteger)
            {
                foreach (var (value, index) in list.Select((v, i) => (v, i)))
                {
                    if (index != 0)
                        StringBuilder.Append(";");
                    StringBuilder.Append(value);

                }
                StringBuilder.AppendLine();
            }
            StreamWriter.Write(StringBuilder);
        }
        public void CSV_ReadListListIntegerFile() 
        {
            while (StreamReader.Peek() > 0)
            {
                string line = StreamReader.ReadLine();
                ListListInteger.Add(line.Split(';').ToList().ConvertAll(int.Parse));                                
            }
            
        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            base.ToolsInicializeFile(this.GetType(), true);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeFile(this.GetType(), false);
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndFile(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndFile(false);
            ListListInteger = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteListListIntegerFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadListListIntegerFile();
            
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }
    }
}
