using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Entities.DtoModel
{
    public class UserDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public int AddressId { get; set; }
        public AddressDto Address { get; set; }
        public String Phone { get; set; }
        public String Website { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
