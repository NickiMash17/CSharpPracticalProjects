namespace InvestmentGrowthCalculator.Models
{
    /// <summary>
    /// Represents the parameters for investment growth calculations
    /// </summary>
    public class InvestmentParameters
    {
        /// <summary>
        /// Principal (initial investment amount)
        /// </summary>
        public double Principal { get; set; }

        /// <summary>
        /// Annual interest rate (as decimal, e.g., 5% = 0.05)
        /// </summary>
        public double InterestRate { get; set; }

        /// <summary>
        /// Start time in years
        /// </summary>
        public double StartTime { get; set; }

        /// <summary>
        /// End time in years
        /// </summary>
        public double EndTime { get; set; }

        /// <summary>
        /// Step size for time increments
        /// </summary>
        public double StepSize { get; set; }

        public InvestmentParameters(double principal, double interestRate, double startTime, double endTime, double stepSize)
        {
            Principal = principal;
            InterestRate = interestRate;
            StartTime = startTime;
            EndTime = endTime;
            StepSize = stepSize;
        }

        /// <summary>
        /// Validates that all parameters are valid
        /// </summary>
        /// <returns>True if all parameters are valid, false otherwise</returns>
        public bool IsValid()
        {
            return Principal > 0 && 
                   StartTime >= 0 && 
                   EndTime > StartTime && 
                   StepSize > 0 && 
                   StepSize <= (EndTime - StartTime);
        }
    }
} 