using ApiWeb.Data;
using ApiWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiWeb.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiWebController : ControllerBase
    {
        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUsersAsync([FromServices] ApiWebContext context)
        {
            var users = await context.User.AsNoTracking().ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("user/{id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromServices] ApiWebContext context, [FromRoute] int id)
        {
            var user = await context.User.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> PostUsersAsync([FromServices] ApiWebContext context, [FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = new User
            {
                Name = model.Name,
                Position = model.Position,
                Birthday = model.Birthday
            };

            try
            {
                await context.User.AddAsync(user);
                await context.SaveChangesAsync();

                return Created("v1/user/{user.Id}", user);
            }

            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }

        }

        [HttpPut]
        [Route("user/{id}")]
        public async Task<IActionResult> PutUsersAsync([FromServices] ApiWebContext context, [FromBody] User model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await context.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                NotFound();

            try
            {
                user.Name = model.Name;
                user.Position = model.Position;
                user.Birthday = model.Birthday;

                context.User.Update(user);
                await context.SaveChangesAsync();

                return Ok(user);
            }

            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpDelete]
        [Route("user/{id}")]
        public async Task<IActionResult> DeleteUsersAsync([FromServices] ApiWebContext context, [FromRoute] int id)
        {
            var user = await context.User.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.User.Remove(user);
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
