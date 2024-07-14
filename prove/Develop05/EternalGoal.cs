public class EternalGoal : Goal
{
    private int _completionCount;

    public EternalGoal(string name, int points) : base(name, points)
    {
        _completionCount = 0;
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        _completionCount++;
    }

    public override string GetDetailsString()
    {
        return $"Eternal Goal: {Name} - Completed {_completionCount} times";
    }
}
