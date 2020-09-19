using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class VehicleAppraisal : BaseEntity
    {
        public int VehicleId { get; set; }
        public double AppraiseValue { get; set; }

        [JsonIgnore]
        public virtual Vehicle Vehicle { get; set; }
    }
}