namespace SetOperationsSystem.Models
{
    /// <summary>
    /// Represents a course with enrolled students
    /// </summary>
    public class Course
    {
        public string Name { get; set; }
        public HashSet<Student> EnrolledStudents { get; set; }

        public Course(string name)
        {
            Name = name;
            EnrolledStudents = new HashSet<Student>();
        }

        public void AddStudent(Student student)
        {
            EnrolledStudents.Add(student);
        }

        public bool HasStudent(Student student)
        {
            return EnrolledStudents.Contains(student);
        }
    }
} 