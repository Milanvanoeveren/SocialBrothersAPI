using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace WebApplication.Models
{
    public class DistanceViewModel
    {
        public IEnumerable<Address> Addresses { get; set; }
        public long Addres1Id { get; set; }
        public long Addres2Id { get; set; }
        public Address Address1 { get; set; }
        public Address Address2 { get; set; }
        public double Distance { get; set; }
    }
}
