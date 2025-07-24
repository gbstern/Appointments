using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static System.Net.WebRequestMethods;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Appointments.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Appointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public readonly DataContext dataContex;
        public LoginController(DataContext _dataContex)
        {
            dataContex = _dataContex;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            //הרשאות עבור מנהל
            if (login.Id == "147258369" && login.Password == "772413")
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, "gitty stern"),
                    new Claim(ClaimTypes.Role, "manager"),
                };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hereIsSomeVeryLongKeyToGenerateMyJwtToken"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5025/",
                    audience: "http://localhost:4200/",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, Role = "manager", Name = "מנהל"});
            }
            // בדיקת משתמש רגיל
            var patient = dataContex.patients.FirstOrDefault(p => p.Id == login.Id && p.Password == login.Password);
            if (patient != null)
            {
                return Ok(new { Role = "user", Name = $"{patient.FirstName} {patient.LastName}", UserId = patient.Id });
            }
            return Unauthorized();
        }

    }

}
