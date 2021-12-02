namespace Day02_Dive;

public abstract class Submarine
{
    protected long horisontalPosition = 0;
    protected long depthPosition = 0;

    public void Run(IEnumerable<string> instructions)
    {
        foreach (var instruction in instructions)
        {
            var instructionParts = instruction.Split();
            var command = instructionParts[0];
            var value = int.Parse(instructionParts[1]);

            switch (command)
            {
                case "forward": 
                    Forward(value); 
                    break;
                case "down": 
                    Down(value); 
                    break;
                case "up":
                    Up(value);
                    break;
                default:
                    throw new Exception("Unknown command");
            }

            if (depthPosition < 0)
            {
                throw new Exception();
            }
        }
    }

    protected abstract void Forward(int value);
    protected abstract void Down(int value);
    protected abstract void Up(int value);

    public long Position => horisontalPosition * depthPosition;
}