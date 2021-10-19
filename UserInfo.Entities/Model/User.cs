using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserInfo.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        
        public String Username { get; set; }
        public String Email { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public String Phone { get; set; }
        public String Website { get; set; }
        
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        
    }
}
