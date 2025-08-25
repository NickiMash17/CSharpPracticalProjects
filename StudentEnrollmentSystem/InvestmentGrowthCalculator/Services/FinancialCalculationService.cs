using System;
using System.Collections.Generic;
using InvestmentGrowthCalculator.Models;
using System.Linq; // Added for Max and Min

namespace InvestmentGrowthCalculator.Services
{
    /// <summary>
    /// Service class for performing various financial calculations
    /// </summary>
    public class FinancialCalculationService
    {
        /// <summary>
        /// Mathematical constant e (base of natural logarithm)
        /// </summary>
        private const double E = 2.718281828459045;

        /// <summary>
        /// Calculates investment growth using continuous compounding formula
        /// A = P × e^(rt)
        /// </summary>
        /// <param name="principal">Initial investment amount</param>
        /// <param name="interestRate">Annual interest rate as decimal</param>
        /// <param name="time">Time in years</param>
        /// <returns>Final investment value</returns>
        public static decimal CalculateContinuousCompounding(decimal principal, decimal interestRate, decimal time)
        {
            if (principal <= 0)
                throw new ArgumentException("Principal must be positive", nameof(principal));

            if (time < 0)
                throw new ArgumentException("Time cannot be negative", nameof(time));

            // Convert to double for Math.Exp calculation, then back to decimal
            double p = (double)principal;
            double r = (double)interestRate;
            double t = (double)time;

            double result = p * Math.Exp(r * t);
            return (decimal)result;
        }

        /// <summary>
        /// Calculates the time required to double an investment (Rule of 72 approximation)
        /// t ≈ 72 / (r × 100)
        /// </summary>
        /// <param name="interestRate">Annual interest rate as decimal</param>
        /// <returns>Time to double in years</returns>
        public static decimal CalculateTimeToDouble(decimal interestRate)
        {
            if (interestRate <= 0)
                throw new ArgumentException("Interest rate must be positive", nameof(interestRate));

            // Rule of 72: t ≈ 72 / (r × 100)
            return 72.0m / (interestRate * 100);
        }

        /// <summary>
        /// Generates a time series of investment values using continuous compounding
        /// </summary>
        /// <param name="parameters">Investment parameters</param>
        /// <returns>Array of time and investment value pairs</returns>
        public static (decimal time, decimal investmentValue)[] GenerateInvestmentTimeSeries(InvestmentParameters parameters)
        {
            if (!parameters.IsValid())
            {
                var errors = parameters.GetValidationErrors();
                throw new ArgumentException($"Invalid investment parameters: {string.Join(", ", errors)}");
            }

            var results = new List<(decimal time, decimal investmentValue)>();
            
            for (decimal time = parameters.StartTime; time <= parameters.EndTime; time += parameters.StepSize)
            {
                decimal investmentValue = CalculateContinuousCompounding(
                    parameters.Principal, 
                    parameters.AnnualInterestRate, 
                    time);
                
                results.Add((time, investmentValue));
            }

            return results.ToArray();
        }

        /// <summary>
        /// Calculates investment growth statistics
        /// </summary>
        /// <param name="parameters">Investment parameters</param>
        /// <param name="timeSeries">Time series data</param>
        /// <returns>Dictionary containing growth statistics</returns>
        public static Dictionary<string, object> CalculateGrowthStatistics(
            InvestmentParameters parameters, 
            (decimal time, decimal investmentValue)[] timeSeries)
        {
            if (timeSeries == null || timeSeries.Length == 0)
                throw new ArgumentException("Time series cannot be null or empty", nameof(timeSeries));

            var initialValue = timeSeries[0].investmentValue;
            var finalValue = timeSeries[^1].investmentValue;
            var totalGrowth = finalValue - initialValue;
            var totalGrowthPercent = initialValue > 0 ? (totalGrowth / initialValue) * 100 : 0;

            // Calculate average annual growth rate
            var totalTime = parameters.EndTime - parameters.StartTime;
            var averageAnnualGrowthRate = totalTime > 0 ? 
                (Math.Pow((double)(finalValue / initialValue), 1.0 / (double)totalTime) - 1) : 0;

            // Find maximum and minimum values
            var maxValue = timeSeries.Max(x => x.investmentValue);
            var minValue = timeSeries.Min(x => x.investmentValue);
            var maxValueTime = timeSeries.First(x => x.investmentValue == maxValue).time;
            var minValueTime = timeSeries.First(x => x.investmentValue == minValue).time;

            return new Dictionary<string, object>
            {
                ["InitialValue"] = initialValue,
                ["FinalValue"] = finalValue,
                ["TotalGrowth"] = totalGrowth,
                ["TotalGrowthPercent"] = totalGrowthPercent,
                ["AverageAnnualGrowthRate"] = (decimal)averageAnnualGrowthRate,
                ["MaxValue"] = maxValue,
                ["MaxValueTime"] = maxValueTime,
                ["MinValue"] = minValue,
                ["MinValueTime"] = minValueTime,
                ["TotalTimePeriod"] = totalTime,
                ["NumberOfDataPoints"] = timeSeries.Length
            };
        }
    }
} 