using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using UserInfo.Entities.Model;

namespace UserInfo.Entities.DtoModel
{
    public class UserDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        //public int AddressId { get; set; }
        public AddressDto Address { get; set; }
        public String Phone { get; set; }
        public String Website { get; set; }
        //public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public RoleDto Role { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public string Password { get; set; }
    }
}
