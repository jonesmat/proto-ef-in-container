using proto_ef_in_container.Managers;
using proto_ef_in_container.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proto_ef_in_container.Managers
{
    public class BooksManager
    {
        private MemCacheMgr memCacheMgr;

        private List<Book> books;

        public BooksManager(MemCacheMgr memCacheMgr)
        {
            this.memCacheMgr = memCacheMgr;

            books = memCacheMgr.bookCache;
        }
    
        public async Task<List<Book>> GetBooks()
        {
            return books;
        }

        public async Task<Book> GetBookByISDN(int ISDN)
        {
            List<Book> books = await GetBooks();

            Book book = books.Where(b => b.ISDN == ISDN).FirstOrDefault();
            return book;
        }

        public async Task<bool> DoesBookExist(Book book)
        {
            List<Book> books = await GetBooks();

            int count = books.Where(b => b == book).Count();
            return count > 0;
        }

        public async Task<Book> AddBook(Book book)
        {
            List<Book> books = await GetBooks();
            books.Add(book);

            return book;
        }
    }
}
