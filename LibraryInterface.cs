using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrary
{
    public class LibraryInterface
    {
        Library library;

        public LibraryInterface()
        {
            library = new Library();
        }

        bool shouldMenuRunning = true;

        public void Menu()
        {
            while (shouldMenuRunning)
            {
                Console.WriteLine("---Library---");
                Console.WriteLine("\t1.Create User.");
                Console.WriteLine("\t2.Delete User.");
                Console.WriteLine("\t3.Create Book.");
                Console.WriteLine("\t4.Delete Book.");
                Console.WriteLine("\t5.Add Book to User.");
                Console.WriteLine("\t6.Show All Readers");
                Console.WriteLine("\t7.Show All Books");
                Console.WriteLine("\t10.Exit.");

                Console.Write("Input:");

                int input;

                bool isValidInput = int.TryParse(Console.ReadLine(), out input);

                if (isValidInput)
                {
                    switch (input)
                    {
                        case 1:
                            UseMethods("ReaderName", library.CreateReader);
                            break;
                        case 2:
                            UseMethods("ReaderName", library.RemoveReader);
                            break;
                        case 3:
                            UseMethods("BookName", library.AddBook);
                            break;
                        case 4:
                            UseMethods("BookName", library.RemoveBook);
                            break;
                        case 5:
                            UseExtendedMethods(library.AddBookToReader);
                            break;
                        case 6:
                            Console.Clear();
                            library.ShowAllReaders();
                            break;
                        case 7:
                            library.ShowAllBooks();
                            break;
                        case 10:
                            shouldMenuRunning = false;
                            break;
                    }
                }
                else if (!isValidInput)
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid Input.");
                }
            }
        }

        void UseMethods(string inputString, Action<string> method)
        {
            Console.Clear();

            string objectName = inputString;
            Console.Write(inputString + ": ");
            inputString = Console.ReadLine().TrimEnd();
            method(inputString);

            Console.WriteLine(objectName + " with name " + inputString + " Successfully created.");
        }
        void UseExtendedMethods(Action<string,string> method)
        {
            Console.Clear();

            Console.Write("ReaderName: ");
            string readerName = Console.ReadLine().TrimEnd();

            Console.Write("BookName: ");
            string bookName = Console.ReadLine().TrimEnd();

            if(!String.IsNullOrEmpty(bookName) && !String.IsNullOrEmpty(readerName))
            {
                method(readerName, bookName);
            }
        }
    }
}
