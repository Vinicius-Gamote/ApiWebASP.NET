using ApiWeb.API;
using ApiWeb.Domain;
using ApiWeb.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiWeb.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiWebController : ControllerBase
    {
        [HttpGet("user")]
        public async Task<IActionResult> GetUsersAsync([FromServices] ApiWebContext context, int skip = 0, int take = 10)
        {
            var users = await context.Users.AsNoTracking().Skip(skip).Take(take).ToListAsync();
            return Ok(users);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromServices] ApiWebContext context, [FromRoute] int id)
        {
            var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("user")]
        public async Task<IActionResult> PostUsersAsync([FromServices] ApiWebContext context, [FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = new User
            {
                Name = model.Name,
                Positions = model.Positions,
                Birthday = model.Birthday,
                UserIcon = model.UserIcon
            };

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Created("v1/user/{user.Id}", user);
            }

            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }

        }

        [HttpPut("user/{id}")]
        public async Task<IActionResult> PutUsersAsync([FromServices] ApiWebContext context, [FromBody] User model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                NotFound();

            try
            {
                user.Name = model.Name;
                user.Positions = model.Positions;
                user.Birthday = model.Birthday;
                user.UserIcon = model.UserIcon;

                context.Users.Update(user);
                await context.SaveChangesAsync();

                return Ok(user);
            }

            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUsersAsync([FromServices] ApiWebContext context, [FromRoute] int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return Ok("User Deleted!");
            }

            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

    }
}
