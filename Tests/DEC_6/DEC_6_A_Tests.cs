using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests;

[TestFixture]
public class DEC_6_A_Tests : BaseTest
{

    [Test]
    public void Star1()
    {
        //Arrange
        timer.StartTimer();
        var lines = FileReader.ReadFile(@"DEC_6\input.txt");
        
        //Act
        var sum = Sum(lines.First());
        
        //Assert
        Console.WriteLine(sum);
        Console.WriteLine(timer.StopTimer());
        
        //sum.Should().Be("");
    }

    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
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
        var uniqeLength = 4;

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