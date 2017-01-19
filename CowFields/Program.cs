using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CowFields.Fields;

namespace CowFields
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;

            // Read initial setup line
            line = Console.ReadLine();

            string[] setup = line.Split(' ');
            int fieldCount = int.Parse(setup[0]);
            var fieldSet = new FieldSet(fieldCount);

            // Read remaining input
            while ((line = Console.ReadLine()) != null)
            {
                string[] split = line.Split(' ');
                int from = int.Parse(split[0]);
                int to = int.Parse(split[1]);
                int weight = int.Parse(split[2]);

                fieldSet.NewEdge(from, to, weight);
                Console.WriteLine(fieldSet.Solve());
            }
        }
    }
}
