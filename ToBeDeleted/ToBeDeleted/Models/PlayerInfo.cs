using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToBeDeleted.Models
{
    [JsonObject, Serializable]
    public class PlayerInfo
    {
        public string Name { get; set; }
        public int Team { get; set; }
        public int Move { get; set; }
        public int Turn { get; set; }
    }
}
