class AdventOfCode
{
    public static void Main()
    {
        Console.WriteLine(dayOne1());
        Console.WriteLine(dayOne2());
        Console.WriteLine(dayTwo1());
        Console.WriteLine(dayTwo2());
    }

    static int dayOne1()
    {
        string[] measurementsRaw = File.ReadAllLines(@"C:\Users\ShaiiboN\source\repos\AdventOfCode2021\AdventOfCode2021\inputs\DayOne.txt");
        int[] measurements = Array.ConvertAll(measurementsRaw, s => int.Parse(s));
        int increased = 0;
        int prevMeasurement = 0;
        foreach (int measurement in measurements)
        {
            int diff = measurement - prevMeasurement;
            increased += diff > 0 ? 1 : 0;
            prevMeasurement = measurement;
        }
        return increased - 1;  // It's easier to compensate first check with no previous measurement then to do an if statement in loop.
    }

    static int dayOne2()
    {
        string[] measurementsRaw = File.ReadAllLines(@"C:\Users\ShaiiboN\source\repos\AdventOfCode2021\AdventOfCode2021\inputs\DayOne.txt");
        int[] measurements = Array.ConvertAll(measurementsRaw, s => int.Parse(s));
        int increased = 0;
        int prevMeasurement = 0;
        for (int i =0; i < measurements.Length - 2; i++)
        {
            int sum = measurements[i] + measurements[i + 1] + measurements[i + 2];
            int diff = sum - prevMeasurement;
            increased += diff > 0 ? 1 : 0;
            prevMeasurement = sum;
        }
        return increased - 1;  // It's easier to compensate first check with no previous measurement then to do an if statement in loop.
    }

    static int dayTwo1()
    {
        string[] commands = File.ReadAllLines(@"C:\Users\ShaiiboN\source\repos\AdventOfCode2021\AdventOfCode2021\inputs\DayTwo.txt");
        int position = 0;
        int depth = 0;
        foreach (string command in commands)
        {
            string[] parsed = command.Split(' ');
            string cmd = parsed[0];
            int amount = int.Parse(parsed[1]);
            switch (cmd)
            {
                case "forward":
                    position += amount;
                    break;
                case "up":
                    depth -= amount;
                    break;
                case "down":
                    depth += amount;
                    break;
            }
        }
        return position * depth;
    }

    static int dayTwo2()
    {
        string[] commands = File.ReadAllLines(@"C:\Users\ShaiiboN\source\repos\AdventOfCode2021\AdventOfCode2021\inputs\DayTwo.txt");
        int position = 0;
        int depth = 0;
        int aim = 0;
        foreach (string command in commands)
        {
            string[] parsed = command.Split(' ');
            string cmd = parsed[0];
            int amount = int.Parse(parsed[1]);
            switch (cmd)
            {
                case "forward":
                    position += amount;
                    depth += aim * amount;
                    break;
                case "up":
                    aim -= amount;
                    break;
                case "down":
                    aim += amount;
                    break;
            }
        }
        return position * depth;
    }
}
