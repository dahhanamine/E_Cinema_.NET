using E_Cinema.Data;
using E_Cinema.Data.Services;
using E_Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Controllers
{
    public class ProducersController : Controller
    {

        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }


        public async Task<IActionResult>  Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ProducerDetails = await _service.GetByIdAsync(id);
            if (ProducerDetails == null) return View("NotFound");
             return View(ProducerDetails);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilPictureUrl,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int id )
        {
            var ProDetails = await _service.GetByIdAsync(id);
            if(ProDetails == null)return View("NotFound");
            return View(ProDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id , [Bind("Id,ProfilPictureUrl,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            
            if(id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }

            return View(producer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ProDetails = await _service.GetByIdAsync(id);
            if (ProDetails == null) return View("NotFound");
            return View(ProDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {

            var ProDetails = await _service.GetByIdAsync(id);
            if (ProDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
