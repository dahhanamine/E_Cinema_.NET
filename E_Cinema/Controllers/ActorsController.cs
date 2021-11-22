using E_Cinema.Data;
using E_Cinema.Data.Services;
using E_Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;      
        }


        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilPictureUrl,FullName,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
             await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails =  await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id )
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id , [Bind("Id,ProfilPictureUrl,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id , actor);
            return RedirectToAction(nameof(Index));

        }

    }
}
