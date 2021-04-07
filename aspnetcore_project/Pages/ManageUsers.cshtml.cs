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

namespace aspnetcore_project
{
    [Authorize(Roles = "Administrator")]
    public class ManageUsersModel : PageModel
    {
        private readonly aspnetcore_project.Data.EventDbContext _context;
        private readonly UserManager<User> _userManager;

        public ManageUsersModel(aspnetcore_project.Data.EventDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<User> Users { get; set; }


        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return Page();
            }

            var role = "Organizer";
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (await _userManager.IsInRoleAsync(user, role))
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }
            else
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return RedirectToPage();
        }

        public async Task<bool> IsOrganizer(User user)
        {
            return await _userManager.IsInRoleAsync(user, "Organizer");
        }

    }
}
