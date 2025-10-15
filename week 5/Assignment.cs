public class Assignment
{
    protected string _studentName;
    protected string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to get summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // We can provide access to protected members through methods if needed
    public string GetStudentName()
    {
        return _studentName;
    }
}