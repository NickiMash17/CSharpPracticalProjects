using System;
using System.Collections.Generic;

namespace InvestmentGrowthCalculator.Models
{
    /// <summary>
    /// Represents the parameters for investment calculations
    /// </summary>
    public class InvestmentParameters
    {
        /// <summary>
        /// Gets or sets the principal amount (initial investment)
        /// </summary>
        public decimal Principal { get; set; }

        /// <summary>
        /// Gets or sets the annual interest rate as a decimal (e.g., 0.05 for 5%)
        /// </summary>
        public decimal AnnualInterestRate { get; set; }

        /// <summary>
        /// Gets or sets the start time in years
        /// </summary>
        public decimal StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time in years
        /// </summary>
        public decimal EndTime { get; set; }

        /// <summary>
        /// Gets or sets the step size for time calculations in years
        /// </summary>
        public decimal StepSize { get; set; }

        /// <summary>
        /// Gets or sets the compounding frequency per year
        /// </summary>
        public int CompoundingFrequency { get; set; }

        /// <summary>
        /// Initializes a new instance of the InvestmentParameters class
        /// </summary>
        public InvestmentParameters()
        {
            CompoundingFrequency = 1; // Default to annual compounding
        }

        /// <summary>
        /// Initializes a new instance of the InvestmentParameters class with specified parameters
        /// </summary>
        /// <param name="principal">Principal amount</param>
        /// <param name="annualInterestRate">Annual interest rate as decimal</param>
        /// <param name="startTime">Start time in years</param>
        /// <param name="endTime">End time in years</param>
        /// <param name="stepSize">Step size in years</param>
        public InvestmentParameters(decimal principal, decimal annualInterestRate, decimal startTime, decimal endTime, decimal stepSize)
        {
            Principal = principal;
            AnnualInterestRate = annualInterestRate;
            StartTime = startTime;
            EndTime = endTime;
            StepSize = stepSize;
            CompoundingFrequency = 1;
        }

        /// <summary>
        /// Gets the total time period in years
        /// </summary>
        public decimal TotalTimePeriod => EndTime - StartTime;

        /// <summary>
        /// Gets the number of time steps
        /// </summary>
        public int NumberOfSteps => (int)((EndTime - StartTime) / StepSize) + 1;

        /// <summary>
        /// Gets the annual interest rate as a percentage
        /// </summary>
        public decimal AnnualInterestRatePercentage => AnnualInterestRate * 100;

        /// <summary>
        /// Gets whether the investment will grow (positive interest rate)
        /// </summary>
        public bool WillGrow => AnnualInterestRate > 0;

        /// <summary>
        /// Gets whether the investment will depreciate (negative interest rate)
        /// </summary>
        public bool WillDepreciate => AnnualInterestRate < 0;

        /// <summary>
        /// Gets whether the investment will remain constant (zero interest rate)
        /// </summary>
        public bool WillRemainConstant => AnnualInterestRate == 0;

        /// <summary>
        /// Validates the investment parameters
        /// </summary>
        /// <returns>True if parameters are valid, false otherwise</returns>
        public bool IsValid()
        {
            return Principal > 0 && 
                   StartTime >= 0 && 
                   EndTime > StartTime && 
                   StepSize > 0 && 
                   StepSize <= TotalTimePeriod &&
                   CompoundingFrequency > 0;
        }

        /// <summary>
        /// Gets validation error messages if any
        /// </summary>
        /// <returns>Array of validation error messages</returns>
        public string[] GetValidationErrors()
        {
            var errors = new List<string>();

            if (Principal <= 0)
                errors.Add("Principal must be positive");

            if (StartTime < 0)
                errors.Add("Start time cannot be negative");

            if (EndTime <= StartTime)
                errors.Add("End time must be greater than start time");

            if (StepSize <= 0)
                errors.Add("Step size must be positive");

            if (StepSize > TotalTimePeriod)
                errors.Add("Step size cannot be larger than the total time period");

            if (CompoundingFrequency <= 0)
                errors.Add("Compounding frequency must be positive");

            return errors.ToArray();
        }

        /// <summary>
        /// Returns a string representation of the investment parameters
        /// </summary>
        /// <returns>String representation of the investment parameters</returns>
        public override string ToString()
        {
            return $"Investment(Principal: ${Principal:F2}, Rate: {AnnualInterestRatePercentage:F2}%, " +
                   $"Time: {StartTime:F1} to {EndTime:F1} years, Step: {StepSize:F2} years)";
        }
    }
} 