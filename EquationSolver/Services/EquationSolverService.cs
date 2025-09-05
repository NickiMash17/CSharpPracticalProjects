using EquationSolver.Models;

namespace EquationSolver.Services
{
    /// <summary>
    /// Service class for solving equations and handling user input
    /// </summary>
    public class EquationSolverService
    {
        /// <summary>
        /// Gets a valid double input from the user with error handling
        /// </summary>
        /// <param name="prompt">The prompt message to display</param>
        /// <returns>Valid double value</returns>
        public static double GetValidDouble(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Error: Input cannot be empty. Please enter a valid number.");
                        continue;
                    }

                    if (double.TryParse(input, out double value))
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a valid number. Invalid input: " + input);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Gets a valid integer choice from the user
        /// </summary>
        /// <param name="prompt">The prompt message to display</param>
        /// <param name="minValue">Minimum valid value</param>
        /// <param name="maxValue">Maximum valid value</param>
        /// <returns>Valid integer choice</returns>
        public static int GetValidChoice(string prompt, int minValue, int maxValue)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Error: Input cannot be empty. Please enter a valid choice.");
                        continue;
                    }

                    if (int.TryParse(input, out int choice) && choice >= minValue && choice <= maxValue)
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine($"Error: Please enter a number between {minValue} and {maxValue}. Invalid input: " + input);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Solves a linear equation and displays the results
        /// </summary>
        /// <param name="a">Coefficient of x</param>
        /// <param name="b">Constant term</param>
        public static void SolveLinearEquation(double a, double b)
        {
            Console.WriteLine("\n=== Linear Equation Solver ===");
            Console.WriteLine($"Solving: {a}x + {b} = 0");
            
            var equation = new LinearEquation(a, b);
            Console.WriteLine($"Equation: {equation}");
            Console.WriteLine($"Type: {equation.GetEquationType()}");
            
            var solution = equation.Solve();
            
            if (solution.HasValue)
            {
                Console.WriteLine($"Solution: x = {solution.Value:F6}");
                
                // Verify the solution
                if (equation.VerifySolution(solution.Value))
                {
                    Console.WriteLine("✓ Verification: Solution is correct!");
                }
                else
                {
                    Console.WriteLine("✗ Verification: Solution verification failed!");
                }
            }
            else
            {
                Console.WriteLine("No unique solution exists.");
                Console.WriteLine("This occurs when a = 0:");
                if (Math.Abs(b) < 1e-10)
                    Console.WriteLine("- If b = 0: 0 = 0 (identity, infinite solutions)");
                else
                    Console.WriteLine("- If b ≠ 0: 0 = b (contradiction, no solution)");
            }
        }

        /// <summary>
        /// Solves a quadratic equation and displays the results
        /// </summary>
        /// <param name="a">Coefficient of x²</param>
        /// <param name="b">Coefficient of x</param>
        /// <param name="c">Constant term</param>
        public static void SolveQuadraticEquation(double a, double b, double c)
        {
            Console.WriteLine("\n=== Quadratic Equation Solver ===");
            Console.WriteLine($"Solving: {a}x² + {b}x + {c} = 0");
            
            var equation = new QuadraticEquation(a, b, c);
            Console.WriteLine($"Equation: {equation}");
            
            // Check if it's actually a quadratic equation
            if (Math.Abs(a) < 1e-10)
            {
                Console.WriteLine("Error: This is not a quadratic equation (a = 0).");
                Console.WriteLine("Please use the linear equation solver instead.");
                return;
            }
            
            var solution = equation.Solve();
            
            if (!solution.IsValid)
            {
                Console.WriteLine($"Error: {solution.ErrorMessage}");
                return;
            }
            
            Console.WriteLine($"Discriminant: {solution.Discriminant:F6}");
            Console.WriteLine($"Nature of roots: {solution.RootNature}");
            
            if (solution.RootNature.Contains("Complex"))
            {
                Console.WriteLine($"Complex roots:");
                Console.WriteLine($"  x₁ = {solution.Root1:F6} + {solution.ImaginaryPart:F6}i");
                Console.WriteLine($"  x₂ = {solution.Root1:F6} - {solution.ImaginaryPart:F6}i");
            }
            else
            {
                Console.WriteLine($"Roots:");
                Console.WriteLine($"  x₁ = {solution.Root1:F6}");
                Console.WriteLine($"  x₂ = {solution.Root2:F6}");
                
                // Verify the solutions
                bool verify1 = equation.VerifySolution(solution.Root1);
                bool verify2 = equation.VerifySolution(solution.Root2);
                
                Console.WriteLine($"Verification:");
                Console.WriteLine($"  x₁ verification: {(verify1 ? "✓ Correct" : "✗ Failed")}");
                Console.WriteLine($"  x₂ verification: {(verify2 ? "✓ Correct" : "✗ Failed")}");
            }
        }

        /// <summary>
        /// Displays the main menu
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("\n=== C# Equation Solver ===");
            Console.WriteLine("Solve linear and quadratic equations with step-by-step solutions");
            Console.WriteLine();
            Console.WriteLine("Choose equation type:");
            Console.WriteLine("1. Linear Equation (ax + b = 0)");
            Console.WriteLine("2. Quadratic Equation (ax² + bx + c = 0)");
            Console.WriteLine("3. Exit");
        }

        /// <summary>
        /// Displays information about the discriminant
        /// </summary>
        public static void DisplayDiscriminantInfo()
        {
            Console.WriteLine("\n=== Understanding the Discriminant ===");
            Console.WriteLine("The discriminant (Δ = b² - 4ac) determines the nature of quadratic equation roots:");
            Console.WriteLine();
            Console.WriteLine("• Δ > 0: Two real and distinct roots");
            Console.WriteLine("• Δ = 0: One real root (repeated)");
            Console.WriteLine("• Δ < 0: Two complex roots (no real solutions)");
            Console.WriteLine();
            Console.WriteLine("This is because the quadratic formula is:");
            Console.WriteLine("x = (-b ± √(b² - 4ac)) / (2a)");
            Console.WriteLine("The discriminant determines what's under the square root!");
        }
    }
}
