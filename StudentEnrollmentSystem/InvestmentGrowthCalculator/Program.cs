using System;
using System.Collections.Generic;
using InvestmentGrowthCalculator.Models;
using InvestmentGrowthCalculator.Services;

namespace InvestmentGrowthCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Investment Growth Calculator - Continuous Compounding";
            DisplayWelcomeHeader();

            try
            {
                // Get investment parameters from user
                var parameters = GetInvestmentParameters();

                // Validate parameters
                if (!parameters.IsValid())
                {
                    var errors = parameters.GetValidationErrors();
                    DisplayValidationErrors(errors);
                    return;
                }

                // Generate investment time series
                var timeSeries = FinancialCalculationService.GenerateInvestmentTimeSeries(parameters);

                // Calculate growth statistics
                var statistics = FinancialCalculationService.CalculateGrowthStatistics(parameters, timeSeries);

                // Display results
                DisplayResults(parameters, timeSeries, statistics);

                // Display additional calculations
                DisplayAdditionalCalculations(parameters);

                // Offer to save results to file
                SaveResultsToFile(parameters, timeSeries, statistics);

                // Display compounding comparison
                DisplayCompoundingComparison(parameters);
            }
            catch (Exception ex)
            {
                DisplayError($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayWelcomeHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=".PadRight(70, '='));
            Console.WriteLine("INVESTMENT GROWTH CALCULATOR".PadLeft(50));
            Console.WriteLine("Continuous Compounding Analysis".PadLeft(45));
            Console.WriteLine("=".PadRight(70, '='));
            Console.ResetColor();
            Console.WriteLine();
        }

        static InvestmentParameters GetInvestmentParameters()
        {
            Console.WriteLine("=== INVESTMENT PARAMETERS ===");
            
            var principal = GetDecimalInput("Enter the principal amount ($): ", "Principal must be a positive number.", p => p > 0);
            var interestRate = GetDecimalInput("Enter the annual interest rate (as decimal, e.g., 0.05 for 5%): ", "Interest rate must be a valid decimal.", r => true);
            var startTime = GetDecimalInput("Enter the start time (years): ", "Start time must be non-negative.", t => t >= 0);
            var endTime = GetDecimalInput("Enter the end time (years): ", "End time must be greater than start time.", t => t > startTime);
            var stepSize = GetDecimalInput("Enter the step size (years): ", "Step size must be positive and reasonable.", s => s > 0 && s <= (endTime - startTime));

            return new InvestmentParameters(principal, interestRate, startTime, endTime, stepSize);
        }

        static decimal GetDecimalInput(string prompt, string errorMessage, Func<decimal, bool>? validator = null)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                {
                    if (validator == null || validator(value))
                    {
                        return value;
                    }
                }
                DisplayError(errorMessage);
            }
        }

        static void DisplayValidationErrors(string[] errors)
        {
            Console.WriteLine("\n=== VALIDATION ERRORS ===");
            foreach (var error in errors)
            {
                DisplayError(error);
            }
        }

        static void DisplayResults(InvestmentParameters parameters, (decimal time, decimal investmentValue)[] timeSeries, Dictionary<string, decimal> statistics)
        {
            Console.WriteLine("\n=== INVESTMENT GROWTH RESULTS ===");
            Console.WriteLine($"Investment Parameters: {parameters}");
            Console.WriteLine($"Total Time Period: {parameters.TotalTimePeriod:F2} years");
            Console.WriteLine($"Number of Data Points: {parameters.NumberOfSteps}");
            Console.WriteLine();

            // Display growth trend analysis
            Console.WriteLine("=== GROWTH TREND ANALYSIS ===");
            if (parameters.WillGrow)
            {
                Console.WriteLine($"✅ Investment will GROW at {parameters.AnnualInterestRatePercentage:F2}% annually");
                Console.WriteLine($"📈 Total growth: ${statistics["TotalGrowth"]:F2} ({statistics["TotalGrowthPercent"]:F2}%)");
                Console.WriteLine($"📊 Average annual growth rate: {statistics["AverageAnnualGrowthRate"]:F2}%");
            }
            else if (parameters.WillDepreciate)
            {
                Console.WriteLine($"⚠️  Investment will DEPRECIATE at {Math.Abs(parameters.AnnualInterestRatePercentage):F2}% annually");
                Console.WriteLine($"📉 Total loss: ${Math.Abs(statistics["TotalGrowth"]):F2} ({Math.Abs(statistics["TotalGrowthPercent"]):F2}%)");
            }
            else
            {
                Console.WriteLine($"➡️  Investment will remain CONSTANT (0% interest rate)");
            }
            Console.WriteLine();

            // Display time series table
            Console.WriteLine("=== TIME SERIES TABLE ===");
            Console.WriteLine("Time (Years) | Investment Value ($) | Growth ($) | Growth (%)");
            Console.WriteLine("-".PadRight(70, '-'));

            decimal previousValue = parameters.Principal;
            foreach (var (time, value) in timeSeries)
            {
                var growth = value - parameters.Principal;
                var growthPercent = parameters.Principal > 0 ? (growth / parameters.Principal) * 100 : 0;
                Console.WriteLine($"{time,11:F2} | {value,18:F2} | {growth,10:F2} | {growthPercent,10:F2}%");
            }
            Console.WriteLine();
        }

        static void DisplayAdditionalCalculations(InvestmentParameters parameters)
        {
            Console.WriteLine("=== ADDITIONAL CALCULATIONS ===");
            
            if (parameters.WillGrow)
            {
                var timeToDouble = FinancialCalculationService.CalculateTimeToDouble(parameters.AnnualInterestRate);
                Console.WriteLine($"⏰ Time to double investment (Rule of 72): {timeToDouble:F1} years");
                
                // Calculate value at specific milestones
                var milestones = new[] { 1.0m, 5.0m, 10.0m, 20.0m };
                foreach (var milestone in milestones)
                {
                    if (milestone <= parameters.EndTime)
                    {
                        var value = FinancialCalculationService.CalculateContinuousCompounding(
                            parameters.Principal, parameters.AnnualInterestRate, milestone);
                        Console.WriteLine($"📅 At {milestone} years: ${value:F2}");
                    }
                }
            }
            Console.WriteLine();
        }

        static void SaveResultsToFile(InvestmentParameters parameters, (decimal time, decimal investmentValue)[] timeSeries, Dictionary<string, decimal> statistics)
        {
            Console.Write("Would you like to save the results to 'InvestmentGrowth.txt'? (y/n): ");
            var response = Console.ReadLine()?.ToLower().Trim();

            if (response == "y" || response == "yes")
            {
                try
                {
                    using (var writer = new StreamWriter("InvestmentGrowth.txt"))
                    {
                        writer.WriteLine("INVESTMENT GROWTH ANALYSIS REPORT");
                        writer.WriteLine("=".PadRight(50, '='));
                        writer.WriteLine($"Generated: {DateTime.Now}");
                        writer.WriteLine();
                        
                        writer.WriteLine("INVESTMENT PARAMETERS:");
                        writer.WriteLine($"Principal: ${parameters.Principal:F2}");
                        writer.WriteLine($"Annual Interest Rate: {parameters.AnnualInterestRatePercentage:F2}%");
                        writer.WriteLine($"Time Period: {parameters.StartTime:F1} to {parameters.EndTime:F1} years");
                        writer.WriteLine($"Step Size: {parameters.StepSize:F2} years");
                        writer.WriteLine();

                        writer.WriteLine("GROWTH STATISTICS:");
                        writer.WriteLine($"Initial Value: ${statistics["InitialValue"]:F2}");
                        writer.WriteLine($"Final Value: ${statistics["FinalValue"]:F2}");
                        writer.WriteLine($"Total Growth: ${statistics["TotalGrowth"]:F2}");
                        writer.WriteLine($"Total Growth %: {statistics["TotalGrowthPercent"]:F2}%");
                        writer.WriteLine();

                        writer.WriteLine("TIME SERIES DATA:");
                        writer.WriteLine("Time (Years) | Investment Value ($)");
                        writer.WriteLine("-".PadRight(40, '-'));
                        foreach (var (time, value) in timeSeries)
                        {
                            writer.WriteLine($"{time,11:F2} | {value,18:F2}");
                        }
                    }
                    Console.WriteLine("✅ Results saved to 'InvestmentGrowth.txt'");
                }
                catch (Exception ex)
                {
                    DisplayError($"Error saving file: {ex.Message}");
                }
            }
            Console.WriteLine();
        }

        static void DisplayCompoundingComparison(InvestmentParameters parameters)
        {
            Console.WriteLine("=== COMPOUNDING COMPARISON ===");
            Console.WriteLine("Comparing different compounding frequencies for 1 year:");
            Console.WriteLine($"Principal: ${parameters.Principal:F2}, Rate: {parameters.AnnualInterestRatePercentage:F2}%");
            Console.WriteLine();

            var frequencies = new[] { 1, 2, 4, 12, 365 };
            var time = 1.0m;

            Console.WriteLine("Frequency | Value ($) | Difference from Annual");
            Console.WriteLine("-".PadRight(50, '-'));

            var annualValue = FinancialCalculationService.CalculateContinuousCompounding(
                parameters.Principal, parameters.AnnualInterestRate, time);

            foreach (var frequency in frequencies)
            {
                var value = FinancialCalculationService.CalculateContinuousCompounding(
                    parameters.Principal, parameters.AnnualInterestRate, time);
                var difference = value - annualValue;
                
                string frequencyName = frequency switch
                {
                    1 => "Annual",
                    2 => "Semi-annual",
                    4 => "Quarterly",
                    12 => "Monthly",
                    365 => "Daily",
                    _ => $"{frequency}x/year"
                };

                Console.WriteLine($"{frequencyName,9} | {value,9:F2} | {difference,8:F2}");
            }
            Console.WriteLine();
        }

        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {message}");
            Console.ResetColor();
        }
    }
} 