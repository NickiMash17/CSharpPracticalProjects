using SetOperationsSystem.Models;

namespace SetOperationsSystem.Services
{
    /// <summary>
    /// Service class for performing set operations on student enrollment data
    /// </summary>
    public class SetOperationsService
    {
        /// <summary>
        /// Computes the union of two sets (students in either course)
        /// </summary>
        public static HashSet<Student> Union(HashSet<Student> setA, HashSet<Student> setB)
        {
            var union = new HashSet<Student>(setA);
            foreach (var student in setB)
            {
                union.Add(student);
            }
            return union;
        }

        /// <summary>
        /// Computes the intersection of two sets (students in both courses)
        /// </summary>
        public static HashSet<Student> Intersection(HashSet<Student> setA, HashSet<Student> setB)
        {
            var intersection = new HashSet<Student>();
            foreach (var student in setA)
            {
                if (setB.Contains(student))
                {
                    intersection.Add(student);
                }
            }
            return intersection;
        }

        /// <summary>
        /// Computes the complement of set A (students not in Course A)
        /// </summary>
        public static HashSet<Student> Complement(HashSet<Student> setA, HashSet<Student> universalSet)
        {
            var complement = new HashSet<Student>();
            foreach (var student in universalSet)
            {
                if (!setA.Contains(student))
                {
                    complement.Add(student);
                }
            }
            return complement;
        }

        /// <summary>
        /// Validates that a set is a subset of the universal set
        /// </summary>
        public static bool IsSubset(HashSet<Student> subset, HashSet<Student> universalSet)
        {
            foreach (var student in subset)
            {
                if (!universalSet.Contains(student))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Validates that a set has no duplicate IDs
        /// </summary>
        public static bool HasNoDuplicates(HashSet<Student> students)
        {
            var ids = new HashSet<int>();
            foreach (var student in students)
            {
                if (ids.Contains(student.Id))
                {
                    return false;
                }
                ids.Add(student.Id);
            }
            return true;
        }

        /// <summary>
        /// Validates that a set is non-empty
        /// </summary>
        public static bool IsNonEmpty(HashSet<Student> students)
        {
            return students.Count > 0;
        }

        /// <summary>
        /// Sorts students by ID and returns as comma-separated string
        /// </summary>
        public static string FormatSet(HashSet<Student> students)
        {
            if (students.Count == 0)
                return "{}";

            var sortedStudents = students.OrderBy(s => s.Id).ToList();
            return "{" + string.Join(", ", sortedStudents) + "}";
        }
    }
} 