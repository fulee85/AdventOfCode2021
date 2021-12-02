namespace Day02_Dive;

public class SecondSubmarine : Submarine
{
    private int aim = 0;

    protected override void Down(int value)
    {
        aim += value;
    }

    protected override void Forward(int value)
    {
        horisontalPosition += value;
        depthPosition += aim * value;
    }

    protected override void Up(int value)
    {
        aim -= value;
    }
}
