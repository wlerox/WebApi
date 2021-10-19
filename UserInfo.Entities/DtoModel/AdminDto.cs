using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserInfo.Entities.DtoModel
{
    public class AdminDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        //[Required]
        //public string Role { get; set; }
       
    }
}
