using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08_SevenSegmentSearch
{
    public class Digit
    {
        private readonly string digitString;

        public Digit(string digitString)
        {
            this.digitString = digitString;
        }

        /// <summary>
        /// Because the digits 1, 4, 7, and 8 each use a unique number of segments, you should be able to tell
        /// which combinations of signals correspond to those digits.
        /// 1 -> 2 segments
        /// 4 -> 4 segments
        /// 7 -> 3 segments
        /// 8 -> 7 segments
        /// </summary>
        /// <returns></returns>
        public bool IsEasyDigit() => digitString.Length switch
        {
            2 => true,
            4 => true,
            3 => true,
            7 => true,
            _ => false
        };

        public int CalculateDigitValue(Dictionary<char,char> segmentMapping)
        {
            var decodedSegmentsArray = digitString.Select(c => segmentMapping[c]).ToArray();
            Array.Sort(decodedSegmentsArray);
            var decodedSegmentsString = new string(decodedSegmentsArray);
            return GetDigitValue(decodedSegmentsString);
        }

        private int GetDigitValue(string segments) => segments switch
        {
            "abcefg" => 0,
            "cf" => 1,
            "acdeg" => 2,
            "acdfg" => 3,
            "bcdf" => 4,
            "abdfg" => 5,
            "abdefg" => 6,
            "acf" => 7,
            "abcdefg" => 8,
            "abcdfg" => 9
        };
    }
}
