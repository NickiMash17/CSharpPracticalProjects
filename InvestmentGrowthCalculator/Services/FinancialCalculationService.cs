using InvestmentGrowthCalculator.Models;

namespace InvestmentGrowthCalculator.Services
{
    /// <summary>
    /// Service class for performing financial calculations related to investment growth
    /// </summary>
    public class FinancialCalculationService
    {
        /// <summary>
        /// Calculates investment value using continuous compound interest formula: A = P * e^(rt)
        /// </summary>
        /// <param name="principal">Initial investment amount</param>
        /// <param name="interestRate">Annual interest rate (as decimal)</param>
        /// <param name="time">Time in years</param>
        /// <returns>Final investment value</returns>
        public static double CalculateInvestmentValue(double principal, double interestRate, double time)
        {
            // Formula: A = P * e^(rt)
            // Using Math.Exp for e^(rt) calculation
            return principal * Math.Exp(interestRate * time);
        }

        /// <summary>
        /// Generates a table of investment values over a time range
        /// </summary>
        /// <param name="parameters">Investment parameters</param>
        /// <returns>List of tuples containing time and investment value</returns>
        public static List<(double Time, double Value)> GenerateInvestmentTable(InvestmentParameters parameters)
        {
            var results = new List<(double Time, double Value)>();
            
            for (double time = parameters.StartTime; time <= parameters.EndTime; time += parameters.StepSize)
            {
                double value = CalculateInvestmentValue(parameters.Principal, parameters.InterestRate, time);
                results.Add((time, value));
            }
            
            return results;
        }

        /// <summary>
        /// Calculates percentage change from initial to final value
        /// </summary>
        /// <param name="initialValue">Initial investment value</param>
        /// <param name="finalValue">Final investment value</param>
        /// <returns>Percentage change</returns>
        public static double CalculatePercentageChange(double initialValue, double finalValue)
        {
            if (initialValue == 0) return 0;
            return ((finalValue - initialValue) / initialValue) * 100;
        }

        /// <summary>
        /// Determines if investment is growing or depreciating
        /// </summary>
        /// <param name="interestRate">Annual interest rate</param>
        /// <returns>Growth trend description</returns>
        public static string DetermineGrowthTrend(double interestRate)
        {
            if (interestRate > 0)
                return "growing";
            else if (interestRate < 0)
                return "depreciating";
            else
                return "stable (no change)";
        }

        /// <summary>
        /// Saves investment table to a text file
        /// </summary>
        /// <param name="results">Investment calculation results</param>
        /// <param name="parameters">Investment parameters</param>
        /// <param name="filename">Output filename</param>
        public static void SaveToFile(List<(double Time, double Value)> results, InvestmentParameters parameters, string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("=== Investment Growth Analysis ===");
                    writer.WriteLine($"Principal: ${parameters.Principal:F2}");
                    writer.WriteLine($"Interest Rate: {parameters.InterestRate:P2}");
                    writer.WriteLine($"Time Range: {parameters.StartTime} to {parameters.EndTime} years");
                    writer.WriteLine($"Step Size: {parameters.StepSize} years");
                    writer.WriteLine();
                    
                    writer.WriteLine("Time (years)\tInvestment Value ($)");
                    writer.WriteLine("----------------------------------------");
                    
                    foreach (var (time, value) in results)
                    {
                        writer.WriteLine($"{time:F2}\t\t${value:F2}");
                    }
                    
                    writer.WriteLine();
                    writer.WriteLine($"Initial Value: ${parameters.Principal:F2}");
                    writer.WriteLine($"Final Value: ${results.Last().Value:F2}");
                    
                    double percentageChange = CalculatePercentageChange(parameters.Principal, results.Last().Value);
                    writer.WriteLine($"Percentage Change: {percentageChange:F2}%");
                    
                    string trend = DetermineGrowthTrend(parameters.InterestRate);
                    writer.WriteLine($"Growth Trend: Investment is {trend}");
                }
                
                Console.WriteLine($"✓ Results saved to {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        /// <summary>
        /// Displays the investment table in formatted output
        /// </summary>
        /// <param name="results">Investment calculation results</param>
        public static void DisplayInvestmentTable(List<(double Time, double Value)> results)
        {
            Console.WriteLine("\n=== Investment Growth Table ===");
            Console.WriteLine("Time (years)\tInvestment Value ($)");
            Console.WriteLine("----------------------------------------");
            
            foreach (var (time, value) in results)
            {
                Console.WriteLine($"{time:F2}\t\t${value:F2}");
            }
        }

        /// <summary>
        /// Displays investment analysis summary
        /// </summary>
        /// <param name="results">Investment calculation results</param>
        /// <param name="parameters">Investment parameters</param>
        public static void DisplayAnalysis(List<(double Time, double Value)> results, InvestmentParameters parameters)
        {
            Console.WriteLine("\n=== Investment Analysis ===");
            Console.WriteLine($"Initial Investment: ${parameters.Principal:F2}");
            Console.WriteLine($"Interest Rate: {parameters.InterestRate:P2}");
            Console.WriteLine($"Final Value: ${results.Last().Value:F2}");
            
            double percentageChange = CalculatePercentageChange(parameters.Principal, results.Last().Value);
            Console.WriteLine($"Percentage Change: {percentageChange:F2}%");
            
            string trend = DetermineGrowthTrend(parameters.InterestRate);
            Console.WriteLine($"Growth Trend: Investment is {trend}");
        }
    }
} 