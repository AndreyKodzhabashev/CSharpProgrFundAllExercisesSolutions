using System;

namespace Ex08_Pr06_BookLibraryModification
{
    class Book
    {

        public Book(string name, string author, string publisher, DateTime dateOfPublishing, string iSBN, decimal price)
        {
           this.Name = name;
           this.Author = author;
           this.Publisher = publisher;
           this.DateOfPublishing = dateOfPublishing;
           this.ISBN = iSBN;
           this.Price = price;
        }

        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime DateOfPublishing { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }

    }
}