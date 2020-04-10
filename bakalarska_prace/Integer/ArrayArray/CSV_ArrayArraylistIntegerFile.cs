﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayArrayInteger
{
    class CSV_ArrayArrayIntegerFile : Tools, ITester
    {
        private System.Int32[][] ArrayArrayInteger;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public CSV_ArrayArrayIntegerFile()
        {
            NumberOfCollections = 0;
            ElementsInCollection = 0;
            ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            if (ElementsInLastCollection > 0)
            {
                ArrayArrayInteger = new Int32[this.NumberOfCollections + 1][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArrayInteger[i] = new int[ElementsInCollection];
                ArrayArrayInteger[NumberOfCollections] = new int[ElementsInLastCollection];
            }
            else
            {
                ArrayArrayInteger = new Int32[this.NumberOfCollections][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArrayInteger[i] = new int[ElementsInCollection];
            }

            if (Write)
            {
                for (int j = 0; j < NumberOfCollections; j++)
                    for (int i = 0; i < ElementsInCollection; i++)
                        ArrayArrayInteger[j][i] = int.MaxValue;
                if (ElementsInLastCollection > 0)
                {
                    for (int j = 0; j < ElementsInLastCollection; j++)
                        ArrayArrayInteger[NumberOfCollections][j] = int.MaxValue;
                }

            }
        }
        public void CSV_WriteArrayArrayIntegerFile()
        {
            foreach (Int32[] array in ArrayArrayInteger)
            {
                foreach (var (value, index) in array.Select((v, i) => (v, i)))
                {
                    if (index != 0)
                        StringBuilder.Append(";");
                    StringBuilder.Append(value);

                }
                StringBuilder.AppendLine();
            }
            StreamWriter.Write(StringBuilder);

        }
        public void CSV_ReadArrayArrayIntegerFile()
        {
            int index_pole = 0;
            while (StreamReader.Peek() > 0)
            {
                string line = StreamReader.ReadLine();
                string[] values = line.Split(';'); // moc se mi nelíbí

                foreach (var (value, index) in values.Select((v, i) => (v, i)))
                {
                    ArrayArrayInteger[index_pole][index] = Convert.ToInt32(value);
                }
                index_pole++;
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
            ArrayArrayInteger = null;

        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayArrayIntegerFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayArrayIntegerFile();
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

        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
