using System.Data;
using Operation;

namespace InputEquation
{
    class Equation
    {
        static void Main(string[] args)
        {
            Computation computation = new Computation();

            
            Console.Write("Input: ");
            string input = Console.ReadLine();

            Console.WriteLine("\nOutput: \n");
            computation.Pemdas(input);

            
        }
        // end main;



    }
    // end equation;








}






