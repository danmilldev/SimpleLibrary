using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
            Console.WriteLine(bookName + " was Successfully created.");
        }

        public void RemoveBook(string bookName)
        {
            books.Remove(books.Where(book => book.BookName.Equals(bookName)).First());
            Console.WriteLine(bookName + " was Successfully removed.");
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("-------Books--------");
            foreach (var book in books)
            {
                Console.WriteLine("BookName\t\tIsOwned"); //Headers
                Console.WriteLine(book.BookName + "\t\t" + book.IsOwned); //information
            }
            Console.WriteLine("-------Books--------");
        }

        //ReaderMethods

        public void ShowAllReaders()
        {

            Console.WriteLine("-------Readers--------");
            foreach (var reader in readers)
            {
                Console.WriteLine("ReaderName: " + reader.ReaderName);
                Console.WriteLine("------Books borrowd list-------");
                foreach (var book in reader.Books)
                {
                    Console.Write(book.BookName + ", "); //information
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------Readers--------");
        }

        public void CreateReader(string readerName)
        {
            readers.Add(new Reader(readerName));
            Console.WriteLine(readerName + " was Successfully created.");
        }

        public void RemoveReader(string readerName)
        {
            readers.Remove(readers.Where(reader => reader.ReaderName.Equals(readerName)).First());
            Console.WriteLine(readerName + " was Successfully removed.");
        }

        //Reader plus Book Methods

        public void AddBookToReader(string readerName,string bookName)
        {
            bool doesReaderExists = readers.Exists(read => read.ReaderName == readerName);
            bool doesBookExists = books.Exists(book => book.BookName == bookName);

            Console.WriteLine("Checked and going forward..." + "name exists?: " + doesReaderExists + "book exists?: " + doesBookExists);
            if(doesReaderExists && doesBookExists)
            {
                var book = books.Where(boo => boo.BookName == bookName).First();

                if(book.IsOwned == false)
                {
                    var reader = readers.Where(read => read.ReaderName == readerName).First();
                    book.IsOwned = true;
                    reader.Books.Add(book);
                    Console.WriteLine("Book Was succefully Added to user.");
                }
                else
                {
                    Console.WriteLine("Book is already borrowed.");
                }
            }
        }
    }
}
