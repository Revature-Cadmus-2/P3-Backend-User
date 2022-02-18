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
    public class NotificationsController : ControllerBase
    {
        private readonly IBL _bl;
        public NotificationsController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<NotificationsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Notifications> allNotifications = await _bl.GetAllNotificationsAsync();
            if(allNotifications != null)
            {
                return Ok(allNotifications);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<NotificationsController>/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            Notifications thisNotification = await _bl.GetNotificationsByIdAsync(id);
            if(thisNotification != null)
            {
                return Ok(thisNotification);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetNotificationsByUserId(int userId)
        {
            List<Notifications> userNotifications = await _bl.GetNotificationsbyUserIdAsync(userId);
            if(userNotifications != null)
            {
                return Ok(userNotifications);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<NotificationsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Notifications newNotification)
        {
            Notifications addedNotification = (Notifications) await _bl.AddObjectAsync(newNotification);
            return Created("api/[controller", addedNotification);
        }

        // PUT api/<NotificationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotificationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
