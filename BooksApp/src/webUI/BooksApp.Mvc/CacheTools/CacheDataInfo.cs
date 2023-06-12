using BooksApp.DataTransferObjects.Responses;

namespace BooksApp.Mvc.CacheTools
{
    public class CacheDataInfo
    {
        public IEnumerable<BookDisplayResponse> Books { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
