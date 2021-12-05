using E_Cinema.Data.Base;
using E_Cinema.Data.ViewModels;
using E_Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<Movies>
    {
        Task<Movies> GetMoviesByIdAsync(int id);
        Task<NewMoviesDropDownVM> GetDropDownValues();
    }
}
