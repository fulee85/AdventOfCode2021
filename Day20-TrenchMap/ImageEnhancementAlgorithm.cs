namespace Day20TrenchMap
{
    public class ImageEnhancementAlgorithm
    {
        private readonly string algorithmString;

        public ImageEnhancementAlgorithm(string algorithmString)
        {
            if (algorithmString.Length != 512)
            {
                throw new ArgumentException("Algorithm string lengt should be 512 long");
            }
            this.algorithmString = algorithmString;
        }

        public Image EnhanceImage(Image image)
        {
            var imageMatrix = new List<List<char>>();

            for (int row = 0; row < image.RowCount; row++)
            {
                imageMatrix.Add(new List<char>());
                for (int col = 0; col < image.ColumnCount; col++)
                {
                    var index = GetPixels(image, row, col)
                        .Select(ch => ch switch { '.' => 0, '#' => 1, _ => throw new NotImplementedException() })
                        .Aggregate(0, (a, b) => a * 2 + b);

                    imageMatrix[row].Add(algorithmString[index]);
                }
            }

            char newFrameChar = image.FrameChar == '.' ? newFrameChar = algorithmString[0] : algorithmString[^1];

            return new Image(imageMatrix, newFrameChar);
        }

        private IEnumerable<char> GetPixels(Image image, int row, int col)
        {
            yield return image.GetChar(row - 1, col - 1);
            yield return image.GetChar(row - 1, col);
            yield return image.GetChar(row - 1, col + 1);
            yield return image.GetChar(row, col - 1);
            yield return image.GetChar(row, col);
            yield return image.GetChar(row, col + 1);
            yield return image.GetChar(row + 1, col - 1);
            yield return image.GetChar(row + 1, col);
            yield return image.GetChar(row + 1, col + 1);
        }
    }
}
