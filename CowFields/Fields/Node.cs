using System.Collections.Generic;

namespace CowFields.Fields
{
    public class Node
    {
        public int Id { get; set; }
        public bool Visited { get; set; }
        public Dictionary<int, int> Edges { get; set; }

        public Node(int id)
        {
            Id = id;
            Edges = new Dictionary<int, int>();
        }
    }
}
