using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.DataTransferObjects.Responses
{
    public class BookDisplayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; } = "https://loremflickr.com/320/240";

    }
}
