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

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Display(Name = "Released Date")]
        public DateTime ReleasedDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number of Stock")]
        [Range(1, 20)]
        public byte NumberOfStock { get; set; }
    }
}