﻿using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests;

[TestFixture]
public class DEC_5_B_Tests
{

    [Test]
    public void Star2()
    {
        var lines = FileReader.ReadFile(@"DEC_5\input.txt");
        var sum = Sum(lines.ToArray());
        Console.WriteLine(sum);
    }
    
    [Test]
    public void Star2_Example()
    {
        var lines = FileReader.ReadFile(@"DEC_5\example.txt");
        var sum = Sum(lines.ToArray());
        Console.WriteLine(sum);
        //sum.Should().Be(4);
    }
    private static int Sum(string[] lines)
    {
        return 0;
    }

}