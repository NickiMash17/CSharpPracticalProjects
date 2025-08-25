using System;
using System.Collections.Generic;
using System.Linq;
using SetOperationsSystem.Models;
using SetOperationsSystem.Services;

namespace SetOperationsSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Set Operations Analysis System - Student Enrollment";
            DisplayWelcomeHeader();

            try
            {
                // Get user input for sets
                var universalSet = GetUniversalSet();
                var setA = GetCourseSet("Course A", universalSet);
                var setB = GetCourseSet("Course B", universalSet);

                // Validate that both sets are subsets of the universal set
                if (!SetOperationsService.IsSubset(setA, universalSet) || !SetOperationsService.IsSubset(setB, universalSet))
                {
                    DisplayError("Error: Course sets must be subsets of the universal set!");
                    return;
                }

                // Compute set operations
                var union = SetOperationsService.ComputeUnion(setA, setB);
                var intersection = SetOperationsService.ComputeIntersection(setA, setB);
                var complementA = SetOperationsService.ComputeComplement(setA, universalSet);
                var complementB = SetOperationsService.ComputeComplement(setB, universalSet);

                // Get statistics
                var statistics = SetOperationsService.GetSetStatistics(universalSet, setA, setB);

                // Display results
                DisplayResults(universalSet, setA, setB, union, intersection, complementA, complementB, statistics);

                // Display additional analysis
                DisplayAnalysis(statistics);
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=".PadRight(70, '='));
            Console.WriteLine("SET OPERATIONS ANALYSIS SYSTEM".PadLeft(50));
            Console.WriteLine("Student Enrollment Analysis".PadLeft(45));
            Console.WriteLine("=".PadRight(70, '='));
            Console.ResetColor();
            Console.WriteLine();
        }

        static HashSet<Student> GetUniversalSet()
        {
            Console.WriteLine("=== UNIVERSAL SET (All Registered Students) ===");
            Console.Write("Enter the number of students in the universal set: ");
            
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                throw new ArgumentException("Please enter a valid positive number for the universal set size.");
            }

            var universalSet = new HashSet<Student>();
            Console.WriteLine($"\nEnter details for {count} students:");

            for (int i = 1; i <= count; i++)
            {
                var student = GetStudentInput(i);
                if (!universalSet.Add(student))
                {
                    throw new ArgumentException($"Student with ID {student.Id} already exists in the universal set.");
                }
            }

            return universalSet;
        }

        static HashSet<Student> GetCourseSet(string courseName, HashSet<Student> universalSet)
        {
            Console.WriteLine($"\n=== {courseName.ToUpper()} ENROLLMENT ===");
            Console.Write($"Enter the number of students enrolled in {courseName}: ");
            
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                throw new ArgumentException($"Please enter a valid positive number for {courseName} enrollment.");
            }

            if (count > universalSet.Count)
            {
                throw new ArgumentException($"{courseName} enrollment cannot exceed the universal set size.");
            }

            var courseSet = new HashSet<Student>();
            Console.WriteLine($"\nEnter student IDs for {courseName} (must exist in universal set):");

            for (int i = 1; i <= count; i++)
            {
                Console.Write($"Student {i} ID: ");
                if (!int.TryParse(Console.ReadLine(), out int studentId))
                {
                    throw new ArgumentException("Please enter a valid student ID.");
                }

                var student = universalSet.FirstOrDefault(s => s.Id == studentId);
                if (student == null)
                {
                    throw new ArgumentException($"Student with ID {studentId} not found in the universal set.");
                }

                if (!courseSet.Add(student))
                {
                    throw new ArgumentException($"Student with ID {studentId} is already enrolled in {courseName}.");
                }
            }

            return courseSet;
        }

        static Student GetStudentInput(int studentNumber)
        {
            Console.WriteLine($"\n--- Student {studentNumber} ---");
            
            Console.Write("Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                throw new ArgumentException("Please enter a valid positive student ID.");
            }

            Console.Write("Student Name: ");
            var name = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Student name cannot be empty.");
            }

            Console.Write("Student Email: ");
            var email = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Student email cannot be empty.");
            }

            Console.Write("Academic Year (1-4): ");
            if (!int.TryParse(Console.ReadLine(), out int year) || year < 1 || year > 4)
            {
                throw new ArgumentException("Please enter a valid academic year (1-4).");
            }

            return new Student(id, name, email, year);
        }

        static void DisplayResults(
            HashSet<Student> universalSet, 
            HashSet<Student> setA, 
            HashSet<Student> setB,
            HashSet<Student> union, 
            HashSet<Student> intersection, 
            HashSet<Student> complementA, 
            HashSet<Student> complementB,
            Dictionary<string, object> statistics)
        {
            Console.WriteLine("\n" + "=".PadRight(70, '='));
            Console.WriteLine("SET OPERATIONS RESULTS".PadLeft(50));
            Console.WriteLine("=".PadRight(70, '='));

            DisplayInputSets(universalSet, setA, setB);
            DisplaySetOperations(union, intersection, complementA, complementB);
        }

        static void DisplayInputSets(HashSet<Student> universalSet, HashSet<Student> setA, HashSet<Student> setB)
        {
            Console.WriteLine("\n--- INPUT SETS ---");
            
            Console.WriteLine($"Universal Set U ({universalSet.Count} students):");
            DisplayStudentList(SetOperationsService.SortStudentsById(universalSet));
            
            Console.WriteLine($"\nSet A - Course A ({setA.Count} students):");
            DisplayStudentList(SetOperationsService.SortStudentsById(setA));
            
            Console.WriteLine($"\nSet B - Course B ({setB.Count} students):");
            DisplayStudentList(SetOperationsService.SortStudentsById(setB));
        }

        static void DisplaySetOperations(
            HashSet<Student> union, 
            HashSet<Student> intersection, 
            HashSet<Student> complementA, 
            HashSet<Student> complementB)
        {
            Console.WriteLine("\n--- SET OPERATIONS ---");
            
            Console.WriteLine($"Union A ∪ B ({union.Count} students):");
            DisplayStudentList(SetOperationsService.SortStudentsById(union));
            
            Console.WriteLine($"\nIntersection A ∩ B ({intersection.Count} students):");
            DisplayStudentList(SetOperationsService.SortStudentsById(intersection));
            
            Console.WriteLine($"\nComplement of A ({complementA.Count} students):");
            DisplayStudentList(SetOperationsService.SortStudentsById(complementA));
            
            Console.WriteLine($"\nComplement of B ({complementB.Count} students):");
            DisplayStudentList(SetOperationsService.SortStudentsById(complementB));
        }

        static void DisplayStudentList(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("  (Empty set)");
                return;
            }

            var studentIds = students.Select(s => s.Id.ToString());
            Console.WriteLine($"  {{{string.Join(", ", studentIds)}}}");
        }

        static void DisplayAnalysis(Dictionary<string, object> statistics)
        {
            Console.WriteLine("\n--- ANALYSIS ---");
            Console.WriteLine($"Total students: {statistics["UniversalSetCount"]}");
            Console.WriteLine($"Students in Course A only: {statistics["OnlyInA"]}");
            Console.WriteLine($"Students in Course B only: {statistics["OnlyInB"]}");
            Console.WriteLine($"Students in both courses: {statistics["InBothCourses"]}");
            Console.WriteLine($"Students not in Course A: {statistics["ComplementACount"]}");
            Console.WriteLine($"Students not in Course B: {statistics["ComplementBCount"]}");
        }

        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR: {message}");
            Console.ResetColor();
        }
    }
} 