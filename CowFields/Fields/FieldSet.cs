using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowFields.Fields
{
    public class FieldSet
    {
        public Dictionary<int, Node> Fields { get; set; }
        public bool AllVisited { get; set; }

        public FieldSet(int fields)
        {
            CreateFields(fields);
        }

        private void CreateFields(int fields)
        {
            Fields = new Dictionary<int, Node>();

            for (int i = 1; i <= fields; i++)
            {
                Fields.Add(i, new Node(i));
            }
        }

        public void NewEdge(int from, int to, int weight)
        {
            // Check if edge already exists
            int existingWeight;
            Fields[from].Edges.TryGetValue(to, out existingWeight);

            if (existingWeight == 0)
            {
                // Edge doesn't exist, add as is
                Fields[from].Edges.Add(to, weight);
                Fields[to].Edges.Add(from, weight);

                // Mark as visited
                Fields[from].Visited = true;
                Fields[to].Visited = true;
            }
            else
            {
                // Edge exists, check if new weight is shorter
                if (weight < existingWeight)
                {
                    Fields[from].Edges[to] = weight;
                    Fields[to].Edges[from] = weight;
                }
            }

            // All fields visited yet?
            if (Fields.All(f => f.Value.Visited))
            {
                AllVisited = true;
            }

        }

        private int PrimWalk()
        {
            // Create the sets for the algorithm
            var visitedNodes = new HashSet<Node>();
            var unvisitedNodes = new HashSet<Node>();

            // Initial setup
            int weight = 0;
            var node = Fields.First().Value;
            visitedNodes.Add(node);
            bool loop = true;

            // Start the Prim walk
            while (visitedNodes != unvisitedNodes)
            {
                
            }

            return weight;
        }
    }
}
