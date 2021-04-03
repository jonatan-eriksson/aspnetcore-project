using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aspnetcore_project.Data;
using aspnetcore_project.Models;

namespace aspnetcore_project.Pages
{
    public class MyEventsModel : PageModel
    {
        private readonly aspnetcore_project.Data.EventDbContext _context;

        public MyEventsModel(aspnetcore_project.Data.EventDbContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get;set; }

        public async Task OnGetAsync()
        {
            User attendee = await _context.Users.Include(a => a.JoindEvents).FirstOrDefaultAsync();
            Events  = attendee.JoindEvents;
        }
    }
}
