using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private static List<User> users = new List<User>()
        {
            new User { Id = 1, Name = "Тест 1" },
            new User { Id = 2, Name = "Тест 2" },
            new User { Id = 3, Name = "Тест 3" },
            new User { Id = 4, Name = "Тест 4" },
            new User { Id = 5, Name = "Тест 5" }
        }; // Список пользователей

        // GET: api/Test
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return users;
        }

        // POST: api/Test
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                if (user != null && !string.IsNullOrEmpty(user.Name))
                {
                    user.Id = users.Count + 1; // Генерируем новый Id
                    users.Add(user); // Добавляем пользователя в список
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/Test/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User newUser)
        {
            try
            {
                if (id > 0 && newUser != null && !string.IsNullOrEmpty(newUser.Name))
                {
                    var userToUpdate = users.FirstOrDefault(u => u.Id == id);
                    if (userToUpdate != null)
                    {
                        userToUpdate.Name = newUser.Name; // Обновляем имя пользователя
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Test/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userToDelete = users.FirstOrDefault(u => u.Id == id);
                if (userToDelete != null)
                {
                    users.Remove(userToDelete); // Удаляем пользователя из списка
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
