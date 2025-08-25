# 🚀 Complete User Guide - C# Mathematical Applications

## 📋 Table of Contents
1. [Getting Started](#getting-started)
2. [Set Operations System](#set-operations-system)
3. [Rocket Velocity Calculator](#rocket-velocity-calculator)
4. [Investment Growth Calculator](#investment-growth-calculator)
5. [Troubleshooting](#troubleshooting)
6. [Advanced Usage](#advanced-usage)

---

## 🚀 Getting Started

### System Requirements
- **Operating System**: Windows 10+, macOS 10.15+, or Linux (Ubuntu 18.04+)
- **.NET Runtime**: .NET 8.0 or later
- **Memory**: At least 512MB RAM
- **Storage**: 100MB free space

### Installation Steps

#### Step 1: Install .NET 8.0
1. Visit [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
2. Download .NET 8.0 Runtime for your operating system
3. Run the installer and follow the prompts
4. Verify installation by opening a terminal/command prompt and typing:
   ```bash
   dotnet --version
   ```
   You should see: `8.0.x`

#### Step 2: Clone the Repository
```bash
git clone https://github.com/NickiMash17/CSharpPracticalProjects.git
cd CSharpPracticalProjects
```

#### Step 3: Build the Solution
```bash
dotnet build
```
You should see: `Build succeeded.`

---

## 🧮 Set Operations System

### What It Does
The Set Operations System analyzes student enrollment in two courses using mathematical set theory. It computes:
- **Union**: Students in either course
- **Intersection**: Students in both courses  
- **Complements**: Students not in each course

### How to Use

#### Running the Application
```bash
cd SetOperationsSystem
dotnet run
```

#### Step-by-Step Input

**Step 1: Enter Universal Set**
```
Enter the universal set U (all registered students):
Enter student IDs separated by spaces (e.g., 1001 1002 1003):
```
**Type**: `1001 1002 1003 1004 1005 1006 1007 1008`
**Press**: Enter

**Step 2: Enter Course A Students**
```
Enter students enrolled in Course A:
Enter student IDs separated by spaces:
```
**Type**: `1001 1002 1003 1004`
**Press**: Enter

**Step 3: Enter Course B Students**
```
Enter students enrolled in Course B:
Enter student IDs separated by spaces:
```
**Type**: `1003 1004 1005 1006`
**Press**: Enter

#### Expected Output
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

#### Input Rules
- ✅ **Valid**: Student IDs as integers separated by spaces
- ❌ **Invalid**: Empty input, duplicate IDs, IDs not in universal set
- 📝 **Format**: Numbers separated by single spaces

---

## 🚀 Rocket Velocity Calculator

### What It Does
The Rocket Velocity Calculator computes rocket velocity and position at t = 2 seconds using specific physics formulas:
- **Velocity**: v(t) = 3t² meters per second
- **Position**: s(t) = t³ meters

### How to Use

#### Running the Application
```bash
cd RocketVelocityCalculator
dotnet run
```

#### What Happens Automatically
The application runs automatically and shows:

**Step-by-Step Calculations:**
```
Step a: Time t is set to 2 seconds
Step b: Velocity calculation: v = 3 × 2² = 12 m/s
Step c: Position calculation: s = 2³ = 8 meters
```

**Formatted Output:**
```
At t=2 seconds, velocity is 12 m/s and position is 8 meters.
```

**Data Type Information:**
```
Time (t): Double = 2
Velocity (v): Double = 12
Position (s): Double = 8
```

**Error Handling Demo:**
```
✓ Error handling works: Time -1 is invalid (negative)
```

#### No User Input Required
This application runs automatically and demonstrates:
- ✅ Mathematical calculations
- ✅ Proper output formatting
- ✅ Error handling
- ✅ Data type usage
- ✅ Code commenting

---

## 💰 Investment Growth Calculator

### What It Does
The Investment Growth Calculator models continuous compound interest using the formula A = P × e^(rt). It:
- Calculates investment growth over time
- Displays results in a formatted table
- Provides growth analysis
- Offers file export functionality

### How to Use

#### Running the Application
```bash
cd InvestmentGrowthCalculator
dotnet run
```

#### Step-by-Step Input

**Step 1: Principal Amount**
```
Principal (P) - Initial investment amount ($): 1000
```
**Type**: `1000` (for $1,000 investment)
**Press**: Enter

**Step 2: Interest Rate**
```
Interest Rate (r) - Annual rate as decimal (e.g., 0.05 for 5%): 0.05
```
**Type**: `0.05` (for 5% annual growth)
**Press**: Enter

**Step 3: Start Time**
```
Start Time (t) - Beginning of time range (years): 0
```
**Type**: `0` (start from beginning)
**Press**: Enter

**Step 4: End Time**
```
End Time (t) - End of time range (years): 5
```
**Type**: `5` (5-year analysis period)
**Press**: Enter

**Step 5: Step Size**
```
Step Size - Time increment (years): 1
```
**Type**: `1` (yearly increments)
**Press**: Enter

#### Expected Output

**Investment Growth Table:**
```
=== Investment Growth Table ===
Time (years)    Investment Value ($)
----------------------------------------
0.00            $1000.00
1.00            $1051.27
2.00            $1105.17
3.00            $1161.83
4.00            $1221.40
5.00            $1284.03
```

**Investment Analysis:**
```
=== Investment Analysis ===
Initial Investment: $1000.00
Interest Rate: 5.00%
Final Value: $1284.03
Percentage Change: 28.40%
Growth Trend: Investment is growing
```

**File Export Option:**
```
Would you like to save the results to a file? (y/n): y
✓ Results saved to InvestmentGrowth.txt
```

#### Input Rules
- ✅ **Principal**: Must be positive (> 0)
- ✅ **Interest Rate**: Can be positive (growth) or negative (depreciation)
- ✅ **Time Range**: Start < End, both non-negative
- ✅ **Step Size**: Must be positive and reasonable

---

## 🚨 Troubleshooting

### Common Issues and Solutions

#### Build Errors

**Error**: `Could not find a part of the path`
**Solution**: Ensure you're in the correct directory
```bash
pwd  # Check current directory
cd CSharpPracticalProjects  # Navigate to project root
```

**Error**: `The framework 'Microsoft.NETCore.App', version '6.0.0' was not found`
**Solution**: Update project files to .NET 8.0 or install .NET 6.0
```bash
# Check installed .NET versions
dotnet --list-runtimes

# Install .NET 8.0 if needed
# Visit: https://dotnet.microsoft.com/download
```

#### Runtime Errors

**Error**: `Cannot read keys when console input is redirected`
**Solution**: This is normal when running with piped input. The application still works correctly.

**Error**: `Input string was not in a correct format`
**Solution**: Ensure you're entering valid numbers
- Use decimal points (e.g., `0.05` not `5%`)
- Don't include currency symbols
- Use spaces to separate multiple numbers

#### File Permission Errors

**Error**: `Access to the path is denied`
**Solution**: Check file permissions and directory access
```bash
# On Linux/Mac, check permissions
ls -la

# On Windows, run as administrator if needed
```

### Getting Help

1. **Check the individual project README files** for detailed guides
2. **Verify .NET installation**: `dotnet --version`
3. **Check project structure**: Ensure all files are present
4. **Review error messages**: They often contain specific solutions

---

## 🔧 Advanced Usage

### Customizing Calculations

#### Set Operations System
You can modify the `Program.cs` file to:
- Change input prompts
- Add new validation rules
- Modify output formatting
- Add new set operations

#### Rocket Velocity Calculator
You can modify the time value in `Program.cs`:
```csharp
// Change this line to test different times
double time = 3.0; // Instead of 2.0
```

#### Investment Growth Calculator
You can modify the `FinancialCalculationService.cs` to:
- Add new financial formulas
- Change output formats
- Add new analysis features
- Modify file export options

### Batch Processing

#### Running All Projects
```bash
# Build all projects
dotnet build

# Run all projects in sequence
cd SetOperationsSystem && dotnet run && cd ..
cd RocketVelocityCalculator && dotnet run && cd ..
cd InvestmentGrowthCalculator && dotnet run && cd ..
```

#### Automated Testing
Create a test script to validate all projects:
```bash
#!/bin/bash
echo "Testing Set Operations System..."
cd SetOperationsSystem
echo "1001 1002 1003 1004 1005 1006 1007 1008" | dotnet run
cd ..

echo "Testing Rocket Velocity Calculator..."
cd RocketVelocityCalculator
dotnet run
cd ..

echo "Testing Investment Growth Calculator..."
cd InvestmentGrowthCalculator
echo -e "1000\n0.05\n0\n5\n1" | dotnet run
cd ..
```

### Integration with Other Tools

#### Visual Studio Code
1. Open the project folder in VS Code
2. Install C# extension
3. Use integrated terminal for running projects
4. Use debugging features for step-by-step execution

#### Visual Studio
1. Open `CSharpPracticalProjects.sln`
2. Set startup project
3. Use debugging tools
4. Use IntelliSense for code completion

---

## 📚 Learning Resources

### Mathematical Concepts
- **Set Theory**: [Khan Academy Set Theory](https://www.khanacademy.org/math/statistics-probability/probability-library)
- **Physics Formulas**: [Physics Classroom](https://www.physicsclassroom.com/)
- **Financial Mathematics**: [Investopedia Compound Interest](https://www.investopedia.com/terms/c/compoundinterest.asp)

### C# Programming
- **Microsoft Learn**: [C# Fundamentals](https://docs.microsoft.com/en-us/learn/paths/csharp-first-steps/)
- **YouTube**: Search for "C# Console Applications Tutorial"
- **Books**: "C# in Depth" by Jon Skeet

### .NET Development
- **Official Documentation**: [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- **Community**: [Stack Overflow C# Tag](https://stackoverflow.com/questions/tagged/c%23)

---

## 🎯 Academic Success Tips

### For Students
1. **Understand the Requirements**: Read each project specification carefully
2. **Test with Sample Data**: Use the provided examples to verify your understanding
3. **Document Your Learning**: Take notes on mathematical concepts and C# features
4. **Practice Modifications**: Try changing parameters and observe results
5. **Seek Help Early**: Don't wait until the deadline to ask questions

### For Educators
1. **Use as Teaching Tools**: These projects demonstrate real-world applications
2. **Assign Modifications**: Ask students to extend functionality
3. **Group Projects**: Combine multiple projects for comprehensive assignments
4. **Assessment**: Use the built-in validation and error handling for grading

---

## 🌟 Support and Community

### Getting Help
- 📖 **Documentation**: Check individual project README files
- 🐛 **Issues**: Report bugs on GitHub
- 💡 **Discussions**: Start conversations about improvements
- 📧 **Contact**: Reach out to the author

### Contributing
We welcome contributions! Here's how:
1. **Fork** the repository
2. **Create** a feature branch
3. **Make** your changes
4. **Test** thoroughly
5. **Submit** a pull request

### Staying Updated
- ⭐ **Star** the repository for updates
- 🔔 **Watch** for notifications
- 📢 **Share** with fellow students and developers

---

## 📞 Quick Reference

### Command Summary
```bash
# Build all projects
dotnet build

# Run Set Operations System
cd SetOperationsSystem && dotnet run

# Run Rocket Velocity Calculator  
cd RocketVelocityCalculator && dotnet run

# Run Investment Growth Calculator
cd InvestmentGrowthCalculator && dotnet run
```

### Sample Inputs
- **Set Operations**: `1001 1002 1003 1004 1005 1006 1007 1008`
- **Investment Calculator**: `1000` → `0.05` → `0` → `5` → `1`

### Expected Outputs
- **Set Operations**: Union, Intersection, Complements
- **Rocket Calculator**: v=12 m/s, s=8 meters
- **Investment Calculator**: Growth table and analysis

---

**Happy Learning and Coding! 🚀📚💻**

*This guide covers all three C# Mathematical Applications projects. Each project is designed to be educational, practical, and ready for academic use.* 