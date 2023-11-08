using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Livraria.Models;

namespace Livraria.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){}
        public DbSet<Books> Books {get; set;}
        public DbSet<Libraian> Libraian { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<FacultyMember> FacultyMembers { get; set; }
        public DbSet <Catalog> Catalog { get; set; }
        

    }
}