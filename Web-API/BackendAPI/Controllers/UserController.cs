using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await userService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await userService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(Customer user)
        {
            await userService.Create(user);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Customer user)
        {
            await userService.Update(user);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await userService.Delete(id);
            return Ok();
        }
    }
}
