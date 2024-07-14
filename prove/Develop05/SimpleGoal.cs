public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points)
    {
    }

    public override string GetDetailsString()
    {
        return $"Simple Goal: {Name} - {GetCompletionStatus()}";
    }
}
