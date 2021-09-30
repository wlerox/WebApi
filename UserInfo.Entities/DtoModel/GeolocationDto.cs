using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Entities.DtoModel
{
    public class GeolocationDto
    {
        public int Id { get; set; }
        public String Lat { get; set; }
        public String Lng { get; set; }
        //public virtual ICollection<AddressDto> Addresses { get; set; }
    }
}
