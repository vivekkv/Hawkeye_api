using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Admin_Backend.Models.Token;
using Admin_Backend.Models.Api;
using Admin_Backend.Models;
using Admin_Backend.Models.Security;
using Microsoft.Extensions.Configuration;  
using System.Linq;
using System.Text;

namespace Admin_Backend.Controllers
{
    [Route("api/account")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ApveraDbContext _context;
        private IConfiguration _iconfiguration;
        public AccountController(ApveraDbContext context, IConfiguration iconfiguration)
        {
            _context = context;
            _iconfiguration = iconfiguration;
        }

        public IActionResult test()
        {
             return Ok(new ApiResponse
            {
                Success = false,
                Message = "goi"
            });
        }

    }
}