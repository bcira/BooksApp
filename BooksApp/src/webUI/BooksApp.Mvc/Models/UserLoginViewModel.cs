using System.ComponentModel.DataAnnotations;

namespace BooksApp.Mvc.Models
{
    public class UserLoginViewModel
    {

        [Required(ErrorMessage = "Ad kısmı boş bırakılamaz!")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
