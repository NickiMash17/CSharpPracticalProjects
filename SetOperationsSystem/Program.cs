using SetOperationsSystem.Models;
using SetOperationsSystem.Services;

namespace SetOperationsSystem
{
    /// <summary>
    /// Main program for Set Operations Analysis System
    /// Implements student enrollment analysis with set operations
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Set Operations Analysis System ===");
            Console.WriteLine("Analyzing student enrollment in two courses\n");

            try
            {
                // Get user input for sets
                var universalSet = GetUniversalSet();
                var setA = GetCourseSet("Course A", universalSet);
                var setB = GetCourseSet("Course B", universalSet);

                // Validate all inputs
                ValidateInputs(setA, setB, universalSet);

                // Display input sets
                DisplayInputSets(setA, setB, universalSet);

                // Perform set operations
                var union = SetOperationsService.Union(setA, setB);
                var intersection = SetOperationsService.Intersection(setA, setB);
                var complementA = SetOperationsService.Complement(setA, universalSet);
                var complementB = SetOperationsService.Complement(setB, universalSet);

                // Display results
                DisplayResults(union, intersection, complementA, complementB);

                Console.WriteLine("\nPress any key to exit...");
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
        /// Gets the universal set of all registered students
        /// </summary>
        static HashSet<Student> GetUniversalSet()
        {
            Console.WriteLine("Enter the universal set U (all registered students):");
            Console.WriteLine("Enter student IDs separated by spaces (e.g., 1001 1002 1003):");
            
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Universal set cannot be empty.");

            var studentIds = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(id => int.Parse(id))
                                .ToList();

            var universalSet = new HashSet<Student>();
            foreach (var id in studentIds)
            {
                universalSet.Add(new Student(id));
            }

            if (!SetOperationsService.IsNonEmpty(universalSet))
                throw new ArgumentException("Universal set must contain at least one student.");

            if (!SetOperationsService.HasNoDuplicates(universalSet))
                throw new ArgumentException("Universal set cannot contain duplicate student IDs.");

            return universalSet;
        }

        /// <summary>
        /// Gets a course set from user input
        /// </summary>
        static HashSet<Student> GetCourseSet(string courseName, HashSet<Student> universalSet)
        {
            Console.WriteLine($"\nEnter students enrolled in {courseName}:");
            Console.WriteLine("Enter student IDs separated by spaces:");
            
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException($"{courseName} cannot be empty.");

            var studentIds = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(id => int.Parse(id))
                                .ToList();

            var courseSet = new HashSet<Student>();
            foreach (var id in studentIds)
            {
                courseSet.Add(new Student(id));
            }

            if (!SetOperationsService.IsNonEmpty(courseSet))
                throw new ArgumentException($"{courseName} must contain at least one student.");

            if (!SetOperationsService.HasNoDuplicates(courseSet))
                throw new ArgumentException($"{courseName} cannot contain duplicate student IDs.");

            return courseSet;
        }

        /// <summary>
        /// Validates all input sets
        /// </summary>
        static void ValidateInputs(HashSet<Student> setA, HashSet<Student> setB, HashSet<Student> universalSet)
        {
            if (!SetOperationsService.IsSubset(setA, universalSet))
                throw new ArgumentException("Set A must be a subset of the universal set.");

            if (!SetOperationsService.IsSubset(setB, universalSet))
                throw new ArgumentException("Set B must be a subset of the universal set.");
        }

        /// <summary>
        /// Displays the input sets
        /// </summary>
        static void DisplayInputSets(HashSet<Student> setA, HashSet<Student> setB, HashSet<Student> universalSet)
        {
            Console.WriteLine("\n=== Input Sets ===");
            Console.WriteLine($"Universal Set U = {SetOperationsService.FormatSet(universalSet)}");
            Console.WriteLine($"Set A (Course A) = {SetOperationsService.FormatSet(setA)}");
            Console.WriteLine($"Set B (Course B) = {SetOperationsService.FormatSet(setB)}");
        }

        /// <summary>
        /// Displays the results of all set operations
        /// </summary>
        static void DisplayResults(HashSet<Student> union, HashSet<Student> intersection, 
                                HashSet<Student> complementA, HashSet<Student> complementB)
        {
            Console.WriteLine("\n=== Set Operation Results ===");
            Console.WriteLine($"Union of A and B (students in either course) = {SetOperationsService.FormatSet(union)}");
            Console.WriteLine($"Intersection of A and B (students in both courses) = {SetOperationsService.FormatSet(intersection)}");
            Console.WriteLine($"Complement of A (students not in Course A) = {SetOperationsService.FormatSet(complementA)}");
            Console.WriteLine($"Complement of B (students not in Course B) = {SetOperationsService.FormatSet(complementB)}");
        }
    }
} 