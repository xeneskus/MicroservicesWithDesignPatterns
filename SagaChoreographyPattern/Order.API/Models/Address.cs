using Microsoft.EntityFrameworkCore;

namespace Order.API.Models
{
    [Owned] //ayrı bir tablo içerisinde olmasın order tablosunda olsun.
    public class Address
    {
        public string Line { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
    }
}
