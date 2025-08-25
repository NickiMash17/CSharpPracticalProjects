using InvestmentGrowthCalculator.Models;
using InvestmentGrowthCalculator.Services;

namespace InvestmentGrowthCalculator
{
    /// <summary>
    /// Main program for Investment Growth Calculator
    /// Implements continuous compound interest calculations with user input and file output
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Investment Growth Calculator ===");
            Console.WriteLine("Continuous Compound Interest Analysis\n");

            try
            {
                // Get user input for investment parameters
                var parameters = GetInvestmentParameters();
                
                // Validate all inputs
                if (!parameters.IsValid())
                {
                    throw new ArgumentException("Invalid investment parameters. Please check your inputs.");
                }

                // Generate investment table
                var results = FinancialCalculationService.GenerateInvestmentTable(parameters);

                // Display results
                FinancialCalculationService.DisplayInvestmentTable(results);
                FinancialCalculationService.DisplayAnalysis(results, parameters);

                // Offer option to save to file
                OfferFileSave(results, parameters);

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Gets investment parameters from user input
        /// </summary>
        /// <returns>InvestmentParameters object with user input</returns>
        static InvestmentParameters GetInvestmentParameters()
        {
            Console.WriteLine("Enter investment parameters:");

            // Get principal (P)
            double principal = GetDoubleInput("Principal (P) - Initial investment amount ($): ", 
                "Principal must be a positive number.");

            // Get interest rate (r)
            double interestRate = GetDoubleInput("Interest Rate (r) - Annual rate as decimal (e.g., 0.05 for 5%): ",
                "Interest rate must be a valid number.");

            // Get time range
            double startTime = GetDoubleInput("Start Time (t) - Beginning of time range (years): ",
                "Start time must be non-negative.");

            double endTime = GetDoubleInput("End Time (t) - End of time range (years): ",
                "End time must be greater than start time.");

            double stepSize = GetDoubleInput("Step Size - Time increment (years): ",
                "Step size must be positive and reasonable.");

            return new InvestmentParameters(principal, interestRate, startTime, endTime, stepSize);
        }

        /// <summary>
        /// Gets a double input from user with validation
        /// </summary>
        /// <param name="prompt">Input prompt message</param>
        /// <param name="errorMessage">Error message for invalid input</param>
        /// <returns>Valid double value</returns>
        static double GetDoubleInput(string prompt, string errorMessage)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    
                    if (double.TryParse(input, out double value))
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {errorMessage}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Offers user the option to save results to a file
        /// </summary>
        /// <param name="results">Investment calculation results</param>
        /// <param name="parameters">Investment parameters</param>
        static void OfferFileSave(List<(double Time, double Value)> results, InvestmentParameters parameters)
        {
            Console.Write("\nWould you like to save the results to a file? (y/n): ");
            string response = Console.ReadLine()?.ToLower();

            if (response == "y" || response == "yes")
            {
                string filename = "InvestmentGrowth.txt";
                FinancialCalculationService.SaveToFile(results, parameters, filename);
            }
            else
            {
                Console.WriteLine("Results not saved to file.");
            }
        }
    }
} 