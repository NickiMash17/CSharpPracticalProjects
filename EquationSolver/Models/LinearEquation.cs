namespace EquationSolver.Models
{
    /// <summary>
    /// Represents a linear equation in the form ax + b = 0
    /// </summary>
    public class LinearEquation
    {
        /// <summary>
        /// Coefficient of x (a)
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// Constant term (b)
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Initializes a new instance of LinearEquation
        /// </summary>
        /// <param name="a">Coefficient of x</param>
        /// <param name="b">Constant term</param>
        public LinearEquation(double a, double b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Solves the linear equation ax + b = 0
        /// </summary>
        /// <returns>The solution x = -b/a, or null if a = 0</returns>
        public double? Solve()
        {
            if (Math.Abs(A) < 1e-10) // Check if a is effectively zero
            {
                return null; // No solution or infinite solutions
            }
            return -B / A;
        }

        /// <summary>
        /// Gets the equation type based on coefficients
        /// </summary>
        /// <returns>String describing the equation type</returns>
        public string GetEquationType()
        {
            if (Math.Abs(A) < 1e-10)
            {
                if (Math.Abs(B) < 1e-10)
                    return "Identity (0 = 0) - Infinite solutions";
                else
                    return "Contradiction (0 = b, b ≠ 0) - No solution";
            }
            return "Linear equation with unique solution";
        }

        /// <summary>
        /// Verifies a solution by substituting it back into the equation
        /// </summary>
        /// <param name="x">The solution to verify</param>
        /// <returns>True if the solution is correct</returns>
        public bool VerifySolution(double x)
        {
            double leftSide = A * x + B;
            return Math.Abs(leftSide) < 1e-10; // Check if left side equals 0
        }

        /// <summary>
        /// Returns the equation as a string
        /// </summary>
        /// <returns>Formatted equation string</returns>
        public override string ToString()
        {
            string equation = "";
            
            // Handle coefficient a
            if (Math.Abs(A - 1) < 1e-10)
                equation += "x";
            else if (Math.Abs(A + 1) < 1e-10)
                equation += "-x";
            else
                equation += $"{A}x";

            // Handle constant b
            if (B > 0)
                equation += $" + {B}";
            else if (B < 0)
                equation += $" - {Math.Abs(B)}";

            equation += " = 0";
            return equation;
        }
    }
}
