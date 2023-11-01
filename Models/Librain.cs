using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Librain
    {
        private string? Name { get; set;}
        private string? Address { get; set;}
        private int MobileNo { get; set;}

        private Member[]? Members { get; set;}
        
    }
}