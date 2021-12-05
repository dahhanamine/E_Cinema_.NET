using E_Cinema.Data;
using E_Cinema.Data.Services;
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


        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n=>n.Cinema);
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


    }
}
