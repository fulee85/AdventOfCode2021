namespace Day16PacketDecoder
{
    public class LiteralPacket : Packet
    {
        private string bits = "";
        public LiteralPacket(int version, int typeId) : base(version, typeId)
        {
        }

        public override int GetVersionNumberSum()
        {
            return version;
        }

        public void AddValueBits(string valueBits)
        {
            bits += valueBits[1..];
        }

        public override long GetValue()
        {
            return Convert.ToInt64(bits, 2);
        }
    }
}
