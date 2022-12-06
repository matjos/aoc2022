using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests;

[TestFixture]
public class DEC_6_B_Tests
{

    [Test]
    public void Star1()
    {
        var lines = FileReader.ReadFile(@"DEC_6\input.txt");
        var sum = Sum(lines.First());
        Console.WriteLine(sum);
        //sum.Should().Be("");
    }

    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Star1_Example(string input, int result)
    {
        var sum = Sum(input);
        Console.WriteLine(sum);
        sum.Should().Be(result);
    }
    
    private static int Sum(string input)
    {
        var chars = input.ToCharArray().ToList();

        var subTotal = 0;
        var uniqeLength = 14;

        for (int i = 0; i < chars.Count(); i++)
        {
            if (chars.GetRange(i,uniqeLength).Distinct().Count() == uniqeLength)
            {
                subTotal += i+uniqeLength;
                break;
            }
        }
        return subTotal;
    }
}
