namespace Day16PacketDecoder
{
    public class OperatorPacket : Packet
    {
        private readonly List<Packet> subPackets = new List<Packet>();

        public OperatorPacket(int version, int typeId) : base(version, typeId)
        {
        }

        public void AddSubpacket(Packet subPacket)
        {
            subPackets.Add(subPacket);
        }

        public override long GetValue() => typeId switch
        {
            0 => subPackets.Sum(p => p.GetValue()),
            1 => subPackets.Product(p => p.GetValue()),
            2 => subPackets.Min(p => p.GetValue()),
            3 => subPackets.Max(p => p.GetValue()),
            5 => subPackets[0].GetValue() > subPackets[1].GetValue() ? 1 : 0,
            6 => subPackets[0].GetValue() < subPackets[1].GetValue() ? 1 : 0,
            7 => subPackets[0].GetValue() == subPackets[1].GetValue() ? 1 : 0,
            _ => throw new Exception(),
        };

        public override int GetVersionNumberSum()
        {
            return version + subPackets.Sum(sp => sp.GetVersionNumberSum());
        }
    }
}
