using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToBeDeleted.Models
{
    [JsonObject, Serializable]
    public class PlayerMove
    {
        public int playerID { get; set; }
        public int turn{ get; set; }
        public string playerName { get; set; }
        public int move { get; set; }
    }
}
