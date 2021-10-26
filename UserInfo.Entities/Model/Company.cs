using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UserInfo.Entities.Model
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Catchphrase { get; set; }
        public string Bs { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
