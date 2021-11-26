using E_Cinema.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Models
{
    public class Producer : IEntityBase
    {

        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile")]
        [Required(ErrorMessage = "Profil is required")]
        public string ProfilPictureUrl { get; set; }
        [Display(Name = "FullName")]
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        public List<Movies> Movies { get; set; }
    }
}
