using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string? Authorname { get; set;}
        public int Noofcopies { get; set;}
        public List<Books>? Books { get; set; } = new List<Books>();
    }
}   