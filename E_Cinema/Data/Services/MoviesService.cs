using E_Cinema.Data.Base;
using E_Cinema.Data.ViewModels;
using E_Cinema.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movies>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context) {

            _context = context;
        }

        public async Task<NewMoviesDropDownVM> GetDropDownValues()
        {
            var response = new NewMoviesDropDownVM();
            response.Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync();
            response.Cinemas = await _context.Cinemas.OrderBy(c => c.Name).ToListAsync();
            response.Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync();

               return response;
        }

        public async Task<Movies> GetMoviesByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
       
        }
    }
}
