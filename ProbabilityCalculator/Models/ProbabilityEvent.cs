namespace ProbabilityCalculator.Models
{
    /// <summary>
    /// Represents a probability event with validation and calculation capabilities
    /// </summary>
    public class ProbabilityEvent
    {
        private double _probability;

        /// <summary>
        /// Gets or sets the probability value (must be between 0 and 1)
        /// </summary>
        public double Probability
        {
            get => _probability;
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Probability must be between 0 and 1");
                }
                _probability = value;
            }
        }

        /// <summary>
        /// Gets the probability as a percentage
        /// </summary>
        public double Percentage => Probability * 100;

        /// <summary>
        /// Initializes a new instance of ProbabilityEvent with the specified probability
        /// </summary>
        /// <param name="probability">The probability value (0 to 1)</param>
        public ProbabilityEvent(double probability)
        {
            Probability = probability;
        }

        /// <summary>
        /// Creates a ProbabilityEvent from user input with validation
        /// </summary>
        /// <param name="prompt">The prompt message to display</param>
        /// <returns>A valid ProbabilityEvent instance</returns>
        public static ProbabilityEvent FromUserInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Error: Input cannot be empty. Please enter a valid probability.");
                        continue;
                    }

                    if (double.TryParse(input, out double value))
                    {
                        return new ProbabilityEvent(value);
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a valid number.");
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Validates that the intersection probability is valid for two events
        /// </summary>
        /// <param name="eventA">First probability event</param>
        /// <param name="eventB">Second probability event</param>
        /// <param name="intersection">Intersection probability to validate</param>
        /// <returns>True if the intersection probability is valid</returns>
        public static bool IsValidIntersection(ProbabilityEvent eventA, ProbabilityEvent eventB, double intersection)
        {
            if (intersection < 0 || intersection > 1)
                return false;

            // P(A ∩ B) cannot be greater than P(A) or P(B)
            if (intersection > eventA.Probability || intersection > eventB.Probability)
                return false;

            // P(A ∩ B) cannot be less than P(A) + P(B) - 1 (for inclusive events)
            double minIntersection = Math.Max(0, eventA.Probability + eventB.Probability - 1);
            if (intersection < minIntersection)
                return false;

            return true;
        }

        /// <summary>
        /// Returns a string representation of the probability
        /// </summary>
        /// <returns>Formatted probability string</returns>
        public override string ToString()
        {
            return $"{Probability:F4} ({Percentage:F2}%)";
        }
    }
} 