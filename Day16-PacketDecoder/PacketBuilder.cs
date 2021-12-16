namespace Day16PacketDecoder
{
    public class PacketBuilder
    {
        private readonly Transmission transmission;

        public PacketBuilder(Transmission transmission)
        {
            this.transmission = transmission;
        }

        public Packet Build()
        {
            var version = transmission.GetNextBitsAsInt(3);
            var typeId = transmission.GetNextBitsAsInt(3);

            if (typeId == 4)
            {
                var literalPacket = new LiteralPacket(version, typeId);
                var valueBits = transmission.GetNextBits(5);
                while (valueBits.StartsWith('1'))
                {
                    literalPacket.AddValueBits(valueBits);
                    valueBits = transmission.GetNextBits(5);
                }
                literalPacket.AddValueBits(valueBits);

                return literalPacket;
            }
            else
            {
                var operatorPacket = new OperatorPacket(version, typeId);
                var lengthTypeId = transmission.GetNextBits(1);
                if (lengthTypeId == "0")
                {
                    var subpacketLength = transmission.GetNextBitsAsInt(15);
                    var subTransmission = Transmission.CreateFromBits(transmission.GetNextBits(subpacketLength));
                    while (subTransmission.HasNextBits())
                    {
                        var subpacket = new PacketBuilder(subTransmission).Build();
                        operatorPacket.AddSubpacket(subpacket);
                    }
                }
                else
                {
                    var subpacketCount = transmission.GetNextBitsAsInt(11);
                    for (int i = 0; i < subpacketCount; i++)
                    {
                        var subpacket = new PacketBuilder(transmission).Build();
                        operatorPacket.AddSubpacket(subpacket);
                    }
                }

                return operatorPacket;
            }
        }
    }
}
