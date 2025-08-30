using ProbabilityCalculator.Models;

namespace ProbabilityCalculator.Services
{
    /// <summary>
    /// Service class for performing probability calculations
    /// </summary>
    public class ProbabilityCalculationService
    {
        /// <summary>
        /// Calculates the probability of the union of two mutually exclusive events
        /// Formula: P(A ∪ B) = P(A) + P(B)
        /// </summary>
        /// <param name="eventA">First probability event</param>
        /// <param name="eventB">Second probability event</param>
        /// <returns>The probability of the union of the two events</returns>
        public static double CalculateMutuallyExclusiveUnion(ProbabilityEvent eventA, ProbabilityEvent eventB)
        {
            // For mutually exclusive events: P(A ∪ B) = P(A) + P(B)
            return eventA.Probability + eventB.Probability;
        }

        /// <summary>
        /// Calculates the probability of the union of two inclusive (non-mutually exclusive) events
        /// Formula: P(A ∪ B) = P(A) + P(B) - P(A ∩ B)
        /// </summary>
        /// <param name="eventA">First probability event</param>
        /// <param name="eventB">Second probability event</param>
        /// <param name="intersection">The probability of the intersection P(A ∩ B)</param>
        /// <returns>The probability of the union of the two events</returns>
        public static double CalculateInclusiveUnion(ProbabilityEvent eventA, ProbabilityEvent eventB, double intersection)
        {
            // For inclusive events: P(A ∪ B) = P(A) + P(B) - P(A ∩ B)
            return eventA.Probability + eventB.Probability - intersection;
        }

        /// <summary>
        /// Validates that two events can be mutually exclusive
        /// </summary>
        /// <param name="eventA">First probability event</param>
        /// <param name="eventB">Second probability event</param>
        /// <returns>True if the events can be mutually exclusive</returns>
        public static bool CanBeMutuallyExclusive(ProbabilityEvent eventA, ProbabilityEvent eventB)
        {
            // For events to be mutually exclusive, their union cannot exceed 1
            return (eventA.Probability + eventB.Probability) <= 1;
        }

        /// <summary>
        /// Formats a probability value for display
        /// </summary>
        /// <param name="probability">The probability value</param>
        /// <returns>Formatted string with 4 decimal places</returns>
        public static string FormatProbability(double probability)
        {
            return $"{probability:F4} ({probability * 100:F2}%)";
        }

        /// <summary>
        /// Displays the calculation details for mutually exclusive events
        /// </summary>
        /// <param name="eventA">First probability event</param>
        /// <param name="eventB">Second probability event</param>
        /// <param name="result">The calculated union probability</param>
        public static void DisplayMutuallyExclusiveCalculation(ProbabilityEvent eventA, ProbabilityEvent eventB, double result)
        {
            Console.WriteLine("\n=== Mutually Exclusive Events Calculation ===");
            Console.WriteLine($"P(A) = {eventA}");
            Console.WriteLine($"P(B) = {eventB}");
            Console.WriteLine($"Formula: P(A ∪ B) = P(A) + P(B)");
            Console.WriteLine($"Calculation: {eventA.Probability:F4} + {eventB.Probability:F4} = {result:F4}");
            Console.WriteLine($"Result: P(A ∪ B) = {FormatProbability(result)}");
        }

        /// <summary>
        /// Displays the calculation details for inclusive events
        /// </summary>
        /// <param name="eventA">First probability event</param>
        /// <param name="eventB">Second probability event</param>
        /// <param name="intersection">The intersection probability</param>
        /// <param name="result">The calculated union probability</param>
        public static void DisplayInclusiveCalculation(ProbabilityEvent eventA, ProbabilityEvent eventB, double intersection, double result)
        {
            Console.WriteLine("\n=== Inclusive Events Calculation ===");
            Console.WriteLine($"P(A) = {eventA}");
            Console.WriteLine($"P(B) = {eventB}");
            Console.WriteLine($"P(A ∩ B) = {FormatProbability(intersection)}");
            Console.WriteLine($"Formula: P(A ∪ B) = P(A) + P(B) - P(A ∩ B)");
            Console.WriteLine($"Calculation: {eventA.Probability:F4} + {eventB.Probability:F4} - {intersection:F4} = {result:F4}");
            Console.WriteLine($"Result: P(A ∪ B) = {FormatProbability(result)}");
        }

        /// <summary>
        /// Validates intersection probability input from user
        /// </summary>
        /// <param name="prompt">The prompt message to display</param>
        /// <param name="eventA">First probability event</param>
        /// <param name="eventB">Second probability event</param>
        /// <returns>Valid intersection probability</returns>
        public static double GetValidIntersectionProbability(string prompt, ProbabilityEvent eventA, ProbabilityEvent eventB)
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
                        if (ProbabilityEvent.IsValidIntersection(eventA, eventB, value))
                        {
                            return value;
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid intersection probability.");
                            Console.WriteLine($"P(A ∩ B) must be between 0 and min(P(A), P(B)) = {Math.Min(eventA.Probability, eventB.Probability):F4}");
                            Console.WriteLine($"And P(A ∩ B) must be at least max(0, P(A) + P(B) - 1) = {Math.Max(0, eventA.Probability + eventB.Probability - 1):F4}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a valid number.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
} 