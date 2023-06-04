class WritingAssignment : Assignment
{
    private string _assignmentName;

    public WritingAssignment(string studentName, string topic, string assignmentName)
        : base(studentName, topic)
    {
        _assignmentName = assignmentName;
    }

    public string GetWritingInformation()
    {
        return $"{_assignmentName} by {_studentName}";
    }
}
