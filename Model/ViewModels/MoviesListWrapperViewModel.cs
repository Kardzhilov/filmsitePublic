using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class MoviesListWrapperViewModel
    {
        public List<MovieViewModel> Movies { get; set; }
        public string SearchText { get; set; }
    }
}
