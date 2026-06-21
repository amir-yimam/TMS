// ============================================
// MODULE 1 - SESSION 1: THE DATA MODEL
// TMS Core - Program.cs
// ============================================

// ============================================
// EXERCISE 1: THE FIRST SAFETY NET
// ============================================

Console.WriteLine("=== EXERCISE 1: THE FIRST SAFETY NET ===\n");

// Pattern 1: Nullable type
string? region = null;

// Pattern 2: Null-conditional operator
string? upperRegion = region?.ToUpper();
Console.WriteLine($"Region (conditional): {upperRegion}");

// Pattern 3: Null-coalescing operator
string displayRegion = region ?? "Unassigned";
Console.WriteLine($"Region (coalesced): {displayRegion}");

// Pattern 4: Null-coalescing assignment
region ??= "Addis Ababa";
Console.WriteLine($"Region (assigned): {region}");

// TMS Variables
Console.WriteLine("\n=== TMS STUDENT DATA ===\n");

string studentName = "Abeba";
string studentId = "STU-001";
int enrollmentCount = 3;
decimal grantAmount = 1999.99m;
DateTime enrolledAt = DateTime.UtcNow;
string? campusRegion = null;

Console.WriteLine($"Student: {studentName} ({studentId})");
Console.WriteLine($"Courses: {enrollmentCount}");
Console.WriteLine($"Grant: {grantAmount:F2}");
Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
Console.WriteLine($"Campus: {campusRegion ?? "Not assigned"}");

// ============================================
// EXERCISE 2: THE MINISTRY AUDIT FAILURE
// ============================================

Console.WriteLine("\n=== EXERCISE 2: MINISTRY AUDIT ===\n");

// STEP 1: See the Bug
Console.WriteLine("--- Legacy Code (DOUBLE - BUGGY) ---");

double grantPerStudent = 1999.99;
double totalAllocation = grantPerStudent * 100_000;

Console.WriteLine($"Total allocated (double): {totalAllocation}");
Console.WriteLine($"Total allocated with full precision: {totalAllocation:R}");

// STEP 2: Fix It
Console.WriteLine("\n--- Fixed Code (DECIMAL - CORRECT) ---");

decimal grantPerStudentDecimal = 1999.99m;
decimal totalAllocationDecimal = grantPerStudentDecimal * 100_000m;

Console.WriteLine($"Total allocated (decimal): {totalAllocationDecimal}");
Console.WriteLine($"Total allocated (formatted): {totalAllocationDecimal:F2}");

// ============================================
// EXERCISE 3A: PIPELINE DATA CORRUPTION
// ============================================

Console.WriteLine("\n=== EXERCISE 3A: DATA CORRUPTION FIX ===\n");

// ---------- TEST 1: EnrollmentRecord (Immutable) ----------
Console.WriteLine("--- EnrollmentRecord (Immutable) ---");

var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
Console.WriteLine($"Original: {enrollment}");

// Non-destructive copy - creates a NEW record with one field changed
var corrected = enrollment with { CourseCode = "CS-402" };
Console.WriteLine($"Corrected: {corrected}");

// Value equality - two records with the same data are equal
var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
Console.WriteLine($"Same data? {enrollment == duplicate}"); // True

// ---------- TEST 2: Course (Mutable with Validation) ----------
Console.WriteLine("\n--- Course (Mutable with Validation) ---");

var course = new Course
{
    Code = "CS-401",
    Title = "Advanced C#",
    Capacity = 30
};
Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");

// Test invalid capacity - should throw exception
try
{
    Console.WriteLine("Trying to set capacity to -5...");
    course.Capacity = -5;
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"✅ Caught: {ex.Message}");
}

// Test invalid title - should throw exception
try
{
    Console.WriteLine("\nTrying to set title to empty...");
    course.Title = "";
}
catch (ArgumentException ex)
{
    Console.WriteLine($"✅ Caught: {ex.Message}");
}

// ---------- TEST 3: Student (Validated Properties) ----------
Console.WriteLine("\n--- Student (Validated Properties) ---");

var student = new Student
{
    Id = "S1",
    Name = "Abeba",
    Age = 20,
    GPA = 3.8m
};
Console.WriteLine($"Student: {student.Name}, GPA: {student.GPA}");

// Test invalid age - should throw exception
try
{
    Console.WriteLine("\nTrying to set age to 12...");
    var invalidStudent = new Student
    {
        Id = "S2",
        Name = "Test",
        Age = 12,
        GPA = 3.0m
    };
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"✅ Caught: {ex.Message}");
}

// Test invalid GPA - should throw exception
try
{
    Console.WriteLine("\nTrying to set GPA to 5.0...");
    var invalidStudent = new Student
    {
        Id = "S3",
        Name = "Test",
        Age = 20,
        GPA = 5.0m
    };
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"✅ Caught: {ex.Message}");
}

// Test invalid name - should throw exception
try
{
    Console.WriteLine("\nTrying to set name to empty...");
    var invalidStudent = new Student
    {
        Id = "S4",
        Name = "",
        Age = 20,
        GPA = 3.0m
    };
}
catch (ArgumentException ex)
{
    Console.WriteLine($"✅ Caught: {ex.Message}");
}

Console.WriteLine("\n=== END OF PROGRAM ===");
