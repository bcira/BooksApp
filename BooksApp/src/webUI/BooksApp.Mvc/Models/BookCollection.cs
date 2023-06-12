using BooksApp.DataTransferObjects.Responses;

namespace BooksApp.Mvc.Models
{
    public class BookCollection
    {
        public List<BookItem> BookItems { get; set; } = new List<BookItem>();

        public void ClearAll() => BookItems.Clear();
        public decimal TotalBookPrice() => BookItems.Sum(item => (decimal)item.Book.Price * item.Quantity);

        public int TotalBooksCount() => BookItems.Sum(p => p.Quantity);

        public void AddNewBook(BookItem bookItem)
        {
            var exists = BookItems.FirstOrDefault(b => b.Book.Id == bookItem.Book.Id);
            if (exists != null)
            {
                
                exists.Quantity += bookItem.Quantity;
            }
            else
            {
                BookItems.Add(bookItem);
            }

        }

    }

    public class BookItem
    {
        public BookDisplayResponse Book { get; set; }
        public int Quantity { get; set; }
        public bool? ApplyCoupon { get; set; }

    }
}

