using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Alert
    {
        private DateTime Issuedate { get; set; }
        private string? Bookname { get; set; }
        private DateTime Returndate { get; set; }
        private int Fine { get; set; }
    }
}