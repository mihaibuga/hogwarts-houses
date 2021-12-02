﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.DAL.Interfaces;
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
        private readonly IPotionService _potionService;
        private readonly IRecipeService _recipeService;

        public PotionController(HogwartsContext context, 
            IPotionService potionService, IRecipeService recipeService)
        {
            _context = context;
            _potionService = potionService;
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<List<Potion>> GetAllPotions()
        {
            //return await _context.GetAllPotions();
            return await _potionService.GetAll();
        }

        [HttpGet("/potions/{studentId}")]
        public async Task<List<Potion>> GetPotionsByStudent(long studentId)
        {
            //return await _context.GetPotionsByStudent(studentId);
            return await _potionService.GetPotionsByStudent(studentId);
        }

        [HttpGet("/potions/{potionId}/help")]
        public async Task<List<Recipe>> GetPossibleRecipesForPotion(long potionId)
        {
            //return await _context.GetPossibleRecipesForPotion(potionId);
            return await _recipeService.GetPossibleRecipesForPotion(potionId);
        }

        [HttpPost]
        public async Task<Potion> AddPotion([FromBody] Potion potion)
        {
            //return await _context.AddPotion(potion);
            return await _potionService.AddPotion(potion);
        }

        [HttpPost("/potions/brew")]
        public async Task AddBrewingPotion([FromBody] Potion potion)
        {
            //await _context.AddBrewingPotion(potion);
            await _potionService.AddBrewingPotion(potion);
        }

        [HttpPut("/potions/{potionId}/add")]
        public async Task<Potion> AttachIngredientToPotion(long potionId, [FromBody] Ingredient ingredient)
        {
            //return await _context.AttachIngredientToPotion(potionId, ingredient);
            return await _potionService.AttachIngredientToPotion(potionId, ingredient);
        }
    }
}
