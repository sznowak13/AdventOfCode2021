class AdventOfCode
{
    public static void Main()
    {
        //Console.WriteLine(dayOne1());
        //Console.WriteLine(dayOne2());
        //Console.WriteLine(dayTwo1());
        //Console.WriteLine(dayTwo2());
        //Console.WriteLine(dayThree1());
        Console.WriteLine(dayThree2());
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

    static int dayThree1()
    {

        char[][] report = Array.ConvertAll(
            File.ReadAllLines(@"C:\Users\ShaiiboN\source\repos\AdventOfCode2021\AdventOfCode2021\inputs\DayThree.txt"),
            s => s.ToCharArray()
            );
        int lnLength = report[0].Length;
        int commonnessPoint = report.Length / 2;
        int[] btSum = new int[lnLength];
        foreach (char[] btArray in report)
        {
            for (int i = 0; i < lnLength; i++)
            {
                btSum[i] += (int) char.GetNumericValue(btArray[i]);
            }
        }
        char[] gammaChars = new char[lnLength];

        for (int i = 0; i < lnLength; i++)
        {
            gammaChars[i] = btSum[i] > commonnessPoint ? '1' : '0';
        }
        int gammaRate = Convert.ToInt32(string.Join("", gammaChars), 2);
        int xorComponent = (int) Math.Pow(2, lnLength) - 1;
        int epsilonRate = gammaRate ^ xorComponent;

        return gammaRate * epsilonRate;

    }

    static int dayThree2()
    {

        char[][] report = Array.ConvertAll(
            File.ReadAllLines(@"C:\Users\ShaiiboN\source\repos\AdventOfCode2021\AdventOfCode2021\inputs\DayThree.txt"),
            s => s.ToCharArray()
            );

        string oxRating = getRating(report, '1', '0');
        string CO2Rating = getRating(report, '0', '1');
        int ox = Convert.ToInt32(oxRating, 2);
        int co = Convert.ToInt32(CO2Rating, 2);

        return ox * co;

    }

    static string getRating(char[][] report, char winningBit, char losingBit)
    {
        List<char[]> bytePool = report.ToList();
        int pos = 0;
        while (bytePool.Count > 1)
        {
            int commonnessPoint = (bytePool.Count / 2) + (bytePool.Count % 2);
            int counter = 0;
            foreach (char[] bt in bytePool)
            {
                counter += (int)char.GetNumericValue(bt[pos]);
            }

            bytePool = bytePool.Where(bt => {
                if (counter >= commonnessPoint)
                {
                    return bt[pos] == winningBit;
                }
                else
                {
                    return bt[pos] == losingBit;
                }
            }).ToList();
            pos++;
        }
        return string.Join("", bytePool[0]);
    }
}
