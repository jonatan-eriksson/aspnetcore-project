using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aspnetcore_project.Data;
using aspnetcore_project.Models;
using Microsoft.AspNetCore.Authorization;

namespace aspnetcore_project.Pages
{
    [Authorize]
    public class EventsModel : PageModel
    {
        private readonly aspnetcore_project.Data.EventDbContext _context;

        public EventsModel(aspnetcore_project.Data.EventDbContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get;set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
        }
    }
}
