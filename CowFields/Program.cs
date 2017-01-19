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
            var fieldSet = new FieldSet(4);

            fieldSet.NewEdge(1, 2, 10);
            fieldSet.NewEdge(1, 3, 8);
            fieldSet.NewEdge(3, 2, 3);
            fieldSet.NewEdge(1, 4, 3);

            int result = fieldSet.Solve();

            Console.WriteLine(result);
        }
    }
}
