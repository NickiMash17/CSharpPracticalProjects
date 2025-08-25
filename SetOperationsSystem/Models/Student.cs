namespace SetOperationsSystem.Models
{
    /// <summary>
    /// Represents a student with a unique ID
    /// </summary>
    public class Student
    {
        public int Id { get; set; }

        public Student(int id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Student other)
                return Id == other.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
} 