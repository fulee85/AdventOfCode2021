namespace Day16PacketDecoder
{
    public abstract class Packet
    {
        protected readonly int version;
        protected readonly int typeId;

        public Packet(int version, int typeId)
        {
            this.version = version;
            this.typeId = typeId;
        }

        public abstract int GetVersionNumberSum();

        public abstract long GetValue();
    }
}
