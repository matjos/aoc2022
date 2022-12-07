using System.Reflection;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests;

[TestFixture]
public class DEC_7_A_Tests : BaseTest
{

    [Test]
    public void Star1()
    {
        //Arrange
        timer.StartTimer();
        var lines = FileReader.ReadFile(@"DEC_7\input.txt");

        //Act
        var sum = Sum(lines.ToArray());

        //Assert
        Console.WriteLine(sum);
        sum.Should().Be(0);

        Console.WriteLine(timer.StopTimer());
    }

    [Test]
    public void Star1_Example()
    {
        //Arrange
        timer.StartTimer();
        var lines = FileReader.ReadFile(@"DEC_7\example.txt");

        //Act
        var sum = Sum(lines.ToArray());

        //Assert
        Console.WriteLine(sum);
        sum.Should().Be(95437);
        Console.WriteLine(timer.StopTimer());
    }
    private static int Sum(string[] lines)
    {
        var changeDir = "$ cd ";
        var listDir = "$ ls";
        var dirName = "dir";

        var currentDirrD = new Dir{FolderName = "/"};

        Dir currentFolder = null;
        var dictionarys = new Dictionary<string, Dir>();
        var currentDir = "";

        var stack = new Stack<string>();

        var dir = new Dir();

        var isFileList = false;

        foreach (var line in lines)
        {
            if (line.Contains(changeDir))
            {
                var commands = line.Split(" ");
                var command = commands.Last();

                switch (command)
                {
                    case "/":
                        {
                            stack = new Stack<string>();
                            stack.Push("/");
                            if (!dictionarys.ContainsKey(command))
                            {
                                var dir1 = new Dir
                                {
                                    FolderName = command
                                };
                                
                                dictionarys.Add(command, dir1);
                            }

                            currentDirrD = dictionarys[command];
                            break;
                        }
                    case "..":
                        {
                            stack.Pop();
                            currentDir = stack.Peek();
                            currentDirrD = dictionarys[currentDir];
                            break;
                        }
                    default:
                        {
                            stack.Push(command);
                            if (!dictionarys.ContainsKey(command))
                            {
                                var dir1 = new Dir
                                {
                                    FolderName = command
                                };
                                
                                dictionarys.Add(command, dir1);
                            }
                            
                            currentDir = stack.Peek();
                            currentDirrD = dictionarys[currentDir];
                            
                            break;
                        }
                }
            }
            else if (line.Contains(listDir))
            {
                isFileList = true;
            }
            else if (line.Contains(dirName))
            {
                var commands = line.Split(" ");
                var command = commands.Last();
                
                if (!dictionarys.ContainsKey(command))
                {
                    var dir1 = new Dir
                    {
                        FolderName = command
                    };
                                
                    dictionarys.Add(command, dir1);
                }
            }
            else
            {
                var command = line.Split(" ");
                currentDirrD.Files.Add(new XFile{Size = Int32.Parse(command[0]), FileName = command[1]});
            }
        }
        return 0;
    }

    public class Dir
    {
        public string FolderName { get; set; }
        public List<XFile> Files { get; set; } = new List<XFile>();

        public int sumFiles()
        {
            return Files.Sum(x => x.Size);
        }
    }
}
public class XFile
{
    public string FileName { get; set; }
    public int Size { get; set; }
}
