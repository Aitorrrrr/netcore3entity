using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEjemplo.Data;
using ProyectoEjemplo.Data.Dto;
using ProyectoEjemplo.Data.Models;
using ProyectoEjemplo.Repositories;

namespace ProyectoEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserRepository _userRepository;

        public UsersController(DataContext context, UserRepository userRepository)
        {
            _context = context;
            this._userRepository = userRepository;

            if (_context.Users.Count() <= 0)
            {
                User[] users = new User[]
                {
                    new User{ Login = "Usuario1", Password = "Password1", Email = "Email1"},
                    new User{ Login = "Usuario2", Password = "Password2", Email = "Email2"}   
                };

                _context.Users.AddRange(users);
                _context.SaveChanges();
            }
        }

        // GET: api/Users
        /// <summary>
        /// Devuelve todos los usuarios
        /// </summary>
        /// <remarks>
        /// Usuario ejemplo:
        ///
        ///     GET /Users
        ///     {
        ///        "login": "nombreUser",
        ///        "password": "passwordRnd",
        ///        "email": "eMail"
        ///     }
        ///
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfoDto>>> GetUsers()
        {
            return Ok(await _userRepository.GetAll());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfoDto>> GetUser(int id)
        {
            return Ok(await _userRepository.GetById(id));
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<UserInfoDto>> Update(int id, [FromBody] UserDto userDto)
        {
            return Ok(await this._userRepository.Update(id, userDto));
        }

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
