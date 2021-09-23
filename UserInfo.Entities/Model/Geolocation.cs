using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UserInfo.Entities
{
    public class Geolocation
    {
        [Key]
        public int Id { get; set; }
        public String Lat { get; set; }
        public String Lng { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
