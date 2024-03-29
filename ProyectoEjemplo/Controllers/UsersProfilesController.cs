﻿using Microsoft.AspNetCore.Mvc;
using ProyectoEjemplo.Data.Dto;
using ProyectoEjemplo.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersProfilesController : ControllerBase
    {
        private readonly UserProfileRepository _userProfileRepository;

        public UsersProfilesController(UserProfileRepository userProfileRepository)
        {
            this._userProfileRepository = userProfileRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfileDto>>> GetAll()
        {
            return Ok(await _userProfileRepository.GetAll());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileDto>> GetById(int id)
        {
            return Ok(await _userProfileRepository.GetById(id));
        }
    }
}
