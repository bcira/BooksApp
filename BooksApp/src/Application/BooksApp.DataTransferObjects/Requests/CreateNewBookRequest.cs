using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.DataTransferObjects.Requests
{
    public class CreateNewBookRequest
    {
        [Required(ErrorMessage = "Kitap adı boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "En az üç karakter giriniz!")]
        public string Name { get; set; }
       
        public string Author { get; set; }
        public decimal? Price { get; set; }
       
        public string ImageUrl { get; set; } = "https://loremflickr.com/320/240";
        public int? CategoryId { get; set; }
        
    }
}
