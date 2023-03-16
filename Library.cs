using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrary
{
    public class Library
    {
        public List<Book> books = new();

        public List<Reader> readers = new();

        //BookMethods
        public void AddBook(string bookName)
        {
            books.Add(new Book(bookName));
        }

        public void RemoveBook(string bookName)
        {
            books.Remove(books.Where(book => book.BookName.Equals(bookName)).First());
        }

        //ReaderMethods

        public void ShowAllReaders()
        {
            Console.WriteLine("-------Readers--------");
            foreach (Reader reader in readers)
            {
                Console.WriteLine("Name\t\tBooks"); //Headers
                Console.WriteLine(reader.ReaderName + "\t\t" + reader.Books); //information
            }
            Console.WriteLine("-------Readers--------");
        }

        public void CreateReader(string readerName)
        {
            readers.Add(new Reader(readerName));
        }

        public void RemoveReader(string readerName)
        {
            readers.Remove(readers.Where(reader => reader.ReaderName.Equals(readerName)).First());
        }

        //Reader plus Book Methods

        public void AddBookToReader(string readerName,string bookName)
        {
            bool doesReaderExists = readers.Exists(read => read.ReaderName == readerName);
            bool doesBookExists = books.Exists(book => book.BookName == bookName);

            if(doesReaderExists && doesBookExists)
            {
                var book = books.Where(boo => boo.BookName == bookName).First();

                if(book.IsOwned == false)
                {
                    var reader = readers.Where(read => read.ReaderName == readerName).First();
                    reader.Books.Add(book);
                }
                else
                {
                    Console.WriteLine("Book is already borrowed.");
                }
            }
        }
    }
}
