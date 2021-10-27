using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserInfo.Entities.DtoModel
{
    public class UserUpdateDto
    {
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
    }
}
