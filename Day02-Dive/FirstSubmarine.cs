namespace Day02_Dive;

public class FirstSubmarine : Submarine
{
    protected override void Down(int value)
    {
        depthPosition += value;
    }

    protected override void Forward(int value)
    {
        horisontalPosition += value;
    }

    protected override void Up(int value)
    {
        depthPosition -= value;
    }
}

