using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Models
{
    public class Producer
    {

        [Key]
        public int Id { get; set; }
        public string ProfilPictureUrl { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        public List<Movies> Movies { get; set; }
    }
}
