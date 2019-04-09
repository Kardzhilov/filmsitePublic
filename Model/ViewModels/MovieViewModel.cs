using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        public string Rated { get; set; }

        public string Runtime { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        public string Director { get; set; }

        [Required(ErrorMessage = "Plot is required")]
        public string Plot { get; set; }

        [Required(ErrorMessage = "Poster is required")]
        public string Poster { get; set; }

        [Display(Name = "Imdb Rating")]
        public string ImdbRating { get; set; }

        [Required(ErrorMessage = "Screen Shot is required")]
        [Display(Name = "Screen Shot")]
        public string ScreenShot { get; set; }
    }
}
