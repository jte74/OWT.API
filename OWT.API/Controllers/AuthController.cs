
using Microsoft.AspNetCore.Mvc;
using OWT.Domain.Interfaces;
using OWT.Domain.Models.Requests.Auth;
using System;
using System.Threading.Tasks;

namespace OWT.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private static IAuthBusiness _authBusiness;
        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpPost]
        public async Task<ActionResult> LoginAsync(ConnectUserRequest request)
        {
                if (ModelState.IsValid)
                {
                    var token = await _authBusiness.ConnectUser(request);
                    return token != null ? Ok(token) : BadRequest("Invalid credentials");
                }
                else
                {
                    return BadRequest(ModelState);
                }
        }
    }
}
