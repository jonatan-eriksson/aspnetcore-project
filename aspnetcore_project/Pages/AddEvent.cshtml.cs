using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using aspnetcore_project.Data;
using aspnetcore_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace aspnetcore_project.Pages
{
    [Authorize(Roles = "Administrator,Organizer")]
    public class AddEventModel : PageModel
    {
        private readonly aspnetcore_project.Data.EventDbContext _context;
        private readonly UserManager<User> _userManager;

        public AddEventModel(aspnetcore_project.Data.EventDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.GetUserAsync(this.User);
            Event.Organizer = user;
            
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./OrganizeEvents");
        }
    }
}
