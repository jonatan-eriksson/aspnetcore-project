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
using Microsoft.AspNetCore.Identity;

namespace aspnetcore_project.Pages
{
    [Authorize(Roles= "Administrator,Organizer")]
    public class OrganizeEventsModel : PageModel
    {
        private readonly aspnetcore_project.Data.EventDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrganizeEventsModel(aspnetcore_project.Data.EventDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Event> Events { get;set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(this.User);
            Events = await _context.Events.Where(e => e.Organizer.Id == userId).ToListAsync();
        }
    }
}
