using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UserInfo.Entities.Model
{
    public class Geolocation
    {
        [Key]
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
