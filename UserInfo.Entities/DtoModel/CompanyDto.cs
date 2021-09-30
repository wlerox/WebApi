using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Entities.DtoModel
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Catchphrase { get; set; }
        public String Bs { get; set; }
        //public virtual ICollection<UserDto> Users { get; set; }
    }
}
