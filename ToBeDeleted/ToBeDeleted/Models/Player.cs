using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToBeDeleted.Models
{
    [JsonObject, Serializable]
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Score { get; set; }
    }
}
