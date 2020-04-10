using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayArrayObject
{
    class CSV_ArrayArrayObjectCSVHelperString : Tools, ITester
    {
        private EmployeeRecord[][] ArrayArrayObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public CSV_ArrayArrayObjectCSVHelperString() {
            NumberOfCollections = 0;
            ElementsInCollection = 0;
            ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            if (ElementsInLastCollection > 0)
            {
                ArrayArrayObject = new EmployeeRecord[this.NumberOfCollections + 1][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArrayObject[i] = new EmployeeRecord[ElementsInCollection];
                ArrayArrayObject[NumberOfCollections] = new EmployeeRecord[ElementsInLastCollection];
            }
            else
            {
                ArrayArrayObject = new EmployeeRecord[this.NumberOfCollections][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArrayObject[i] = new EmployeeRecord[ElementsInCollection];
            }

            if (Write)
            {
                for (int j = 0; j < NumberOfCollections; j++)
                    for (int i = 0; i < ElementsInCollection; i++)
                        ArrayArrayObject[j][i] = new EmployeeRecord(true);
                if (ElementsInLastCollection > 0)
                {
                    for (int j = 0; j < ElementsInLastCollection; j++)
                        ArrayArrayObject[NumberOfCollections][j] = new EmployeeRecord(true);
                }

            }
        }

        public void CSV_WriteArrayArrayObjectCSVHelperString()
        {
            foreach (EmployeeRecord[] record in ArrayArrayObject)
            {
                csvWriter.WriteRecords<EmployeeRecord>(record);
                csvWriter.NextRecord();
            }
        }
        public void CSV_ReadArrayArrayObjectCSVHelperString()
        {
            int index_pole = 0;
            int i = 0;

            while (csvReader.Read())
            {
                if (csvReader.Context.Record.Count() == 0) //------
                {
                    index_pole++;
                    i = 0;
                    continue;
                }
                ArrayArrayObject[index_pole][i] = csvReader.GetRecord<EmployeeRecord>();
                i++;
            }

        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            base.ToolsInicializeString(true);
            csvWriter = new CsvWriter(base.StringWriter, CultureInfo.InvariantCulture);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeString(false, StringData);
            csvReader = new CsvReader(StringReader, CultureInfo.InvariantCulture);
            csvReader.Configuration.IgnoreBlankLines = false;
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndString(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndString(false);
            ArrayArrayObject = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayArrayObjectCSVHelperString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayArrayObjectCSVHelperString();
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

        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
