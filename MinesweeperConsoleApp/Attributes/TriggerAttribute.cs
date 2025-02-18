namespace MinesweeperConsoleApp.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class TriggerAttribute : Attribute
{
    public string Trigger { get; }

    public TriggerAttribute(string trigger)
    {
        Trigger = trigger;
    }
}