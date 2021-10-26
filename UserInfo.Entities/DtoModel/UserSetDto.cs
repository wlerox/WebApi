using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Entities.DtoModel
{
    public class UserSetDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public int AddressId { get; set; }
        public String Phone { get; set; }
        public String Website { get; set; }
        public int CompanyId { get; set; }
        public string Password { get; set; }
    }
}
