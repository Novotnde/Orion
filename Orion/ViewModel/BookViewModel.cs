using Orion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orion.ViewModel
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}