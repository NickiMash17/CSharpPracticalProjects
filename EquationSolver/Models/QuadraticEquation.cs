namespace EquationSolver.Models
{
    /// <summary>
    /// Represents a quadratic equation in the form ax² + bx + c = 0
    /// </summary>
    public class QuadraticEquation
    {
        /// <summary>
        /// Coefficient of x² (a)
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// Coefficient of x (b)
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Constant term (c)
        /// </summary>
        public double C { get; set; }

        /// <summary>
        /// Initializes a new instance of QuadraticEquation
        /// </summary>
        /// <param name="a">Coefficient of x²</param>
        /// <param name="b">Coefficient of x</param>
        /// <param name="c">Constant term</param>
        public QuadraticEquation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Calculates the discriminant (b² - 4ac)
        /// </summary>
        /// <returns>The discriminant value</returns>
        public double CalculateDiscriminant()
        {
            return B * B - 4 * A * C;
        }

        /// <summary>
        /// Determines the nature of the roots based on the discriminant
        /// </summary>
        /// <returns>String describing the nature of roots</returns>
        public string GetRootNature()
        {
            double discriminant = CalculateDiscriminant();
            
            if (Math.Abs(discriminant) < 1e-10)
                return "Real and equal (one repeated root)";
            else if (discriminant > 0)
                return "Real and distinct (two different roots)";
            else
                return "Complex (no real roots)";
        }

        /// <summary>
        /// Solves the quadratic equation using the quadratic formula
        /// </summary>
        /// <returns>QuadraticSolution containing the roots and nature</returns>
        public QuadraticSolution Solve()
        {
            if (Math.Abs(A) < 1e-10)
            {
                return new QuadraticSolution
                {
                    IsValid = false,
                    ErrorMessage = "This is not a quadratic equation (a = 0). Use linear equation solver instead."
                };
            }

            double discriminant = CalculateDiscriminant();
            string rootNature = GetRootNature();

            if (discriminant > 0)
            {
                // Two real and distinct roots
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double root1 = (-B + sqrtDiscriminant) / (2 * A);
                double root2 = (-B - sqrtDiscriminant) / (2 * A);

                return new QuadraticSolution
                {
                    IsValid = true,
                    Root1 = root1,
                    Root2 = root2,
                    RootNature = rootNature,
                    Discriminant = discriminant
                };
            }
            else if (Math.Abs(discriminant) < 1e-10)
            {
                // One real root (repeated)
                double root = -B / (2 * A);

                return new QuadraticSolution
                {
                    IsValid = true,
                    Root1 = root,
                    Root2 = root,
                    RootNature = rootNature,
                    Discriminant = discriminant
                };
            }
            else
            {
                // Complex roots
                double realPart = -B / (2 * A);
                double imaginaryPart = Math.Sqrt(-discriminant) / (2 * A);

                return new QuadraticSolution
                {
                    IsValid = true,
                    Root1 = realPart,
                    Root2 = realPart,
                    ImaginaryPart = imaginaryPart,
                    RootNature = rootNature,
                    Discriminant = discriminant
                };
            }
        }

        /// <summary>
        /// Verifies a solution by substituting it back into the equation
        /// </summary>
        /// <param name="x">The solution to verify</param>
        /// <returns>True if the solution is correct</returns>
        public bool VerifySolution(double x)
        {
            double leftSide = A * x * x + B * x + C;
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
                equation += "x²";
            else if (Math.Abs(A + 1) < 1e-10)
                equation += "-x²";
            else
                equation += $"{A}x²";

            // Handle coefficient b
            if (Math.Abs(B) > 1e-10)
            {
                if (B > 0)
                    equation += $" + {B}x";
                else
                    equation += $" - {Math.Abs(B)}x";
            }

            // Handle constant c
            if (Math.Abs(C) > 1e-10)
            {
                if (C > 0)
                    equation += $" + {C}";
                else
                    equation += $" - {Math.Abs(C)}";
            }

            equation += " = 0";
            return equation;
        }
    }

    /// <summary>
    /// Represents the solution to a quadratic equation
    /// </summary>
    public class QuadraticSolution
    {
        public bool IsValid { get; set; }
        public double Root1 { get; set; }
        public double Root2 { get; set; }
        public double ImaginaryPart { get; set; }
        public string RootNature { get; set; } = "";
        public double Discriminant { get; set; }
        public string ErrorMessage { get; set; } = "";
    }
}
