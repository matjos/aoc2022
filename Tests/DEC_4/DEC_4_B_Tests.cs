using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests;

[TestFixture]
public class DEC_4_B_Tests
{

    [Test]
    public void Star2()
    {
        var lines = FileReader.ReadFile(@"DEC_4\input.txt");
        var sum = Sum(lines.ToArray());
        Console.WriteLine(sum);
    }
    
    [Test]
    public void Star2_Example()
    {
        var lines = FileReader.ReadFile(@"DEC_4\example.txt");
        var sum = Sum(lines.ToArray());
        Console.WriteLine(sum);
        sum.Should().Be(4);
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

            var arr1 = Enumerable.Range(elf1_Start, elf1_End - elf1_Start+1);

            var elf2_Start = Int32.Parse(elfNumber2[0]);
            var elf2_End = Int32.Parse(elfNumber2[1]);
            
            var arr2 = Enumerable.Range(elf2_Start, elf2_End - elf2_Start+1);

            var togheter = arr1.Concat(arr2);

            var duplicates = togheter.Distinct().Count();
            
            if (togheter.Count() > togheter.Distinct().Count())
            {
                sum += 1;
            }
           
        }
        return sum;
    }

}
