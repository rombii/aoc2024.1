using var inputReader = new StreamReader(Path.Join(Directory.GetCurrentDirectory(), "input.txt"));
long ansPart1 = 0, ansPart2 = 0;
PriorityQueue<int, int> queue1 = new(), queue2 = new();
var part2Dict = new Dictionary<int, int>();
while (!inputReader.EndOfStream)
{
    var line = await inputReader.ReadLineAsync();
    var splitLine = line!.Split("   ");
    if (int.TryParse(splitLine[0], out var item1) && int.TryParse(splitLine[1], out var item2))
    {
        queue1.Enqueue(item1, item1);
        queue2.Enqueue(item2, item2);
        if (part2Dict.TryGetValue(item2, out var value))
        {
            part2Dict[item2] = ++value;
        }
        else
        {
            part2Dict[item2] = 1;
        }
    }
}

while (queue1.Count > 0 && queue2.Count > 0)
{
    int item1 = queue1.Dequeue(), item2 = queue2.Dequeue();
    ansPart1 += Math.Abs(item1 - item2);
    if (!part2Dict.TryGetValue(item1, out var value))
    {
        continue;
    }
    ansPart2 += item1 * value;
}

Console.WriteLine($"First part: {ansPart1}");
Console.WriteLine($"Second part: {ansPart2}");