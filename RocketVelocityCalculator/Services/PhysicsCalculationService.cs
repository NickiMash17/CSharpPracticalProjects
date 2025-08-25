namespace RocketVelocityCalculator.Services
{
    /// <summary>
    /// Service class for performing physics calculations related to rocket motion
    /// </summary>
    public class PhysicsCalculationService
    {
        /// <summary>
        /// Calculates rocket velocity using the formula v(t) = 3t²
        /// </summary>
        /// <param name="time">Time in seconds</param>
        /// <returns>Velocity in meters per second</returns>
        public static double CalculateVelocity(double time)
        {
            // Formula: v(t) = 3t²
            return 3 * Math.Pow(time, 2);
        }

        /// <summary>
        /// Calculates rocket position using the formula s(t) = t³
        /// </summary>
        /// <param name="time">Time in seconds</param>
        /// <returns>Position in meters</returns>
        public static double CalculatePosition(double time)
        {
            // Formula: s(t) = t³ (assuming initial position s(0) = 0)
            return Math.Pow(time, 3);
        }

        /// <summary>
        /// Validates that the time value is non-negative
        /// </summary>
        /// <param name="time">Time value to validate</param>
        /// <returns>True if time is valid, false otherwise</returns>
        public static bool IsValidTime(double time)
        {
            return time >= 0;
        }

        /// <summary>
        /// Formats the output string according to the specified format
        /// </summary>
        /// <param name="time">Time in seconds</param>
        /// <param name="velocity">Velocity in m/s</param>
        /// <param name="position">Position in meters</param>
        /// <returns>Formatted output string</returns>
        public static string FormatOutput(double time, double velocity, double position)
        {
            return $"At t={time} seconds, velocity is {velocity} m/s and position is {position} meters.";
        }
    }
} 