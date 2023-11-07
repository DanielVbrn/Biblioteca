using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Libraian
    {
        public int Id { get;  set; }
        public string? Name { get; set;}
        public string? Address { get; set;}
        public int MobileNo { get; set;}

        public Member[]? Members { get; set;}

        
    }
}