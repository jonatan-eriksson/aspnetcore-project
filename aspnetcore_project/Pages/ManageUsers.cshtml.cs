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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;


      

        public ManageUsersModel(aspnetcore_project.Data.EventDbContext context,RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;


        }

        public IList<User> Users { get; set; }
       

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
       
       
        
    }
}