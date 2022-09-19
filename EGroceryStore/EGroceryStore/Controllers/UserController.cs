using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EGroceryStore.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using EGroceryStore.DataAccess;
using EGroceryStore.Core;

namespace EGroceryStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DB_Context _context;
        private readonly IUser users;

        public UserController(DB_Context context,IUser users)
        {
            _context = context;
            this.users = users;
        }


        
        [HttpPost]
        [Route("Registration")]
        public async Task<ActionResult<Responsemodel>> Signup([FromBody] User user)
        {
            try
            {
                var response = await users.Signup(user);
                return response;
            }
            catch (Exception ex)
            {
                Responsemodel responsemodel = new Responsemodel();
                responsemodel.Message = ex.Message;
                return responsemodel;
            }
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login(Loginmodel loginmodel)
        {
            log.Info("Hit User Login");
            try
            {
                var user = await _context.usertable.Where(i => i.Username == loginmodel.Username && i.Password == loginmodel.Password).FirstOrDefaultAsync();
                if (user == null)
                {
                    throw new Exception("Invalid Credentials");

                }
                var claims = new List<Claim>
                {
                    new Claim(type: ClaimTypes.Name, value:user?.Username)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return Ok("Login Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      

       
    }
}
