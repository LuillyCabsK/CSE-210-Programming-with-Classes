public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title) 
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to get writing information
    public string GetWritingInformation()
    {
        // Using the protected member directly
        return $"{_title} by {_studentName}";
        
        // Alternative: Using the public getter method
        // return $"{_title} by {GetStudentName()}";
    }
}