// ============================================
// MODULE 1 - SESSION 1: THE DATA MODEL
// TMS Core - Models.cs
// ============================================

// ============================================
// EXERCISE 3A - PART 1: EnrollmentRecord
// ============================================

/// <summary>
/// Immutable by design - the logging pipeline cannot corrupt this
/// </summary>
public record EnrollmentRecord(string StudentId, string CourseCode, DateTime EnrolledAt);

// ============================================
// EXERCISE 3A - PART 2: Course Class
// ============================================

/// <summary>
/// Course entity with validation using C# 14 field keyword
/// </summary>
public class Course
{
    // Required, cannot be changed after creation
    public required string Code { get; init; }

    // Required, cannot be empty or whitespace
    public required string Title
    {
        get => field;
        set => field = !string.IsNullOrWhiteSpace(value)
            ? value
            : throw new ArgumentException("Title cannot be empty or whitespace.", nameof(value));
    }

    // C# 14 Auto-property validation using 'field'
    public int Capacity
    {
        get => field;
        set => field = value > 0
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value), 
                "System constraint: Capacity must be greater than zero.");
    }

    // Can change, no validation needed
    public int EnrolledCount { get; set; }
}

// ============================================
// EXERCISE 3A - PART 3: Student Class
// ============================================

/// <summary>
/// Student entity with validation using C# 14 field keyword
/// </summary>
public class Student
{
    // Required, cannot be changed after creation
    public required string Id { get; init; }

    // Required, cannot be empty or whitespace
    public required string Name
    {
        get => field;
        set => field = !string.IsNullOrWhiteSpace(value)
            ? value
            : throw new ArgumentException("Name cannot be empty or whitespace.", nameof(value));
    }

    // Age must be between 16 and 100
    public int Age
    {
        get => field;
        set => field = value is >= 16 and <= 100
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value), 
                "Age must be between 16 and 100.");
    }

    // GPA must be between 0.0 and 4.0
    public decimal GPA
    {
        get => field;
        set => field = value is >= 0.0m and <= 4.0m
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value), 
                "GPA must be between 0.0 and 4.0.");
    }
}
