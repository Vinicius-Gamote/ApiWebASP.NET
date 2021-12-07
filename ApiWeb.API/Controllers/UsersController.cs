using ApiWeb.Domain;
using ApiWeb.Persistence;
using ApiWeb.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWeb.Application.Contracts;
using Microsoft.AspNetCore.Http;

namespace ApiWeb.API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUsersAsync()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync(true);
                if (users == null) return NotFound("Any user found!");

                return Ok(users);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Try get user error. Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id, true);
                if (user == null) return NotFound("User not found!");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Try get user error. Error: {ex.Message}");
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<User>> GetUserByNameAsync(string name)
        {
            try
            {
                var users = await _userService.GetAllUsersByNameAsync(name, true);
                if (users == null) return NotFound("User by name not found!");

                return Ok(users);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Try get user error. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUsersAsync(User model)
        {
            try
            {
                var user = await _userService.AddUsers(model);
                if (user == null) return BadRequest("Error when try to add users!");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Try add user error. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUsersAsync(int id, User model)
        {
            try
            {
                var user = await _userService.UpdateUser(id, model);
                if (user == null) return BadRequest("Error when try to update users!");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Try update user error. Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUsersAsync(int id)
        {
            try
            {
                if (await _userService.DeleteUser(id))
                    return Ok("Deleted");

                else
                    return BadRequest("User not deleted!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Try delete user error. Error: {ex.Message}");
            }
        }

    }
}
