using LearningMVC.Models;
using LearningMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly EventRepository _eventRepository = null;

        public EventController(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }


        public async Task<ViewResult> GetAllEvents()
        {
            var data = await _eventRepository.GetAllEvents();
            return View(data);
        }

      /*  [Route("eventdetails/{id}",Name ="eventDetailsRoute")]
        public async Task<ViewResult> GetEvent(int id)
        {
            var data= await _eventRepository.GetEventById(id);
            return View(data);
        }
      */

       
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult CreateEvent(bool isSuccess=false,int eventId=0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.EventId = eventId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventModel eventModel)
        {
           int id= await _eventRepository.CreateNewEvent(eventModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(CreateEvent),new { isSuccess = true,eventId=id });
            }
            return View();
        }
    }
}
