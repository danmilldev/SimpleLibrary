using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrary
{
    public class Reader
    {
        public string ReaderName { get; set; }
        public List<Book> Books = new();

        public Reader(string readerName)
        {
            this.ReaderName = readerName;
        }
    }
}
