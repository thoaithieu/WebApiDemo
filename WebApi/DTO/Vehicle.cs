using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class Vehicle : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ModelId { get; set; }
        public int MakeId { get; set; }
        public string VIN { get; set; }
        public int Odometer { get; set; }
        public string Engine { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        [JsonIgnore]
        public virtual Model Model { get; set; }
        [JsonIgnore]
        public virtual Make Make { get; set; }

        [JsonIgnore]
        public virtual ICollection<Condition> Conditions { get; set; }
        [JsonIgnore]
        public virtual ICollection<VehicleAppraisal> VehicleAppraisals { get; set; }
    }
}