using Day08_SevenSegmentSearch;

var input = File.ReadLines("input.txt");
var entries = input.Select(il => new Entry(il));

Console.WriteLine($"{entries.Sum(e => e.GetEasyDigitsAppearCount())} times do digits 1, 4, 7, or 8 appear in the output values.");
Console.WriteLine($"If you add up all of the output values you get {entries.Sum(e => e.GetOutputValue())}.");