using System;
using System.Collections.Generic;
using RocketVelocityCalculator.Services;

namespace RocketVelocityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Rocket Velocity and Position Calculator";
            DisplayWelcomeHeader();

            try
            {
                // Define the required time t = 2 seconds as per requirements
                double time = 2.0;
                Console.WriteLine($"Required time: t = {time} seconds");

                // Calculate velocity and position using the service
                var motionData = PhysicsCalculationService.GetRocketMotionData(time);
                
                double velocity = (double)motionData["Velocity"];
                double position = (double)motionData["Position"];
                double acceleration = (double)motionData["Acceleration"];

                // Display basic results as required
                DisplayBasicResults(time, velocity, position, acceleration);

                // Display comprehensive analysis
                DisplayComprehensiveAnalysis(motionData);

                // Display additional calculations for different time points
                DisplayAdditionalCalculations();

                // Explain mathematical relationships
                DisplayMathematicalRelationships();

                // Allow interactive input
                HandleInteractiveTimeInput();
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=".PadRight(70, '='));
            Console.WriteLine("ROCKET VELOCITY AND POSITION CALCULATOR".PadLeft(50));
            Console.WriteLine("Physics Calculations System".PadLeft(45));
            Console.WriteLine("=".PadRight(70, '='));
            Console.ResetColor();
            Console.WriteLine();
        }

        static void DisplayBasicResults(double time, double velocity, double position, double acceleration)
        {
            Console.WriteLine("=== BASIC RESULTS (Required Output) ===");
            Console.WriteLine($"At t={time} seconds, velocity is {velocity} m/s and position is {position} meters.");
            Console.WriteLine($"Acceleration at t={time} seconds: {acceleration} m/s²");
            Console.WriteLine();
        }

        static void DisplayComprehensiveAnalysis(Dictionary<string, object> motionData)
        {
            Console.WriteLine("=== COMPREHENSIVE ANALYSIS ===");
            Console.WriteLine($"Time: {motionData["Time"]} seconds");
            Console.WriteLine($"Velocity: {motionData["Velocity"]:F2} m/s ({motionData["VelocityKph"]:F2} km/h)");
            Console.WriteLine($"Position: {motionData["Position"]:F2} meters ({motionData["PositionFeet"]:F2} feet)");
            Console.WriteLine($"Acceleration: {motionData["Acceleration"]:F2} m/s²");
            Console.WriteLine($"Kinetic Energy: {motionData["KineticEnergy"]:F2} J");
            Console.WriteLine($"Potential Energy: {motionData["PotentialEnergy"]:F2} J");
            Console.WriteLine($"Total Mechanical Energy: {motionData["TotalEnergy"]:F2} J");
            Console.WriteLine();
        }

        static void DisplayAdditionalCalculations()
        {
            Console.WriteLine("=== ADDITIONAL CALCULATIONS ===");
            
            double[] timePoints = { 0.5, 1.0, 1.5, 2.5, 3.0 };
            
            foreach (double t in timePoints)
            {
                try
                {
                    var data = PhysicsCalculationService.GetRocketMotionData(t);
                    Console.WriteLine($"t={t}s: v={data["Velocity"]:F2} m/s, s={data["Position"]:F2} m, a={data["Acceleration"]:F2} m/s²");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"t={t}s: Error - {ex.Message}");
                }
            }
            Console.WriteLine();
        }

        static void DisplayMathematicalRelationships()
        {
            Console.WriteLine("=== MATHEMATICAL RELATIONSHIPS ===");
            Console.WriteLine("• Velocity function: v(t) = 3t²");
            Console.WriteLine("• Position function: s(t) = t³");
            Console.WriteLine("• Acceleration function: a(t) = 6t (derivative of velocity)");
            Console.WriteLine("• Position is the integral of velocity: ∫v(t)dt = ∫3t²dt = t³ + C");
            Console.WriteLine("• At t=0: v(0)=0 m/s, s(0)=0 m, a(0)=0 m/s²");
            Console.WriteLine("• The rocket starts from rest and accelerates continuously");
            Console.WriteLine();
        }

        static void HandleInteractiveTimeInput()
        {
            Console.WriteLine("=== INTERACTIVE CALCULATIONS ===");
            Console.Write("Enter a custom time value (or press Enter to skip): ");
            
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && double.TryParse(input, out double customTime))
            {
                try
                {
                    var customData = PhysicsCalculationService.GetRocketMotionData(customTime);
                    DisplayCustomTimeResults(customTime, customData);
                }
                catch (Exception ex)
                {
                    DisplayError($"Error calculating for t={customTime}: {ex.Message}");
                }
            }
        }

        static void DisplayCustomTimeResults(double time, Dictionary<string, object> motionData)
        {
            Console.WriteLine($"\n--- Results for t = {time} seconds ---");
            Console.WriteLine($"Velocity: {motionData["Velocity"]:F2} m/s");
            Console.WriteLine($"Position: {motionData["Position"]:F2} meters");
            Console.WriteLine($"Acceleration: {motionData["Acceleration"]:F2} m/s²");
        }

        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR: {message}");
            Console.ResetColor();
        }
    }
} 