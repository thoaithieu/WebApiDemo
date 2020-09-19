using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class Condition : BaseEntity
    {
        public int VehicleId { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public string Note { get; set; }


        [JsonIgnore]
        public virtual Vehicle Vehicle { get; set; }
    }
}