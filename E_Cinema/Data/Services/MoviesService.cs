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

        public async Task AddNewMovie(NewMoviesVm data)
        {
            var newMovie = new Movies()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price ,
                ImageUrl = data.ImageUrl ,
                CinemaId = data.CinemaId ,
                StartDate = data.StartDate ,
                EndDate = data.EndDate ,
                MovieCategory = data.MovieCategory ,
                ProducerId = data.ProducerId 

            };

            await   _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();


            foreach(var actorId  in data.ActorIDs)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
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

        public async Task UpdateMovie(NewMoviesVm data)
        {

            var dbmovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbmovie != null)
            {

                dbmovie.Name = data.Name;
                dbmovie.Description = data.Description;
                dbmovie.Price = data.Price;
                dbmovie.ImageUrl = data.ImageUrl;
                dbmovie.CinemaId = data.CinemaId;
                dbmovie.StartDate = data.StartDate;
                dbmovie.EndDate = data.EndDate;
                dbmovie.MovieCategory = data.MovieCategory;
                dbmovie.ProducerId = data.ProducerId;

        
                await _context.SaveChangesAsync();

            }

            var existActor = _context.Actor_Movies.Where(n => n.ActorId == data.Id).ToList();
            _context.Actor_Movies.RemoveRange(existActor);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorIDs)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
