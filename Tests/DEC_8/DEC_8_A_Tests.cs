using System.Reflection;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests;

[TestFixture]
public class DEC_8_A_Tests
{

    [Test]
    public void Star1()
    {
        var lines = FileReader.ReadFile(@"DEC_8\input.txt");
        var sum = Sum(lines.ToArray());
        Console.WriteLine(sum);
        sum.Should().Be("");
    }
    
    [Test]
    public void Star1_Example()
    {
        var lines = FileReader.ReadFile(@"DEC_8\example.txt");
        var sum = Sum(lines.ToArray());
        Console.WriteLine(sum);
        sum.Should().Be("");
    }
    private static string Sum(string[] lines)
    {
        return "";
    }
}
