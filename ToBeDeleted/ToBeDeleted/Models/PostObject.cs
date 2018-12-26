using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToBeDeleted.Models
{
    [JsonObject, Serializable]
    public class PostObject
    {
      public  int currentturn { get; set; }
    }
}
