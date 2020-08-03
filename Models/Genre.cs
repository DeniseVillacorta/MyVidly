using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        public string GenreName { get; set; }
    }
}