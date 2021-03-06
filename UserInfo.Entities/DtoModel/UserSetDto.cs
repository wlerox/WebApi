using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace UserInfo.Entities.DtoModel
{
    public class UserSetDto
    {

        [JsonIgnore]
        [IgnoreDataMember]
        public int Id { get; set; }
        public String Name { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public String Phone { get; set; }
        public String Website { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
