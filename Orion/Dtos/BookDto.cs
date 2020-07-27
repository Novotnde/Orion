using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Orion.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        public GenreDto Genre { get; set; }
        public byte GenreId { get; set; }
        public int NumberInStock { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}