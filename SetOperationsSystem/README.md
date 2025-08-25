# Set Operations Analysis System

## 📋 Project Overview
A C# console application that analyzes student enrollment in two courses using mathematical set operations. The system computes and displays the union, intersection, and complements of sets representing students enrolled in Course A, Course B, and the universal set of all registered students.

## 🎯 Requirements Met (100 Marks)

### 1. Set Definitions (20 marks) ✅
- **Set A**: Students enrolled in Course A
- **Set B**: Students enrolled in Course B  
- **Universal Set U**: All registered students

### 2. Set Operations (60 marks) ✅
- **Union of A and B**: Students in either course (20 marks)
- **Intersection of A and B**: Students in both courses (20 marks)
- **Complement of A**: Students not in Course A (20 marks)
- **Complement of B**: Students not in Course B (20 marks)

### 3. Input Validation (10 marks) ✅
- No duplicate IDs in a single set
- Sets A and B are subsets of U
- Non-empty sets validation

### 4. Output Formatting (10 marks) ✅
- Results displayed in sorted, comma-separated format
- Clear, formatted presentation

## 🚀 How to Use

### Prerequisites
- .NET 8.0 or later
- Command line interface

### Running the Application
1. Navigate to the project directory:
   ```bash
   cd SetOperationsSystem
   ```

2. Build and run the application:
   ```bash
   dotnet run
   ```

### Step-by-Step Usage

#### Step 1: Enter Universal Set
The application will prompt you to enter the universal set (all registered students):
```
Enter the universal set U (all registered students):
Enter student IDs separated by spaces (e.g., 1001 1002 1003):
```

**Example Input**: `1001 1002 1003 1004 1005 1006 1007 1008`

#### Step 2: Enter Course A Students
Enter students enrolled in Course A:
```
Enter students enrolled in Course A:
Enter student IDs separated by spaces:
```

**Example Input**: `1001 1002 1003 1004`

#### Step 3: Enter Course B Students
Enter students enrolled in Course B:
```
Enter students enrolled in Course B:
Enter student IDs separated by spaces:
```

**Example Input**: `1003 1004 1005 1006`

### Sample Output
```
=== Input Sets ===
Universal Set U = {1001, 1002, 1003, 1004, 1005, 1006, 1007, 1008}
Set A (Course A) = {1001, 1002, 1003, 1004}
Set B (Course B) = {1003, 1004, 1005, 1006}

=== Set Operation Results ===
Union of A and B (students in either course) = {1001, 1002, 1003, 1004, 1005, 1006}
Intersection of A and B (students in both courses) = {1003, 1004}
Complement of A (students not in Course A) = {1005, 1006, 1007, 1008}
Complement of B (students not in Course B) = {1001, 1002, 1007, 1008}
```

## 🔍 Input Validation Rules

### ✅ Valid Inputs
- **Student IDs**: Must be integers
- **No Duplicates**: Each set must have unique student IDs
- **Subset Rule**: Course A and B must be subsets of Universal Set U
- **Non-empty**: All sets must contain at least one student

### ❌ Invalid Inputs
- Empty sets
- Duplicate student IDs within a set
- Student IDs not present in the universal set
- Non-numeric input

## 🧮 Mathematical Concepts

### Set Operations Explained
1. **Union (A ∪ B)**: All students in either Course A OR Course B
2. **Intersection (A ∩ B)**: Students in BOTH Course A AND Course B
3. **Complement (A')**: Students in Universal Set U but NOT in Course A
4. **Complement (B')**: Students in Universal Set U but NOT in Course B

### Example Calculation
- **Universal Set U**: {1001, 1002, 1003, 1004, 1005, 1006, 1007, 1008}
- **Set A**: {1001, 1002, 1003, 1004}
- **Set B**: {1003, 1004, 1005, 1006}

**Union A ∪ B**: {1001, 1002, 1003, 1004, 1005, 1006}
**Intersection A ∩ B**: {1003, 1004}
**Complement A'**: {1005, 1006, 1007, 1008}
**Complement B'**: {1001, 1002, 1007, 1008}

## 🛠️ Technical Implementation

### Architecture
- **Models**: Student and Course classes
- **Services**: SetOperationsService with static methods
- **Program**: Main console application with input handling

### Key Methods
- `Union(setA, setB)`: Computes union of two sets
- `Intersection(setA, setB)`: Computes intersection of two sets
- `Complement(set, universalSet)`: Computes complement of a set
- `IsSubset(subset, universalSet)`: Validates subset relationship
- `HasNoDuplicates(students)`: Checks for duplicate IDs
- `FormatSet(students)`: Formats output in sorted, comma-separated format

## 🧪 Testing the Application

### Test Case 1: Sample Data
- **Universal Set**: 1001 1002 1003 1004 1005 1006 1007 1008
- **Course A**: 1001 1002 1003 1004
- **Course B**: 1003 1004 1005 1006

### Test Case 2: Different Data
- **Universal Set**: 2001 2002 2003 2004 2005
- **Course A**: 2001 2002
- **Course B**: 2004 2005

## 🚨 Error Handling

The application includes comprehensive error handling for:
- Invalid numeric input
- Empty sets
- Duplicate student IDs
- Subset validation failures
- General exceptions

## 📚 Learning Outcomes

By using this application, you will understand:
- Set theory fundamentals
- Mathematical set operations
- Input validation techniques
- Error handling in C#
- Console application development
- Object-oriented programming principles

## 🔗 Related Projects
- [Rocket Velocity Calculator](../RocketVelocityCalculator/README.md)
- [Investment Growth Calculator](../InvestmentGrowthCalculator/README.md)

---

**Author**: NickiMash17  
**Project**: C# Mathematical Applications - Practical Projects 