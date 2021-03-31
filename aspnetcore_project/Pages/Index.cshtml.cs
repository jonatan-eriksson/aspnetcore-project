using aspnetcore_project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EventDbContext _context;

        public IndexModel(
            ILogger<IndexModel> logger,
            EventDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet(bool? resetDb)
        {
            if(resetDb ?? false)
            {
                _context.ResetAndSeed();
            }
        }
    }
}
