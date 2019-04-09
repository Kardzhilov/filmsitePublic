using filmsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filmsite.Utilities
{
    public static class ListUtilities
    {
        public static List<Movie> SuffleMovies(List<Movie> movies)
        {
            List<Movie> randomList = new List<Movie>();
            Random r = new Random();
            int randomIndex = 0;
            while (movies.Count > 0)
            {
                randomIndex = r.Next(0, movies.Count);
                randomList.Add(movies[randomIndex]);
                movies.RemoveAt(randomIndex);
            }

            return randomList;
        }
    }
}