using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Author { get; set; }
       
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; } = "https://www.pngwing.com/tr/free-png-npdtg";
        public int? CategoryId { get; set; }
       
        public Category? Category { get; set; }
    }
}
