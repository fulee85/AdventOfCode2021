using Day16PacketDecoder;

namespace Day16_PacketDecoder
{
    public class Solver
    {
        private readonly string hexadecimalTransmission;

        public Solver(IEnumerable<string> input)
        {
            hexadecimalTransmission = input.First();
        }

        public Solver(string input)
        {
            hexadecimalTransmission = input;
        }

        public string SolvePartOne()
        {
            var transmission = new Transmission(hexadecimalTransmission);

            var packetBuilder = new PacketBuilder(transmission);

            var packet = packetBuilder.Build();

            return packet.GetVersionNumberSum().ToString();
        }

        public string SolvePartTwo()
        {
            var transmission = new Transmission(hexadecimalTransmission);

            var packetBuilder = new PacketBuilder(transmission);

            var packet = packetBuilder.Build();

            return packet.GetValue().ToString();
        }
    }
}
