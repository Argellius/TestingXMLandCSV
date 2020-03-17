using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayArrayInteger
{
    class CSV_ArrayArrayIntegerString : Tools, ITester
    {
        private System.Int32[][] ArrayArray_Integer;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public CSV_ArrayArrayIntegerString() {
            NumberOfCollections = 0;
            ElementsInCollection = 0;
            ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            if (ElementsInLastCollection > 0)
            {
                ArrayArray_Integer = new Int32[this.NumberOfCollections + 1][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArray_Integer[i] = new int[ElementsInCollection];
                ArrayArray_Integer[NumberOfCollections] = new int[ElementsInLastCollection];
            }
            else
            {
                ArrayArray_Integer = new Int32[this.NumberOfCollections][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArray_Integer[i] = new int[ElementsInCollection];
            }

            if (Write)
            {
                for (int j = 0; j < NumberOfCollections; j++)
                    for (int i = 0; i < ElementsInCollection; i++)
                        ArrayArray_Integer[j][i] = int.MaxValue;
                if (ElementsInLastCollection > 0)
                {
                    for (int j = 0; j < ElementsInLastCollection; j++)
                        ArrayArray_Integer[NumberOfCollections][j] = int.MaxValue;
                }

            }
        }
        public void CSV_WriteArrayArrayIntegerString()
        {
            foreach (Int32[] array in ArrayArray_Integer)
            {
                foreach (var (value, index) in array.Select((v, i) => (v, i)))
                {
                    if (index != 0)
                        StringBuilder.Append(";");
                    StringBuilder.Append(value);

                }
                StringBuilder.AppendLine();
            }
            StringWriter.Write(StringBuilder);
        }

        public void CSV_ReadArrayArrayIntegerString()
        {
            int index_pole = 0;
            while (StringReader.Peek() > 0)
            {
                string line = StringReader.ReadLine();
                string[] values = line.Split(';');

                foreach (var (value, index) in values.Select((v, i) => (v, i)))
                {
                    ArrayArray_Integer[index_pole][index] = Convert.ToInt32(value);
                }
                index_pole++;
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
            CSV_WriteArrayArrayIntegerString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayArrayIntegerString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile();
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }
    }
}
