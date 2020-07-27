using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Orion.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        public byte GenreId { get; set; }
        public int NumberInStock { get; set; }
        public DateTime PublishedDate { get; set; }

    }
}