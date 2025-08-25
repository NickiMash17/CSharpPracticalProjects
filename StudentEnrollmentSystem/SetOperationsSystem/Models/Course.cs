namespace SetOperationsSystem.Models
{
    /// <summary>
    /// Represents a course entity with enrollment information
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the course code (e.g., "CS101", "MATH201")
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the course name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the course description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the maximum number of students allowed in the course
        /// </summary>
        public int MaxCapacity { get; set; }

        /// <summary>
        /// Gets or sets the current number of enrolled students
        /// </summary>
        public int CurrentEnrollment { get; set; }

        /// <summary>
        /// Initializes a new instance of the Course class
        /// </summary>
        public Course() { }

        /// <summary>
        /// Initializes a new instance of the Course class with specified parameters
        /// </summary>
        /// <param name="id">Course ID</param>
        /// <param name="code">Course code</param>
        /// <param name="name">Course name</param>
        /// <param name="description">Course description</param>
        /// <param name="maxCapacity">Maximum capacity</param>
        public Course(int id, string code, string name, string description, int maxCapacity)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            MaxCapacity = maxCapacity;
            CurrentEnrollment = 0;
        }

        /// <summary>
        /// Gets the available capacity for the course
        /// </summary>
        public int AvailableCapacity => MaxCapacity - CurrentEnrollment;

        /// <summary>
        /// Gets whether the course is full
        /// </summary>
        public bool IsFull => CurrentEnrollment >= MaxCapacity;

        /// <summary>
        /// Gets the enrollment percentage
        /// </summary>
        public double EnrollmentPercentage => MaxCapacity > 0 ? (double)CurrentEnrollment / MaxCapacity * 100 : 0;

        /// <summary>
        /// Returns a string representation of the course
        /// </summary>
        /// <returns>String representation of the course</returns>
        public override string ToString()
        {
            return $"Course(ID: {Id}, Code: {Code}, Name: {Name}, Enrollment: {CurrentEnrollment}/{MaxCapacity})";
        }
    }
} 