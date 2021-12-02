using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsPotions.Controllers
{
    [ApiController, Route("/potions")]
    [EnableCors("AllowAll")]
    public class PotionController : ControllerBase
    {
        private readonly HogwartsContext _context;

        public PotionController(HogwartsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Potion>> GetAllPotions()
        {
            return await _context.GetAllPotions();
        }

        [HttpGet("/potions/{studentId}")]
        public async Task<List<Potion>> GetPotionsByStudent(long studentId)
        {
            return await _context.GetPotionsByStudent(studentId);
        }

        [HttpPost]
        public async Task<Potion> AddPotion([FromBody] Potion potion)
        {
            return await _context.AddPotion(potion);
        }

        [HttpPost("/potions/brew")]
        public async Task AddBrewingPotion([FromBody] Potion potion)
        {
            await _context.AddBrewingPotion(potion);
        }

        [HttpPut("/potions/{potionId}/add")]
        public async Task AttachIngredientToPotion(long potionId, [FromBody] Ingredient ingredient)
        {
            await _context.AttachIngredientToPotion(potionId, ingredient);
        }
    }
}
