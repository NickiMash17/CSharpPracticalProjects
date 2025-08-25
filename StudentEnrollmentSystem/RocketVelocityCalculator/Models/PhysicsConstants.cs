namespace RocketVelocityCalculator.Models
{
    /// <summary>
    /// Contains commonly used physical constants and conversion factors
    /// </summary>
    public static class PhysicsConstants
    {
        /// <summary>
        /// Gravitational acceleration on Earth (m/s²)
        /// </summary>
        public const double GravitationalAcceleration = 9.81;

        /// <summary>
        /// Speed of light in vacuum (m/s)
        /// </summary>
        public const double SpeedOfLight = 299792458.0;

        /// <summary>
        /// Planck's constant (J⋅s)
        /// </summary>
        public const double PlancksConstant = 6.62607015e-34;

        /// <summary>
        /// Boltzmann constant (J/K)
        /// </summary>
        public const double BoltzmannConstant = 1.380649e-23;

        /// <summary>
        /// Avogadro's number (mol⁻¹)
        /// </summary>
        public const double AvogadroNumber = 6.02214076e23;

        /// <summary>
        /// Universal gas constant (J/(mol⋅K))
        /// </summary>
        public const double UniversalGasConstant = 8.314462618;

        /// <summary>
        /// Elementary charge (C)
        /// </summary>
        public const double ElementaryCharge = 1.602176634e-19;

        /// <summary>
        /// Electron mass (kg)
        /// </summary>
        public const double ElectronMass = 9.1093837015e-31;

        /// <summary>
        /// Proton mass (kg)
        /// </summary>
        public const double ProtonMass = 1.67262192369e-27;

        /// <summary>
        /// Neutron mass (kg)
        /// </summary>
        public const double NeutronMass = 1.67492749804e-27;

        /// <summary>
        /// Conversion factor from meters to feet
        /// </summary>
        public const double MetersToFeet = 3.28084;

        /// <summary>
        /// Conversion factor from feet to meters
        /// </summary>
        public const double FeetToMeters = 0.3048;

        /// <summary>
        /// Conversion factor from meters per second to kilometers per hour
        /// </summary>
        public const double MpsToKph = 3.6;

        /// <summary>
        /// Conversion factor from kilometers per hour to meters per second
        /// </summary>
        public const double KphToMps = 0.277778;

        /// <summary>
        /// Conversion factor from degrees to radians
        /// </summary>
        public const double DegreesToRadians = Math.PI / 180.0;

        /// <summary>
        /// Conversion factor from radians to degrees
        /// </summary>
        public const double RadiansToDegrees = 180.0 / Math.PI;
    }
} 