﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace
{
    interface ITester
    {
        void SetupWriteStart();                                 // Test preparation (initializing a collections, stream writer, string writer ... for create file or create stringwriter)

        void SetupReadStart();                                   // Test preparation (initializing a collections, stream reader, string reader ... for read file or read stringwriter)

        void SetupWriteEnd();                                   // delete collection, close streamwriter,string writer

        void SetupReadEnd();                                    // delete collection, close streamreader,string reader

        void TestWrite();

        void TestRead();

        void SetNumberOfElements(int NumberOfElements);

        void SetPath(string path);
        long GetSize();      
    }
}
