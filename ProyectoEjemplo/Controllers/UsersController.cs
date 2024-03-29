﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfoDto>> GetUser(int id)
        {
            return Ok(await _userRepository.GetById(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserInfoDto>> Update(int id, [FromBody] UserDto userDto)
        {
            return Ok(await this._userRepository.Update(id, userDto));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<UserInfoDto>> Register([FromBody] UserDto user)
        {
            return Ok(await this._userRepository.Create(user));
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            return Ok(await this._userRepository.Delete(id));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}