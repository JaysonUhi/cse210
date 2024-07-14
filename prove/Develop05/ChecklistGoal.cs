public class ChecklistGoal : Goal
{
    private int _targetTimes;
    private int _completedTimes;
    public int BonusPoints { get; }

    public ChecklistGoal(string name, int points, int targetTimes, int bonusPoints) : base(name, points)
    {
        _targetTimes = targetTimes;
        _completedTimes = 0;
        BonusPoints = bonusPoints; // Initialize the bonus points
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        _completedTimes++;
    }

    public override string GetDetailsString()
    {
        return $"Checklist Goal: {Name} - Completed {_completedTimes}/{_targetTimes} times - {GetCompletionStatus()}";
    }

    public override string GetCompletionStatus()
    {
        if (_completedTimes >= _targetTimes)
        {
            return $"Completed {_completedTimes}/{_targetTimes} times - [X] Completed";
        }
        else
        {
            return $"Completed {_completedTimes}/{_targetTimes} times - [ ] Not Completed";
        }
    }
}
