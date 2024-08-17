using BookstoreAPI.Common.Database.Models;

namespace BookstoreAPI.Common.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            else if (obj is DbBook)
                return Id == (obj as DbBook).Id;
            else if (obj is Book)
                return Id == (obj as Book).Id;
            else
                return false;
        }

        public Book(int id, string title, List<Author> authors)
        {
            Id = id;
            Title = title;
            Authors = authors;
        }

        public Book(int id, string title, Author author)
        {
            Id = id;
            Title = title;
            Authors = new List<Author>() { author };
        }
    }
}
