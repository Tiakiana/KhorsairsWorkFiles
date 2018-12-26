using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToBeDeleted.Models;

namespace ToBeDeleted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {



        public static List<Player> Players = new List<Player>()
        {
            new Player()
            {
                ID = 1,
                Name = "Svend Bent",
                Score = 1000
                },
    new Player()
    {
                ID = 2,
                Name = "Hubert",
                Score = 1500
    },
    new Player()
    {
                ID = 3,
                Name = "IngeMarie",
                Score = 50
    },
    new Player()
    {
                ID = 4,
                Name = "Grethe",
                Score = 100
    }
        };

        // GET api/players
        [HttpGet]
        public JsonResult Get()
        {
            JsonResult js = new JsonResult(Players);
            return js;
        }

        // GET api/players/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Player player = Players.Single(p => p.ID == id);
            JsonResult json = new JsonResult(player);
            return json;
        }

        // POST api/players
        [HttpPost]
        public void Post([FromBody] PlayerInfo newPlayer)
        {
            newPlayer.Turn = GameController.CurrentTurn;
            GameController.playerList.Add(newPlayer);

        }

        // PUT api/players/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] PlayerInfo updatePlayer)
        {
            GameController.playerList.Single(x => x.Name == id).Turn = GameController.CurrentTurn;
            GameController.playerList.Single(x => x.Name == id).Move = updatePlayer.Move;
        }

        // DELETE api/players/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
