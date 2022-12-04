using FluentAssertions;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class DEC_3_A_Tests
{

    [Test]
    public void Star1()
    {
        var lines = File.ReadAllLines(@"C:\code\AdventofCode2022\AdventOfCode2022\Tests\DEC_3\input.txt");
        var sum = 0;
        foreach (var input in lines)
        {
            sum += Sum(input);
        }
        Console.WriteLine(sum);
    }

    [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", 16)]
    [TestCase("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38)]
    [TestCase("PmmdzqPrVvPwwTWBwg", 42)]
    [TestCase("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22)]
    [TestCase("ttgJtRGJQctTZtZT", 20)]
    [TestCase("CrZsJsPPZsGzwwsLwLmpwMDw", 19)]
    public void Example(string input, int sum)
    {
        var result = Sum(input);
        result.Should().Be(sum);
    }

    private static int Sum(string input)
    {
        var length = input.Length;

        var comp1 = input.Substring(0, length / 2);
        var comp2 = input.Substring((length / 2));

        var duplicate = comp1.ToCharArray().Where(x => comp2.Contains(x)).ToList();

        var singleDup = duplicate[0];
        var alphabet = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        var isLower = Char.IsLower(singleDup);
        var prio = alphabet.IndexOf(singleDup.ToString().ToUpper()) + 1;

        if (!isLower)
        {
            prio = prio + 26;
        }

        return prio;
    }
}
