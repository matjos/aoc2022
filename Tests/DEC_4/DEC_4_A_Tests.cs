using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests;

[TestFixture]
public class DEC_4_A_Tests
{

    [Test]
    public void Star1()
    {
        var lines = FileReader.ReadFile(@"DEC_4\input.txt");
        var sum = Sum(lines.ToArray());
        Console.WriteLine(sum);
    }
    
    [Test]
    public void Star1_Example()
    {
        var lines = FileReader.ReadFile(@"DEC_4\example.txt");
        var sum = Sum(lines.ToArray());
        Console.WriteLine(sum);
        sum.Should().Be(2);
    }
    private static int Sum(string[] lines)
    {
        var sum = 0;
        foreach (var input in lines)
        {
            var elfs = input.Split(",").ToList();

            var elfNumber = elfs[0].Split("-");
            var elfNumber2 = elfs[1].Split("-");

            var elf1_Start = Int32.Parse(elfNumber[0]);
            var elf1_End = Int32.Parse(elfNumber[1]);

            var elf2_Start = Int32.Parse(elfNumber2[0]);
            var elf2_End = Int32.Parse(elfNumber2[1]);

            if (elf1_End-elf1_Start > elf2_End-elf2_Start)
            {
                if (elf1_Start <= elf2_Start && elf1_End >= elf2_End)
                {
                    sum += 1;
                }
            }
            else
            {
                if (elf2_Start <= elf1_Start && elf2_End >= elf1_End)
                {
                    sum += 1;
                }
            }
        }
        return sum;
    }
}
