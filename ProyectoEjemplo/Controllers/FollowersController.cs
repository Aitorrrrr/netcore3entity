using Microsoft.AspNetCore.Mvc;
using ProyectoEjemplo.Data.Dto;
using ProyectoEjemplo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowersController : ControllerBase
    {
        private readonly FollowerRepository _followerRepository;

        public FollowersController(FollowerRepository followerRepository)
        {
            this._followerRepository = followerRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<FollowerInfoDto>>> GetFollowers(int userId)
        {
            return Ok(await _followerRepository.GetFollowers(userId));
        }

        [HttpGet("Following/{userId}")]
        public async Task<ActionResult<IEnumerable<FollowerInfoDto>>> GetFollowings(int userId)
        {
            return Ok(await _followerRepository.GetFollowings(userId));
        }
    }
}
