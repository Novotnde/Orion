using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orion.Dtos
{
    public class BookRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> BooksIds { get; set; }
    }
}