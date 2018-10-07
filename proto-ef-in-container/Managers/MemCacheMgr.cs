using proto_ef_in_container.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proto_ef_in_container.Managers
{
    public class MemCacheMgr
    {
        public List<Book> bookCache = new List<Book>();

        public MemCacheMgr()
        {
            bookCache.AddRange( new Book[] {
                new Book { ISDN = 1, Name = "Book 1" },
                new Book { ISDN = 2, Name = "Book 2" }
            });
        }
    }
}
