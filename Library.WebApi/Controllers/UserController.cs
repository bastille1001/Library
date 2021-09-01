using Library.Services.Attributes;
using Library.Services.AuthenticateModels;
using Library.Services.Models;
using Library.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;
        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userServices.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult CreateUser(User user) =>
            Ok(_userServices.CreateUser(user));

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userServices.GetAll();
            return Ok(users);
        }
    }
}
