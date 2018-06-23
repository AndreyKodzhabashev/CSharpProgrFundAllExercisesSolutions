using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ex08_Pr06_BookLibraryModification
{
    class Ex08_Pr06_BookLibraryModification
    {
        // 100/100
        static void Main()
        {

            Library library = new Library("Fantasy");

            int booksCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < booksCount; i++)
            {
                string[] currentBook = Console.ReadLine().Split();

                string bookName = currentBook[0];
                string bookAutor = currentBook[1];
                string bookPublisher = currentBook[2];
                DateTime bookDate = DateTime.ParseExact(currentBook[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string bookISBN = currentBook[4];
                decimal bookPrice = decimal.Parse(currentBook[5]);

                Book book = new Book(bookName, bookAutor, bookPublisher, bookDate, bookISBN, bookPrice);

                library.Books.Add(book);
            }

            DateTime markDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            List<Book> sorted = library.Books.Where(x => x.DateOfPublishing > markDate).OrderBy(x => x.DateOfPublishing).ThenBy(x => x.Name).ToList();

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Name} -> {item.DateOfPublishing.ToString("dd.MM.yyyy")}");
            }

        }
    }
}