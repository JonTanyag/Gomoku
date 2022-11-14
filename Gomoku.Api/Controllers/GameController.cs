using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gomoku.Core.Domain;
using Gomoku.Core.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gomoku.Api.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly IPlayService _playService;

        public GameController(IPlayService playService)
        {
            _playService = playService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<List<Board>> Post([FromBody] string value)
        {
            var board = await _playService.NewBoard(15, 15);
            return board;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<List<Board>> Put(int id, [FromBody] List<Board> board, string coordinates)
        {
            var latestBoard = await _playService.HitBoard(id,board, coordinates);
            return latestBoard;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

