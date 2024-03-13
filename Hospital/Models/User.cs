using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public partial class User
    {
        public User(int id, string name, int palata)
        {
            Id = id;
            Name = name;
            Palata = palata;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Palata { get; set; }
    }
}
