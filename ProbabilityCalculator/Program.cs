using ProbabilityCalculator.Models;
using ProbabilityCalculator.Services;

namespace ProbabilityCalculator
{
    /// <summary>
    /// Main program for Probability Calculator
    /// Calculates probability of union of two events (mutually exclusive and inclusive)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Requirement 1: User Interface (15 marks)
            DisplayWelcomeMessage();
            
            bool continueCalculations = true;
            
            // Requirement 6: Program Flow (10 marks) - Allow multiple calculations
            while (continueCalculations)
            {
                try
                {
                    // Display menu and get user choice
                    int choice = GetUserChoice();
                    
                    switch (choice)
                    {
                        case 1:
                            HandleMutuallyExclusiveEvents();
                            break;
                        case 2:
                            HandleInclusiveEvents();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select 1 or 2.");
                            break;
                    }
                    
                    // Ask if user wants to continue
                    continueCalculations = AskToContinue();
                }
                catch (Exception ex)
                {
                    // Requirement 5: Error Handling (15 marks) - Handle unexpected errors
                    Console.WriteLine($"\nUnexpected error occurred: {ex.Message}");
                    Console.WriteLine("Please try again.");
                }
            }
            
            Console.WriteLine("\nThank you for using the Probability Calculator!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays the welcome message and program purpose
        /// </summary>
        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("=== C# Probability Calculator ===");
            Console.WriteLine("Calculate the probability of the union of two events");
            Console.WriteLine();
            Console.WriteLine("Formulas used:");
            Console.WriteLine("• Mutually Exclusive Events: P(A ∪ B) = P(A) + P(B)");
            Console.WriteLine("• Inclusive Events: P(A ∪ B) = P(A) + P(B) - P(A ∩ B)");
            Console.WriteLine();
        }

        /// <summary>
        /// Gets the user's choice between mutually exclusive and inclusive events
        /// </summary>
        /// <returns>User's choice (1 or 2)</returns>
        static int GetUserChoice()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Select event type:");
                    Console.WriteLine("1. Mutually Exclusive Events");
                    Console.WriteLine("2. Inclusive Events");
                    Console.Write("Enter your choice (1 or 2): ");
                    
                    string input = Console.ReadLine();
                    
                    if (int.TryParse(input, out int choice) && (choice == 1 || choice == 2))
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter 1 or 2.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Handles calculation for mutually exclusive events
        /// </summary>
        static void HandleMutuallyExclusiveEvents()
        {
            Console.WriteLine("\n--- Mutually Exclusive Events ---");
            
            // Requirement 2: Input Collection (20 marks) - Collect P(A) and P(B)
            var eventA = ProbabilityEvent.FromUserInput("Enter P(A) (probability of event A, 0 to 1): ");
            var eventB = ProbabilityEvent.FromUserInput("Enter P(B) (probability of event B, 0 to 1): ");
            
            // Requirement 4: Input Validation (15 marks) - Validate probabilities
            if (!ProbabilityCalculationService.CanBeMutuallyExclusive(eventA, eventB))
            {
                Console.WriteLine("Warning: These events may not be truly mutually exclusive.");
                Console.WriteLine($"P(A) + P(B) = {eventA.Probability + eventB.Probability:F4} > 1");
                Console.WriteLine("The result may exceed 100% probability.");
            }
            
            // Requirement 3: Probability Calculations (20 marks) - Calculate union
            double result = ProbabilityCalculationService.CalculateMutuallyExclusiveUnion(eventA, eventB);
            
            // Display calculation details
            ProbabilityCalculationService.DisplayMutuallyExclusiveCalculation(eventA, eventB, result);
        }

        /// <summary>
        /// Handles calculation for inclusive events
        /// </summary>
        static void HandleInclusiveEvents()
        {
            Console.WriteLine("\n--- Inclusive Events ---");
            
            // Requirement 2: Input Collection (20 marks) - Collect P(A), P(B), and P(A ∩ B)
            var eventA = ProbabilityEvent.FromUserInput("Enter P(A) (probability of event A, 0 to 1): ");
            var eventB = ProbabilityEvent.FromUserInput("Enter P(B) (probability of event B, 0 to 1): ");
            
            // Get and validate intersection probability
            double intersection = ProbabilityCalculationService.GetValidIntersectionProbability(
                "Enter P(A ∩ B) (probability of both events occurring, 0 to 1): ", 
                eventA, eventB);
            
            // Requirement 3: Probability Calculations (20 marks) - Calculate union
            double result = ProbabilityCalculationService.CalculateInclusiveUnion(eventA, eventB, intersection);
            
            // Display calculation details
            ProbabilityCalculationService.DisplayInclusiveCalculation(eventA, eventB, intersection, result);
        }

        /// <summary>
        /// Asks the user if they want to perform another calculation
        /// </summary>
        /// <returns>True if user wants to continue, false otherwise</returns>
        static bool AskToContinue()
        {
            while (true)
            {
                Console.Write("\nWould you like to perform another calculation? (y/n): ");
                string input = Console.ReadLine()?.ToLower();
                
                if (input == "y" || input == "yes")
                {
                    Console.WriteLine("\n" + new string('=', 50));
                    return true;
                }
                else if (input == "n" || input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
                }
            }
        }
    }
} 