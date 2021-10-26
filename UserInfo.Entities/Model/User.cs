using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo.Entities.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string Password { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
