using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Movie
    {

        public int ID { get; set; }

        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        [RegularExpression("^[A-Z]+[a-zA-Z]*$")]
        [Required]
        public string Genre { get; set; }

        
        public decimal Price { get; set; }

        [RegularExpression("^[A-Z]+[a-zA-Z]*$")]
        [Required]
        public string Rating { get; set; }
    }
}
