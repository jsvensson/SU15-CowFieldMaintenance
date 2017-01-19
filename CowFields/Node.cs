using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowFields
{
    public class Node
    {
        public int Id { get; set; }
        public bool Visited { get; set; }
        public Dictionary<int, int> Paths { get; set; }
    }
}
