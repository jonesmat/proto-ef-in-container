using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proto_ef_in_container.Model
{
    public class Book
    {
        public int ISDN { get; set; }
        public string Name { get; set; }
        
        public override bool Equals(object other)
        {
            if (!(other is Book))
                return false;

            var otherBook = (Book)other;

            if (ISDN == otherBook.ISDN &&
                Name == otherBook.Name)
            {
                return true;
            }

            return false;
        }
    }
}
