class MathAssignment : Assignment
{
    private int _chapterNumber;
    private string _section;

    public MathAssignment(string studentName, string topic, int chapterNumber, string section)
        : base(studentName, topic)
    {
        _chapterNumber = chapterNumber;
        _section = section;
    }

    public string GetHomeworkList()
    {
        return $"Chapter {_chapterNumber} Section {_section} Problems 1-20";
    }
}