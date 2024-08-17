namespace BookstoreAPI.Common.Database.Models
{
    public class DbBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorNameString { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not DbBook)
                return false;

            var book = obj as DbBook;
            return Id == book.Id;
        }
    }
}
