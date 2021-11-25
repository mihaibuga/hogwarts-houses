using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsPotions.Controllers
{
    [ApiController, Route("/room")]
    public class RoomController : ControllerBase
    {
        private readonly HogwartsContext _context;

        public RoomController(HogwartsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.GetAllRooms();
        }

        [HttpPost]
        public void AddRoom([FromBody] Room room)
        {
            _context.AddRoom(room);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<Room>> GetRoomById(long id)
        {
            try
            {
                var room = await _context.GetRoom(id);

                if (room == null)
                {
                    return NotFound();
                }

                return room;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut("/{id}")]
        public async Task UpdateRoomByIdAsync(long id, [FromBody] Room updatedRoom)
        {
            if (id == updatedRoom.ID)
            {
                await _context.UpdateRoom(updatedRoom);
            }
        }

        [HttpDelete("/{id}")]
        public void DeleteRoomById(long id)
        {
            _context.DeleteRoom(id);
        }

        [HttpGet("/rat-owners")]
        public async Task<List<Room>> GetRoomsForRatOwners()
        {
            return await _context.GetRoomsForRatOwners();
        }
    }
}
