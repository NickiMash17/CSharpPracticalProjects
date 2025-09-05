using EquationSolver.Services;

namespace EquationSolver
{
    /// <summary>
    /// Main program for Equation Solver
    /// Solves linear equations (ax + b = 0) and quadratic equations (ax² + bx + c = 0)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the C# Equation Solver!");
            Console.WriteLine("This program solves linear and quadratic equations with detailed explanations.");
            
            bool continueSolving = true;
            
            while (continueSolving)
            {
                try
                {
                    EquationSolverService.DisplayMenu();
                    
                    int choice = EquationSolverService.GetValidChoice(
                        "Enter your choice (1-3): ", 1, 3);
                    
                    switch (choice)
                    {
                        case 1:
                            HandleLinearEquation();
                            break;
                        case 2:
                            HandleQuadraticEquation();
                            break;
                        case 3:
                            continueSolving = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                            break;
                    }
                    
                    if (continueSolving)
                    {
                        Console.WriteLine("\n" + new string('=', 60));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nUnexpected error occurred: {ex.Message}");
                    Console.WriteLine("Please try again.");
                }
            }
            
            Console.WriteLine("\nThank you for using the C# Equation Solver!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Handles linear equation solving
        /// </summary>
        static void HandleLinearEquation()
        {
            Console.WriteLine("\n--- Linear Equation Solver ---");
            Console.WriteLine("Solving equation: ax + b = 0");
            Console.WriteLine();
            
            double a = EquationSolverService.GetValidDouble("Enter coefficient a: ");
            double b = EquationSolverService.GetValidDouble("Enter constant b: ");
            
            EquationSolverService.SolveLinearEquation(a, b);
        }

        /// <summary>
        /// Handles quadratic equation solving
        /// </summary>
        static void HandleQuadraticEquation()
        {
            Console.WriteLine("\n--- Quadratic Equation Solver ---");
            Console.WriteLine("Solving equation: ax² + bx + c = 0");
            Console.WriteLine();
            
            double a = EquationSolverService.GetValidDouble("Enter coefficient a: ");
            double b = EquationSolverService.GetValidDouble("Enter coefficient b: ");
            double c = EquationSolverService.GetValidDouble("Enter constant c: ");
            
            // Check for special case where a = 0
            if (Math.Abs(a) < 1e-10)
            {
                Console.WriteLine("\n⚠️  Warning: a = 0 makes this a linear equation, not quadratic!");
                Console.WriteLine("Would you like to solve it as a linear equation instead? (y/n)");
                
                string response = Console.ReadLine()?.ToLower();
                if (response == "y" || response == "yes")
                {
                    EquationSolverService.SolveLinearEquation(a, b);
                    return;
                }
                else
                {
                    Console.WriteLine("Continuing with quadratic solver...");
                }
            }
            
            EquationSolverService.SolveQuadraticEquation(a, b, c);
            
            // Ask if user wants to learn about the discriminant
            Console.WriteLine("\nWould you like to learn about the discriminant? (y/n)");
            string learnResponse = Console.ReadLine()?.ToLower();
            if (learnResponse == "y" || learnResponse == "yes")
            {
                EquationSolverService.DisplayDiscriminantInfo();
            }
        }
    }
}
