using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMTraine
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
