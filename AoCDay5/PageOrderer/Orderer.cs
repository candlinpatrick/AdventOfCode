﻿namespace PageOrderer;

public static class Orderer
{
    public static int GetSumOfMidpoints(string input)
    {
        var sum = 0;

        var orderRules = GetOrderingRules(input);
        var orderedPages = new List<string>();
        var numbersLists = GetnumberList(input);

        for (int i = 0; i < numbersLists.Count; i++)
        {
            List<string>? nums = numbersLists[i];

            var correctOrder = true;

            for (int j = 0; j < nums.Count - 1; j++)
            {
                var num1 = nums[i];
                var num2 = nums[i + 1];

                var luckyShot = orderRules
                    .Where(x => x.Contains(num1) && x.Contains(num2))
                    .ToArray();

                if (luckyShot.Any())
                {
                    if (luckyShot[0] == num1 && luckyShot[1] == num2)
                    {
                        continue;
                    }
                }

                correctOrder = false;
                break;
            }

            if (correctOrder)
            {
                int midIdex = nums.Count / 2;

                sum += int.Parse(nums[midIdex]);
            }
        }

        return sum;
    }

    private static List<List<string>> GetnumberList(string input)
    {
        var lines = input.Split('\n');

        var numbers = new List<List<string>>();

        foreach (var line in lines)
        {
            if (line.Contains(','))
            {
                numbers.Add(line.Split(',').ToList());
            }
        }

        return numbers;
    }

    private static List<string> GetOrderingRules(string input)
    {
        var lines = input.Split("\n");

        var rules = new List<string>();

        foreach (var line in lines)
        {
            if (line.Contains('|'))
            {
                rules.Add(line);
            }
        }

        return rules;
    }
}
