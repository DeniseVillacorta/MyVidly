using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Released Date")]
        public DateTime ReleasedDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number of Stock")]
        public byte NumberOfStock { get; set; }
    }
}