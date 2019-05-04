using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using WebAppService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET: api/values
        [HttpPost, Route("login")]
        public IActionResult LoginAction([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.UserName == "johndoe" && user.Password == "def@123")
            {
                // Create symmetric security secrete key value with secrete key
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                // Important third step of creating the JWT token
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5020",        // Name of the web server that issues the token
                    audience: "http://localhost:5020",      // Represents valid recipients/audience
                    claims: new List<Claim>(),              // List of user roles. Examples: admin, manager or author
                    expires: DateTime.Now.AddMinutes(5),    // Date and time after which the token expires
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions); // Create a string JWT token
                return Ok(new { Token = tokenString }); // Return the new created string JWT token
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
