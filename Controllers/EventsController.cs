using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEMA.Data;
using SEMA.Dto;
using SEMA.Entities;
using SEMA.Services;

namespace SEMA.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventAppService _eventAppService;


        public EventsController(IEventAppService eventAppService)
        {
            _eventAppService = eventAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _eventAppService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _eventAppService.GetByIdAsync(id.Value);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        public async Task<IActionResult> CreateOrUpdateAsync(int? id)
        {
            var model = new EventDto();
            if (id == null || id == 0)
            {
                model.Date = DateTime.Now;
                return View(model);
            }
            model = await _eventAppService.GetByIdAsync(id.Value);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdateAsync(EventDto eventDto)
        {

            if (ModelState.IsValid)
            {
                await _eventAppService.CreateOrUpdateAsync(eventDto);

                return RedirectToAction("Index", "Home");
            }
            return View(eventDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _eventAppService.GetByIdAsync(id.Value);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventAppService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            if (id==0)
            {
                return NotFound();
            }
            await _eventAppService.ChangeStatus(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
