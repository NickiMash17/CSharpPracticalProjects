using System;
using System.Collections.Generic;
using System.Linq;
using SetOperationsSystem.Models;

namespace SetOperationsSystem.Services
{
    /// <summary>
    /// Service class for performing set operations on student enrollment data
    /// </summary>
    public class SetOperationsService
    {
        /// <summary>
        /// Computes the union of two sets of students
        /// </summary>
        /// <param name="setA">First set of students</param>
        /// <param name="setB">Second set of students</param>
        /// <returns>Union of the two sets</returns>
        public static HashSet<Student> ComputeUnion(HashSet<Student> setA, HashSet<Student> setB)
        {
            if (setA == null || setB == null)
                throw new ArgumentNullException("Sets cannot be null");

            var union = new HashSet<Student>(setA);
            union.UnionWith(setB);
            return union;
        }

        /// <summary>
        /// Computes the intersection of two sets of students
        /// </summary>
        /// <param name="setA">First set of students</param>
        /// <param name="setB">Second set of students</param>
        /// <returns>Intersection of the two sets</returns>
        public static HashSet<Student> ComputeIntersection(HashSet<Student> setA, HashSet<Student> setB)
        {
            if (setA == null || setB == null)
                throw new ArgumentNullException("Sets cannot be null");

            var intersection = new HashSet<Student>(setA);
            intersection.IntersectWith(setB);
            return intersection;
        }

        /// <summary>
        /// Computes the complement of a set relative to the universal set
        /// </summary>
        /// <param name="set">The set to find the complement of</param>
        /// <param name="universalSet">The universal set</param>
        /// <returns>Complement of the set</returns>
        public static HashSet<Student> ComputeComplement(HashSet<Student> set, HashSet<Student> universalSet)
        {
            if (set == null || universalSet == null)
                throw new ArgumentNullException("Sets cannot be null");

            var complement = new HashSet<Student>(universalSet);
            complement.ExceptWith(set);
            return complement;
        }

        /// <summary>
        /// Computes the difference between two sets (A - B)
        /// </summary>
        /// <param name="setA">First set</param>
        /// <param name="setB">Second set</param>
        /// <returns>Elements in A that are not in B</returns>
        public static HashSet<Student> ComputeDifference(HashSet<Student> setA, HashSet<Student> setB)
        {
            if (setA == null || setB == null)
                throw new ArgumentNullException("Sets cannot be null");

            var difference = new HashSet<Student>(setA);
            difference.ExceptWith(setB);
            return difference;
        }

        /// <summary>
        /// Computes the symmetric difference of two sets
        /// </summary>
        /// <param name="setA">First set</param>
        /// <param name="setB">Second set</param>
        /// <returns>Symmetric difference of the two sets</returns>
        public static HashSet<Student> ComputeSymmetricDifference(HashSet<Student> setA, HashSet<Student> setB)
        {
            if (setA == null || setB == null)
                throw new ArgumentNullException("Sets cannot be null");

            var union = ComputeUnion(setA, setB);
            var intersection = ComputeIntersection(setA, setB);
            var symmetricDifference = new HashSet<Student>(union);
            symmetricDifference.ExceptWith(intersection);
            return symmetricDifference;
        }

        /// <summary>
        /// Validates that a set is a subset of the universal set
        /// </summary>
        /// <param name="set">The set to validate</param>
        /// <param name="universalSet">The universal set</param>
        /// <returns>True if the set is a subset, false otherwise</returns>
        public static bool IsSubset(HashSet<Student> set, HashSet<Student> universalSet)
        {
            if (set == null || universalSet == null)
                throw new ArgumentNullException("Sets cannot be null");

            return set.IsSubsetOf(universalSet);
        }

        /// <summary>
        /// Gets statistical information about the sets
        /// </summary>
        /// <param name="universalSet">Universal set</param>
        /// <param name="setA">First set</param>
        /// <param name="setB">Second set</param>
        /// <returns>Dictionary containing statistical information</returns>
        public static Dictionary<string, object> GetSetStatistics(
            HashSet<Student> universalSet, 
            HashSet<Student> setA, 
            HashSet<Student> setB)
        {
            if (universalSet == null || setA == null || setB == null)
                throw new ArgumentNullException("Sets cannot be null");

            var union = ComputeUnion(setA, setB);
            var intersection = ComputeIntersection(setA, setB);
            var complementA = ComputeComplement(setA, universalSet);
            var complementB = ComputeComplement(setB, universalSet);

            return new Dictionary<string, object>
            {
                ["UniversalSetCount"] = universalSet.Count,
                ["SetACount"] = setA.Count,
                ["SetBCount"] = setB.Count,
                ["UnionCount"] = union.Count,
                ["IntersectionCount"] = intersection.Count,
                ["ComplementACount"] = complementA.Count,
                ["ComplementBCount"] = complementB.Count,
                ["OnlyInA"] = setA.Count - intersection.Count,
                ["OnlyInB"] = setB.Count - intersection.Count,
                ["InBothCourses"] = intersection.Count
            };
        }

        /// <summary>
        /// Sorts a set of students by their ID
        /// </summary>
        /// <param name="students">Set of students to sort</param>
        /// <returns>Sorted list of students</returns>
        public static List<Student> SortStudentsById(HashSet<Student> students)
        {
            if (students == null)
                throw new ArgumentNullException("Students set cannot be null");

            return students.OrderBy(s => s.Id).ToList();
        }

        /// <summary>
        /// Sorts a set of students by their name
        /// </summary>
        /// <param name="students">Set of students to sort</param>
        /// <returns>Sorted list of students</returns>
        public static List<Student> SortStudentsByName(HashSet<Student> students)
        {
            if (students == null)
                throw new ArgumentNullException("Students set cannot be null");

            return students.OrderBy(s => s.Name).ToList();
        }
    }
} 