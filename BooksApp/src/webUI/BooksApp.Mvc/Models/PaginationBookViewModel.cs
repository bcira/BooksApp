using BooksApp.DataTransferObjects.Responses;
namespace BooksApp.Mvc.Models
{
    public class PaginationBookViewModel
    {

        public IEnumerable<BookDisplayResponse> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
