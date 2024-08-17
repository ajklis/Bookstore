using BookstoreAPI.Common.Models;

namespace BookstoreAPI.Contracts
{
    public interface IDatabaseAccess
    {
        public Task<List<Book>> GetAllBooks();
    }
}
