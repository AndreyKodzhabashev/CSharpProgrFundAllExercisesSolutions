using System;
using System.Collections.Generic;
using System.Text;

namespace Ex08_Pr06_BookLibraryModification
{
    class Library
    {
        public Library(string name)
        {
            this.Name = name;
            this.Books = new List<Book>();
        }

        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
