namespace SetOperationsSystem.Models
{
    /// <summary>
    /// Represents a student entity with identification and enrollment information
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the unique identifier for the student
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the student's full name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the student's email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the academic year of the student
        /// </summary>
        public int AcademicYear { get; set; }

        /// <summary>
        /// Initializes a new instance of the Student class
        /// </summary>
        public Student() { }

        /// <summary>
        /// Initializes a new instance of the Student class with specified parameters
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <param name="name">Student name</param>
        /// <param name="email">Student email</param>
        /// <param name="academicYear">Academic year</param>
        public Student(int id, string name, string email, int academicYear)
        {
            Id = id;
            Name = name;
            Email = email;
            AcademicYear = academicYear;
        }

        /// <summary>
        /// Returns a string representation of the student
        /// </summary>
        /// <returns>String representation of the student</returns>
        public override string ToString()
        {
            return $"Student(ID: {Id}, Name: {Name}, Email: {Email}, Year: {AcademicYear})";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current student
        /// </summary>
        /// <param name="obj">Object to compare with</param>
        /// <returns>True if objects are equal, false otherwise</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Student other)
            {
                return Id == other.Id;
            }
            return false;
        }

        /// <summary>
        /// Returns the hash code for the student
        /// </summary>
        /// <returns>Hash code based on student ID</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
} 