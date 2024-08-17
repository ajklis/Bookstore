using BookstoreAPI.Common.Database.Models;
using BookstoreAPI.Common.Models;
using BookstoreAPI.Contracts;
using Dapper;
using System.Data.SqlClient;

namespace BookstoreAPI.Services
{
    public class DatabaseAccess : IDatabaseAccess
    {
        private readonly string _connectionString;
        private readonly ILogger<DatabaseAccess> _logger;

        public DatabaseAccess(IConfiguration configuration, ILogger<DatabaseAccess> logger)
        {
            _connectionString = configuration["ConnectionString"];
            _logger = logger;
        }
        
        public async Task<List<Book>> GetAllBooks()
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            var dbBooks = await con.QueryAsync<DbBook>("SELECT b.Id, b.Title, a.NameString as AuthorNameString" +
                "FROM dbo.Books AS b" +
                "RIGHT JOIN dbo.BookAuthors AS ba ON b.Id = ba.BookId" +
                "RIGHT JOIN dbo.Authors AS a on ba.AuthorId = a.Id");
            var books = new List<Book>();
            foreach (var book in dbBooks)
            {
                if (books.Select(x => x.Id).Contains(book.Id))
                    books.Where(x => x.Id == book.Id).First().Authors.Add(Author.FromNameString(book.AuthorNameString));
                else
                    books.Add(new Book(book.Id, book.Title, Author.FromNameString(book.AuthorNameString)));
            }
            return books;
        }
    }
}
