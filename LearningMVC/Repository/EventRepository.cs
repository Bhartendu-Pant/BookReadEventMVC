using LearningMVC.Data;
using LearningMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVC.Repository
{
    public class EventRepository
    {
        private readonly BookReadContext _context = null;

        public EventRepository(BookReadContext context)  // Depandency injection
        {
            _context = context;
        }

        public async Task<List<EventModel>> GetAllEvents()
        {
            var events = new List<EventModel>();
            var allevents = await _context.Events.ToListAsync();
            if (allevents?.Any() == true)
            {
                foreach(var evnt in allevents)
            {
                    events.Add(new EventModel()
                    {
                        id = evnt.id,
                        Title = evnt.Title,

                        Date = evnt.Date,
                        Location = evnt.Location,

                        DurationInHours = evnt.DurationInHours,
                        Description = evnt.Description,
                        OtherDetails = evnt.OtherDetails,
                        InviteOthers = evnt.InviteOthers,

                    }) ; 
            }
            }
            return events;
        }

      /*  public async Task<EventModel> GetEventById(int id)
        {
            var evnt = await _context.Events.FindAsync(id);
            if(evnt != null)
            {
                var eventDetails = new EventModel()
                {
                    id = evnt.id,
                    Title = evnt.Title,

                    Date = evnt.Date,
                    Location = evnt.Location,
                  
                    DurationInHours = evnt.DurationInHours,
                    Description = evnt.Description,
                    OtherDetails = evnt.OtherDetails,
                    InviteOthers = evnt.InviteOthers,
                };
                return eventDetails;
;
            }
            return null;

        }
      */

       



        public async Task<int> CreateNewEvent(EventModel eventModel)
        {
            var newEvent = new Events()
            {
                id = eventModel.id,

                Title = eventModel.Title,
                Date=eventModel.Date,
                Location=eventModel.Location,
             
                DurationInHours=eventModel.DurationInHours,
                Description=eventModel.Description,
                OtherDetails=eventModel.OtherDetails,
                InviteOthers=eventModel.InviteOthers,

            };

           await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return newEvent.id;
        }
    }
}
