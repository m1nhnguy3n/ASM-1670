using ASM.Areas.Identity.Data;
using ASM.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASM.Controllers
{
    public class CartsController : Controller
    {
        private readonly UserContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CartsController(UserContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            string thisUserId = _userManager.GetUserId(HttpContext.User);
            return View(_context.Carts.Where(c => c.UId == thisUserId)
                .Include(c => c.Book));
        }

    }

}