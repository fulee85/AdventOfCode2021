namespace Day24ArithmeticLogicUnit
{
    public class Input
    {
        private int[] input;

        public Input()
        {
            input = new int[14];
        }

        public int this[int index]
        {
            get { return input[index]; }
            set { input[index] = value; }
        }
    }
}
