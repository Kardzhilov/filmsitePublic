﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filmsite.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public float ImdbRating { get; set; }
        public string ScreenShot { get; set; }
    }
}