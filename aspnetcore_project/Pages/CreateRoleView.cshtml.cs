using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcore_project.Pages
{
    public class CreateRoleViewModel : PageModel
    {

        private readonly RoleManager<IdentityRole> _roleManager;
       

        public CreateRoleViewModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;

         
        }
        public IList<IdentityRole>RoleName { get; set; }

    
        
        public async Task<IActionResult> OnPost(string RoleName)
        {
            if (!string.IsNullOrEmpty(RoleName))
            {
               /* IdentityRole identityrole = new IdentityRole
                {
                    Name = RoleName
                };*/
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(RoleName));
                if(result.Succeeded)
                {
                    return RedirectToAction("/index");

                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return Page();
        }
      

    }
}
