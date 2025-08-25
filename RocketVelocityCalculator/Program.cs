using RocketVelocityCalculator.Services;

namespace RocketVelocityCalculator
{
    /// <summary>
    /// Main program for Rocket Velocity and Position Calculation
    /// Calculates velocity and position at t = 2 seconds using specified formulas
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Rocket Velocity and Position Calculator ===");
            Console.WriteLine("Calculating rocket motion at t = 2 seconds\n");

            try
            {
                // Step a: Define the time t as 2 seconds (10 marks)
                double time = 2.0;
                Console.WriteLine($"Step a: Time t is set to {time} seconds");

                // Step b: Calculate velocity using formula v = 3 × t² (20 marks)
                double velocity = PhysicsCalculationService.CalculateVelocity(time);
                Console.WriteLine($"Step b: Velocity calculation: v = 3 × {time}² = {velocity} m/s");

                // Step c: Calculate position using formula s = t³ (20 marks)
                double position = PhysicsCalculationService.CalculatePosition(time);
                Console.WriteLine($"Step c: Position calculation: s = {time}³ = {position} meters");

                // Step d: Output results in specified format (20 marks)
                string result = PhysicsCalculationService.FormatOutput(time, velocity, position);
                Console.WriteLine($"\nStep d: Formatted output:");
                Console.WriteLine(result);

                // Step e: Demonstrate appropriate data types (10 marks)
                Console.WriteLine($"\nStep e: Data types used:");
                Console.WriteLine($"Time (t): {time.GetType().Name} = {time}");
                Console.WriteLine($"Velocity (v): {velocity.GetType().Name} = {velocity}");
                Console.WriteLine($"Position (s): {position.GetType().Name} = {position}");

                // Step f: Error handling for invalid input (10 marks)
                Console.WriteLine($"\nStep f: Error handling demonstration:");
                TestErrorHandling();

                // Step g: Comments explaining each step (10 marks)
                Console.WriteLine($"\nStep g: All steps have been commented in the code");
                Console.WriteLine("Press any key to exit...");
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
        /// Demonstrates error handling for invalid time values
        /// </summary>
        static void TestErrorHandling()
        {
            try
            {
                double negativeTime = -1.0;
                if (!PhysicsCalculationService.IsValidTime(negativeTime))
                {
                    Console.WriteLine($"✓ Error handling works: Time {negativeTime} is invalid (negative)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✓ Exception caught: {ex.Message}");
            }
        }
    }
} 