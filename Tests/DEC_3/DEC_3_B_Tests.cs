using FluentAssertions;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class DEC_3_B_Tests
{

    [Test]
    public void Star2()
    {
        var lines = File.ReadAllLines(@"C:\code\AdventofCode2022\AdventOfCode2022\Tests\DEC_3\input.txt");
        var sum = 0;

        var grouping = 0;
        for (int j = 0; j < 100; j++)
        {
            Console.WriteLine(grouping);
            sum += Sum(new List<string> { lines[grouping++], lines[grouping++], lines[grouping++] });
        }

        Console.WriteLine(sum);
    }

    private static int Sum(IList<string> x)
    {
        var comp1 = x[0].ToString();
        var comp2 = x[1].ToString();
        var comp3 = x[2].ToString();

     
        var duplicate = comp1.ToCharArray().Where(x => comp2.Contains(x) && comp3.Contains(x)).ToList();
        
        if (!duplicate.Any())
        {
            return 0;
        }

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