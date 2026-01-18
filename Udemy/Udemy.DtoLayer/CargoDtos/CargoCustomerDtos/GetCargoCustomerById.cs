using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.DtoLayer.CargoDtos.CargoCustomerDtos
{
    public class GetCargoCustomerById
    {
        public int CargocustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Districk { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string UserCustomerId { get; set; }
    }
}
