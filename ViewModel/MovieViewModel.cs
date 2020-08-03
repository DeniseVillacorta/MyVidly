using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? ID { get; set; }

        [StringLength(255)]
        [Display(Name = "Movie Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Released Date")]
        [Required]
        public DateTime? ReleasedDate { get; set; }

        [Display(Name = "Number of Stock")]
        [Range(1, 20)]
        [Required]
        public byte NumberOfStock { get; set; }

        public string Title
        {
            get
            {
                return ID != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieViewModel()
        {
            ID = 0;
        }

        public MovieViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleasedDate = movie.ReleasedDate;
            NumberOfStock = movie.NumberOfStock;
        }
    }
}
