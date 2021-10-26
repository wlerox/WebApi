using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace UserInfo.Entities.DtoModel
{
    public class UserSecurityDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [JsonIgnore]
        [IgnoreDataMember]
        public string Password { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
