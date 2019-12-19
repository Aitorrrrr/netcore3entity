using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEjemplo.Data.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Picture { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
