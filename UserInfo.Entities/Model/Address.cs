using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UserInfo.Entities.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual ICollection<User> Users { get; set; }
        [ForeignKey("Geolocation")]
        public int GeoId { get; set; }
        public virtual Geolocation Geo { get; set; }

    }
}
