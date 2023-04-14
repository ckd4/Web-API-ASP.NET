using BackendAPI.Contracts.Customer;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
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
        /// <summary>
        /// Получает список всех пользователей.
        /// </summary>
        /// <returns>Список пользователей.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await userService.GetAll());
        }

        /// <summary>
        /// Получает пользователя по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Пользователь.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await userService.GetById(id));
        }

        /// <summary>
        /// Добавляет нового пользователя.
        /// </summary>
        /// <param name="user">Новый пользователь.</param>
        /// <returns>Результат добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest cus)
        {

            Customer CusModel = new Customer()
            {
                CustomerPhone = cus.CustomerPhone,
                CustomerPassword = cus.CustomerPassword,
                CustomerFirstName = cus.CustomerFirstName,
                CustomerLastName = cus.CustomerLastName,
                CustomerAddress = cus.CustomerAddress,
            };
            await userService.Create(CusModel.Adapt<Customer>());
            return Ok();
        }

        /// <summary>
        /// Обновляет существующего пользователя.
        /// </summary>
        /// <param name="user">Обновленный пользователь.</param>
        /// <returns>Результат обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Customer user)
        {
            await userService.Update(user);
            return Ok();
        }

        /// <summary>
        /// Удаляет пользователя по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Результат удаления.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await userService.Delete(id);
            return Ok();
        }

    }
}
