namespace Day14_ExtendedPolymerization
{
    public class PolymerNode
    {
        private static readonly Dictionary<PolymerNode, Dictionary<char, long>> shortcutDict = new Dictionary<PolymerNode, Dictionary<char, long>>();
        private readonly string polymerPart;
        private readonly char leftElement;
        private readonly char rightElement;
        private readonly int nodeLevel;

        public PolymerNode(char firstElement, char secondElement, int nodeLevel)
        {
            this.polymerPart = string.Concat(firstElement,secondElement);
            this.leftElement = firstElement;
            this.rightElement = secondElement;
            this.nodeLevel = nodeLevel;
        }

        public Dictionary<char, long> GetResultDictionary(Dictionary<string, char>  polymerizationRules)
        {
            if (shortcutDict.TryGetValue(this, out var result))
            {
                return result;
            }

            char middleElement = polymerizationRules[polymerPart];
            if (nodeLevel == 1)
            {
                return new Dictionary<char, long>()
                    .Increment(leftElement)
                    .Increment(middleElement)
                    .Increment(rightElement);
            }

            var leftChild = new PolymerNode(leftElement, middleElement, nodeLevel - 1);
            var rightChild = new PolymerNode(middleElement, rightElement, nodeLevel - 1);
            var leftNodeResult = leftChild.GetResultDictionary(polymerizationRules);
            var rightNodeResult = rightChild.GetResultDictionary(polymerizationRules);

            result = leftNodeResult.Add(rightNodeResult).Decrement(middleElement);
            shortcutDict.Add(this, result);

            return result;
        }

        public override int GetHashCode()
        {
            return polymerPart.GetHashCode() ^ nodeLevel;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (obj is not PolymerNode polymerNode)
                return false;

            return polymerNode.polymerPart == polymerPart && polymerNode.nodeLevel == nodeLevel;
        }
    }
}
