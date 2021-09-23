using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UserInfo.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public String Street { get; set; }
        public String Suite { get; set; }
        public String City { get; set; }
        public String Zipcode { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<User> Users { get; set; }
        [ForeignKey("Geolocation")]
        public int GeoId { get; set; }
        public virtual Geolocation Geo { get; set; }
        
    }
}
