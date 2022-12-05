using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests;

[TestFixture]
public class DEC_5_B_Tests
{

    [Test]
    public void Star1()
    {
        var lines = FileReader.ReadFile(@"DEC_5\input.txt");
        var sum = Sum(lines.ToArray());
        Console.WriteLine(sum);
        sum.Should().Be("RWLWGJGFD");
    }
    
    [Test]
    public void Star1_Example()
    {
        var lines = FileReader.ReadFile(@"DEC_5\example.txt");
        var sum = Sum(lines.ToArray());
        Console.WriteLine(sum);
        sum.Should().Be("MCD");
    }
    private static string Sum(string[] lines)
    {
        var result = "";
        var allStacks = new Dictionary<string, char[]>(); 
        var isMoving = false;
        
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                isMoving = true;
            }
            else if (isMoving)
            {
                var line2 = line.Replace(" ", "-");
                //var numberOnly = Regex.Replace(line2, "[^0-9.]", "");
                
                var numbarray = line2.Split("-");

                //numbarray = numbarray.Where(x => int.TryParse(x) !string.IsNullOrWhiteSpace(x)).ToArray();

                var move = int.Parse(numbarray[1].ToString());
                var from = numbarray[3].ToString();
                var to = numbarray[5].ToString();

                var toMove = allStacks[from].Take(move);

                allStacks[to] = toMove.Concat(allStacks[to]).ToArray();

                var temp = allStacks[from].ToList(); 
                temp.RemoveRange(0, move);

                allStacks[from] = temp.ToArray();
            }
            else
            {
                var stackId = line.Substring(0, 1);
                var stackStructure = line.Substring(1);
                var only_letters = stackStructure.Replace("[","").Replace("]","").Replace(" ","").Replace("\t","").Trim();
                var stackArray = only_letters.ToCharArray();
                
                allStacks.Add(stackId, stackArray); 
            }
        }

        foreach (var stack in allStacks)
        {
            result += stack.Value.First();
        }
        
        
        return result;
    }

}
