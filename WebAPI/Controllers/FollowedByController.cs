using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowedByController : ControllerBase
    {
        private readonly IBL _bl;
        public FollowedByController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<FollowedByController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<FollowedBy> allFollowers = await _bl.GetAllFollowersAsync();
            if(allFollowers != null)
            {
                return Ok(allFollowers);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetFollowersByUserId(int userId)
        {
            List<FollowedBy> userFollowers = await _bl.GetFollowersbyUserIdAsync(userId);
            if (userFollowers != null)
            {
                return Ok(userFollowers);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<FollowedByController>/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            FollowedBy followers = await _bl.GetFollowersByIdAsync(id);
            if(followers != null)
            {
                return Ok(followers);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<FollowedByController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FollowedBy newFollower)
        {
            FollowedBy addedFollower = (FollowedBy)await _bl.AddObjectAsync(newFollower);
            return Created("api/[controller]", addedFollower);
        }

        // PUT api/<FollowedByController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FollowedByController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            FollowedBy deleteFollower = await _bl.GetFollowersByIdAsync(id);
            await _bl.DeleteObjectAsync(deleteFollower);
            return Ok(deleteFollower);
        }
    }
}
