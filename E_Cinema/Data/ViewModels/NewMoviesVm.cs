using E_Cinema.Data;
using E_Cinema.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Models
{
    public class NewMoviesVm
    {

        
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        public List<int> ActorIDs { get; set; }

        public int CinemaId { get; set; }
    

         
        public int ProducerId { get; set; }
       

    }
}
