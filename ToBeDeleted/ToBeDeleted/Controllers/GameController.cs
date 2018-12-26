using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToBeDeleted.Models;

namespace ToBeDeleted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public static int CurrentTurn;
        public static List<PlayerInfo> playerList = new List<PlayerInfo>();

        // GET: api/Game
        [HttpGet]
        public JsonResult Get()
        {
            
            JsonResult js = new JsonResult(playerList);
            return js;
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //POST: api/Game
        [HttpPost]
        public void Post( [FromBody] PostObject post)
        {
            CurrentTurn = post.currentturn;
        }
      


        // PUT: api/Game/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
