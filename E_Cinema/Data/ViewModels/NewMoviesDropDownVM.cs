using E_Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Data.ViewModels
{
    public class NewMoviesDropDownVM
    {
        public NewMoviesDropDownVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }
        public List<Producer> Producers { get; set; }

        public List<Cinema> Cinemas { get; set; }

        public List<Actor> Actors { get; set; }


    }
}
