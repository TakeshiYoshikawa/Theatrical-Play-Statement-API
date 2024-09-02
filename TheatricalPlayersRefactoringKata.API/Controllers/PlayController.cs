﻿using Microsoft.AspNetCore.Mvc;
using TheatricalPlayersRefactoringKata.Entities;
using TheatricalPlayersRefactoringKata.Interfaces.Repositories;

namespace TheatricalPlayersRefactoringKata.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayController : Controller
    {
        private readonly IBaseRepository<Play> _playRepository;

        public PlayController(IBaseRepository<Play> context)
        {
            _playRepository = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Play play)
        {
            await _playRepository.AddAsync(play);
            return CreatedAtAction(nameof(Get), new { id = play.Name }, play);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var plays = await _playRepository.GetAllAsync();
            return Ok(plays);
        }
    }
}
