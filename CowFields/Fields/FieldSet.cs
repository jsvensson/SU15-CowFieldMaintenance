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
            var unvisitedNodes = new HashSet<Node>(Fields.Values);

            // Initial setup
            int weight = 0;
            var node = unvisitedNodes.First();
            visitedNodes.Add(node);
            unvisitedNodes.Remove(node);

            // Start the Prim walk
            while (unvisitedNodes.Count > 0)
            {
                // Find shortest edge not yet connected to a visited node
                KeyValuePair<int, int> nextEdge = visitedNodes
                    .SelectMany(n => n.Edges)
                    .Where(e => !visitedNodes.Select(n => n.Id).Contains(e.Key))
                    .OrderBy(e => e.Value)
                    .First();

                // Add weight to counter
                weight += nextEdge.Value;

                // Fetch selected node
                Node nextNode = unvisitedNodes.Single(n => n.Id == nextEdge.Key);

                // Move node to visited set
                visitedNodes.Add(nextNode);
                unvisitedNodes.Remove(nextNode);
            }

            return weight;
        }

        public int Solve()
        {
            if (!AllVisited)
            {
                return -1;
            }

            return PrimWalk();
        }
    }
}
