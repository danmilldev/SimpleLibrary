using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrary
{
    public class Book
    {
        public string BookName { get; set; }
        public bool IsOwned { get; set; } = false;

        public Book(string bookNname)
        {
            this.BookName = bookNname;
        }
    }
}
