using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Alert
    {
        public DateTime Issuedate { get; set; }
        public string? Bookname { get; set; }
        public DateTime Returndate { get; set; }
        public int Fine { get; set; }   
    }
}