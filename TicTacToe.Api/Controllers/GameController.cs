﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Api.Features.Game.GetGame;
using TicTacToe.Api.Features.Game.NewGame;

namespace TicTacToe.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IMediator _mediator;
        public GameController(ILogger<GameController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet(Name = "StartGame")]
        public async Task<ActionResult<NewGameResponse>> StartGame()
        {
            var request = new NewGameRequest();
            var game = await _mediator.Send(request);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }
        //[HttpGet(Name = "GetGame")]
        //public async Task<ActionResult<GetGameResponse>> GetGame(Guid id)
        //{
        //    var request = new GetGameQuery(id);
        //    var game = await _mediator.Send(request);

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(game);
        //}
    }
}
