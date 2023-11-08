using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string? Mname { get; set;}
        public string? Maddress { get; set;}
        public int Mno { get; set;} 
        public List<Books> BooksIssued { get; set; } = new List<Books>();

    }
}