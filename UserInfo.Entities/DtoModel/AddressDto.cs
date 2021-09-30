using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Entities.DtoModel
{
    public class AddressDto
    {
        public int Id { get; set; }
        public String Street { get; set; }
        public String Suite { get; set; }
        public String City { get; set; }
        public String Zipcode { get; set; }
        //public virtual ICollection<UserDto> Users { get; set; }
        public int GeoId { get; set; }
        public GeolocationDto Geo { get; set; }
    }
}
