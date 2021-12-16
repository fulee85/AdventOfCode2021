using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16PacketDecoder
{
    public class Transmission
    {
        private string inputBits = "";
        private int actualPosition = 0;

        public Transmission(string hexadecimalInput)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var ch in hexadecimalInput)
            {
                sb.Append(ch switch
                {
                    '0' => "0000",
                    '1' => "0001",
                    '2' => "0010",
                    '3' => "0011",
                    '4' => "0100",
                    '5' => "0101",
                    '6' => "0110",
                    '7' => "0111",
                    '8' => "1000",
                    '9' => "1001",
                    'A' => "1010",
                    'B' => "1011",
                    'C' => "1100",
                    'D' => "1101",
                    'E' => "1110",
                    'F' => "1111",
                    _ => string.Empty,
                });
            }

            inputBits = sb.ToString();
        }

        private Transmission()
        {
        }

        public static Transmission CreateFromBits(string bits)
        {
            var transmission = new Transmission
            {
                inputBits = bits
            };

            return transmission;
        }


        public int GetNextBitsAsInt(int count)
        {
            return Convert.ToInt32(GetNextBits(count), 2);
        }

        public string GetNextBits(int count)
        {
            var bits = inputBits.Substring(actualPosition, count);
            actualPosition += count;

            return bits;
        }

        public bool HasNextBits()
        {
            if (actualPosition > inputBits.Length)
            {
                return false;
            }
            return inputBits.Substring(actualPosition).Any(c => c == '1');
        }

        public void SkipZeros()
        {

        }
    }
}
