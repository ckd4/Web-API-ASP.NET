using API.Contracts;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}/info")]
        public async Task<IActionResult> GetUserDataByIdentificator(long id)
        {
            User? user = await userService.GetUserById(id);
            if (user == null)
                return NotFound($"user {id} does not exist");
            return Ok(user.Adapt<GetUserContract>());
        }

        [HttpPut("update/info/{token}")]
        public async Task<IActionResult> Update(string token, UpdateUserContract user)
        {
            User? selectedUser = await userService.GetUserByToken(token);
            if (selectedUser == null)
                return NotFound("invalid user token");
            selectedUser.FirstName = user.FirstName;
            selectedUser.FamilyName = user.FamilyName;
            selectedUser.Birthday = user.Birthday;
            await userService.Update(selectedUser);
            return Ok();
        }

        [HttpDelete("delete/{token}")]
        public async Task<IActionResult> Delete(string token)
        {
            User? user = await userService.GetUserByToken(token);
            if (user == null)
                return NotFound("invalid user token");
            await userService.Delete(user.UserId);
            return Ok("user successfully deleted");
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddUserContract user)
        {
            User newUser = new User()
            {
                FirstName = user.FirstName,
                FamilyName = user.FamilyName,
                Birthday = new DateTime(
                    user.Birthday.Year,
                    user.Birthday.Month,
                    user.Birthday.Day)
            };

            await userService.Create(newUser);
            return Ok();
        }
    }
}