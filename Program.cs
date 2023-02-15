using System;
using System.Globalization;

namespace Calculator {
    class Program {
        static void Main(string[] args) {
            Dictionary<string, Func<float, float, float>> operations = new Dictionary<string, Func<float, float, float>>{
                { "+", Add},
                { "-", Subtract},
                { "*", Multiply},
                { "/", Divide},
                { "%", Modulo},
                { "^", Power},
                { "r", Root}
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("Welcome to the Basile's Calculator!");
            Console.WriteLine("'+' for Addition, '-' for Subtraction, '*' for Multiplication, \n'/' for Division, '%' for Modulo, '^' for Exponentiation, 'r' for Root");
            Console.WriteLine("Enter the operation you want to perform: ");
            var operation = Console.ReadLine();

            Console.WriteLine("Enter the first number: ");
            var arg1 = Console.ReadLine();

            Console.WriteLine("Enter the second number: ");
            var arg2 = Console.ReadLine();

            if (!string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(arg1) && !string.IsNullOrEmpty(arg2)) {
                if (float.TryParse(arg1, out float x) && float.TryParse(arg2, out float y)) {
                    if (operations.ContainsKey(operation)) {
                        if (operation == "/" && y == 0) {
                            Console.WriteLine("Division by zero!");
                        } else {
                            var result = operations[operation](x, y);
                            Console.WriteLine("The result of the operation is: " + result);
                        }
                    } else {
                        Console.WriteLine("Invalid operation");
                    }
                } else {
                    Console.WriteLine("One or more arguments are not numbers!");
                }
            } else {
                Console.WriteLine("Some or more arguments are empty!");
            }

            Console.WriteLine("Do you want to restart? (y/n): ");
            var wantsToRestart = Console.ReadLine() == "y";

            Console.ResetColor();
            Console.Clear();
            if (wantsToRestart) {
                Main(args);
            }
        }

        static float Add(float x, float y) {
            return x + y;
        }

        static float Subtract(float x, float y) {
            return x - y;
        }

        static float Multiply(float x, float y) {
            return x * y;
        }

        static float Divide(float x, float y) {
            return x / y;
        }

        static float Modulo(float x, float y) {
            return x % y;
        }

        static float Power(float x, float y) {
            return (float)Math.Pow(x, y);
        }

        static float Root(float x, float y) {
            return (float)Math.Pow(x, 1 / y);
        }
    }
}