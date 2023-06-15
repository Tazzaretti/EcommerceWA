using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.ViewModels;
using Service.Services;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();

            var usersViewModel = users.Select(user => new UsersViewModel
            {
                Dni = user.Dni,
                Email = user.Email,
                Nombre = user.Nombre,
                Tel = user.Tel
            }).ToList();

            return Ok(usersViewModel);
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var usersViewModel = new UsersViewModel
            {
                Dni = user.Dni,
                Email = user.Email,
                Nombre = user.Nombre,
                Tel = user.Tel
            };
            
            return Ok(usersViewModel);
        }

        [HttpPost]
        public IActionResult AddUser(Users user)
        {
            _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("UpdateUserById")]
        public IActionResult UpdateUser(int id, Users user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("DeleteUserById")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}