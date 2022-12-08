using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests;

[TestFixture]
public class DEC_9_B_Tests : BaseTest
{

    [Test]
    public void Star1()
    {
        //Arrange
        timer.StartTimer();
        var lines = FileReader.ReadFile(@"DEC_8\input.txt");
        
        //Act
        var sum = Sum(lines.ToArray());
        
        //Assert
        Console.WriteLine(sum);
        sum.Should().Be("");
        
        Console.WriteLine(timer.StopTimer());
    }
    
    [Test]
    public void Star1_Example()
    {
        //Arrange
        timer.StartTimer();
        var lines = FileReader.ReadFile(@"DEC_8\example.txt");
        
        //Act
        var sum = Sum(lines.ToArray());
        
        //Assert
        Console.WriteLine(sum);
        sum.Should().Be("");
        Console.WriteLine(timer.StopTimer());
    }
    private static string Sum(string[] lines)
    {
        return "";
    }

}
