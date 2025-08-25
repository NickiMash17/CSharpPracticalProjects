using System;
using System.Collections.Generic;
using RocketVelocityCalculator.Models;

namespace RocketVelocityCalculator.Services
{
    /// <summary>
    /// Service class for performing various physics calculations
    /// </summary>
    public class PhysicsCalculationService
    {
        /// <summary>
        /// Calculates the velocity of a rocket at a given time
        /// using the formula v(t) = 3t² meters per second
        /// </summary>
        /// <param name="time">Time in seconds</param>
        /// <returns>Velocity in meters per second</returns>
        /// <exception cref="ArgumentException">Thrown when time is negative</exception>
        public static double CalculateRocketVelocity(double time)
        {
            ValidateTime(time);
            
            // Calculate velocity using the formula v = 3 × t²
            double velocity = 3 * Math.Pow(time, 2);
            return velocity;
        }

        /// <summary>
        /// Calculates the position of a rocket at a given time
        /// using the formula s(t) = t³ meters (assuming initial position s(0) = 0)
        /// </summary>
        /// <param name="time">Time in seconds</param>
        /// <returns>Position in meters</returns>
        /// <exception cref="ArgumentException">Thrown when time is negative</exception>
        public static double CalculateRocketPosition(double time)
        {
            ValidateTime(time);
            
            // Calculate position using the formula s = t³
            double position = Math.Pow(time, 3);
            return position;
        }

        /// <summary>
        /// Calculates the acceleration of a rocket at a given time
        /// using the derivative of velocity: a(t) = dv/dt = 6t m/s²
        /// </summary>
        /// <param name="time">Time in seconds</param>
        /// <returns>Acceleration in meters per second squared</returns>
        /// <exception cref="ArgumentException">Thrown when time is negative</exception>
        public static double CalculateRocketAcceleration(double time)
        {
            ValidateTime(time);
            
            // Calculate acceleration using the derivative: a = 6t
            double acceleration = 6 * time;
            return acceleration;
        }

        /// <summary>
        /// Calculates the kinetic energy of a rocket
        /// using the formula KE = ½mv²
        /// </summary>
        /// <param name="mass">Mass of the rocket in kilograms</param>
        /// <param name="velocity">Velocity in meters per second</param>
        /// <returns>Kinetic energy in Joules</returns>
        public static double CalculateKineticEnergy(double mass, double velocity)
        {
            if (mass <= 0)
                throw new ArgumentException("Mass must be positive", nameof(mass));

            // Calculate kinetic energy using the formula KE = ½mv²
            double kineticEnergy = 0.5 * mass * Math.Pow(velocity, 2);
            return kineticEnergy;
        }

        /// <summary>
        /// Calculates the potential energy of a rocket due to gravity
        /// using the formula PE = mgh
        /// </summary>
        /// <param name="mass">Mass of the rocket in kilograms</param>
        /// <param name="height">Height above reference point in meters</param>
        /// <returns>Potential energy in Joules</returns>
        public static double CalculatePotentialEnergy(double mass, double height)
        {
            if (mass <= 0)
                throw new ArgumentException("Mass must be positive", nameof(mass));

            // Calculate potential energy using the formula PE = mgh
            double potentialEnergy = mass * PhysicsConstants.GravitationalAcceleration * height;
            return potentialEnergy;
        }

        /// <summary>
        /// Calculates the total mechanical energy of a rocket
        /// using the formula E = KE + PE
        /// </summary>
        /// <param name="mass">Mass of the rocket in kilograms</param>
        /// <param name="velocity">Velocity in meters per second</param>
        /// <param name="height">Height above reference point in meters</param>
        /// <returns>Total mechanical energy in Joules</returns>
        public static double CalculateTotalMechanicalEnergy(double mass, double velocity, double height)
        {
            double kineticEnergy = CalculateKineticEnergy(mass, velocity);
            double potentialEnergy = CalculatePotentialEnergy(mass, height);
            
            return kineticEnergy + potentialEnergy;
        }

        /// <summary>
        /// Converts velocity from meters per second to kilometers per hour
        /// </summary>
        /// <param name="velocityMps">Velocity in meters per second</param>
        /// <returns>Velocity in kilometers per hour</returns>
        public static double ConvertVelocityToKph(double velocityMps)
        {
            return velocityMps * PhysicsConstants.MpsToKph;
        }

        /// <summary>
        /// Converts position from meters to feet
        /// </summary>
        /// <param name="positionMeters">Position in meters</param>
        /// <returns>Position in feet</returns>
        public static double ConvertPositionToFeet(double positionMeters)
        {
            return positionMeters * PhysicsConstants.MetersToFeet;
        }

        /// <summary>
        /// Validates that the time parameter is non-negative
        /// </summary>
        /// <param name="time">Time value to validate</param>
        /// <exception cref="ArgumentException">Thrown when time is negative</exception>
        private static void ValidateTime(double time)
        {
            if (time < 0)
            {
                throw new ArgumentException("Time cannot be negative. Please enter a non-negative value.", nameof(time));
            }
        }

        /// <summary>
        /// Gets comprehensive rocket motion data for a given time
        /// </summary>
        /// <param name="time">Time in seconds</param>
        /// <param name="mass">Mass of the rocket in kilograms</param>
        /// <returns>Dictionary containing all motion parameters</returns>
        public static Dictionary<string, object> GetRocketMotionData(double time, double mass = 1000.0)
        {
            ValidateTime(time);
            
            if (mass <= 0)
                throw new ArgumentException("Mass must be positive", nameof(mass));

            var velocity = CalculateRocketVelocity(time);
            var position = CalculateRocketPosition(time);
            var acceleration = CalculateRocketAcceleration(time);
            var kineticEnergy = CalculateKineticEnergy(mass, velocity);
            var potentialEnergy = CalculatePotentialEnergy(mass, position);
            var totalEnergy = CalculateTotalMechanicalEnergy(mass, velocity, position);

            return new Dictionary<string, object>
            {
                ["Time"] = time,
                ["Velocity"] = velocity,
                ["Position"] = position,
                ["Acceleration"] = acceleration,
                ["KineticEnergy"] = kineticEnergy,
                ["PotentialEnergy"] = potentialEnergy,
                ["TotalEnergy"] = totalEnergy,
                ["VelocityKph"] = ConvertVelocityToKph(velocity),
                ["PositionFeet"] = ConvertPositionToFeet(position)
            };
        }
    }
} 