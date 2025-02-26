using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class SortedBooksDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ShelfName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
