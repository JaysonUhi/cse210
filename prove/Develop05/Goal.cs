public abstract class Goal
{
    public string Name { get; }
    public int Points { get; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public virtual void RecordEvent()
    {
        IsCompleted = true;
    }

    public virtual string GetCompletionStatus()
    {
        return IsCompleted ? "[X] Completed" : "[ ] Not Completed";
    }

    public abstract string GetDetailsString();
}
