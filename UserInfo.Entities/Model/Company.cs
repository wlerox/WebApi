using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UserInfo.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Catchphrase { get; set; }
        public String Bs { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<User> Users { get; set; }
    }
}
