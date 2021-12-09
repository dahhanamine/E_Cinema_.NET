using E_Cinema.Data;
using E_Cinema.Data.Services;
using E_Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Filter(String searchString)
        {
            var allMovies = await _service.GetAllAsync(n=>n.Cinema);

            if (!String.IsNullOrEmpty(searchString))
            {
                var filterresult = allMovies.Where(n => n.Name.Contains(searchString) ||
                n.Description.Contains(searchString)).ToList();
                return View("Index", filterresult);
            }
            return View("Index", allMovies);
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMoviesByIdAsync(id);
            return View(movieDetails);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropDown = await _service.GetDropDownValues();

            ViewBag.CinemaID = new SelectList(movieDropDown.Cinemas, "Id", "Name");

            ViewBag.ProducerID = new SelectList(movieDropDown.Producers, "Id", "FullName");

            ViewBag.ActorID = new SelectList(movieDropDown.Actors, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMoviesVm newMovieVm) 
        {

            if (!ModelState.IsValid)
            {
                var movieDropDown = await _service.GetDropDownValues();

                ViewBag.CinemaID = new SelectList(movieDropDown.Cinemas, "Id", "Name");

                ViewBag.ProducerID = new SelectList(movieDropDown.Producers, "Id", "FullName");

                ViewBag.ActorID = new SelectList(movieDropDown.Actors, "Id", "FullName");
                return View(newMovieVm);
            }
            await _service.AddNewMovie(newMovieVm);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {

            var  movieDetails = await _service.GetMoviesByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMoviesVm()
            {
                Id = movieDetails.Id ,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price ,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageUrl = movieDetails.ImageUrl ,
                MovieCategory = movieDetails.MovieCategory ,
                CinemaId = movieDetails.CinemaId ,
                ProducerId = movieDetails.ProducerId ,
                ActorIDs = movieDetails.Actor_Movies.Select(n=>n.ActorId).ToList()
            };

            var movieDropDown = await _service.GetDropDownValues();

            ViewBag.CinemaID = new SelectList(movieDropDown.Cinemas, "Id", "Name");

            ViewBag.ProducerID = new SelectList(movieDropDown.Producers, "Id", "FullName");

            ViewBag.ActorID = new SelectList(movieDropDown.Actors, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id , NewMoviesVm newMovieVm)
        {
            if(id != newMovieVm.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropDown = await _service.GetDropDownValues();

                ViewBag.CinemaID = new SelectList(movieDropDown.Cinemas, "Id", "Name");

                ViewBag.ProducerID = new SelectList(movieDropDown.Producers, "Id", "FullName");

                ViewBag.ActorID = new SelectList(movieDropDown.Actors, "Id", "FullName");
                return View(newMovieVm);
            }
            await _service.UpdateMovie(newMovieVm);
            return RedirectToAction(nameof(Index));
        }

    }
}
