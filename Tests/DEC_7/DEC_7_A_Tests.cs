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
        sum.Should().Be(1845346);

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
    private static float Sum(string[] lines)
    {
        var changeDir = "$ cd ";
        var listDir = "$ ls";
        var dirName = "dir";

        var currentDirrD = new Dir { FolderName = "/" };

        Dir currentFolder = null;
        var dictionarys = new Dictionary<string, Dir>();
        var currentDir = "";

        var stack = new Stack<string>();
        stack.Push("root");

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
                            var defKey = stack.ToList();
                            defKey.Reverse();
                            var key = string.Join("-", defKey) + "-" + command;
                            stack.Push(command);
                            if (!dictionarys.ContainsKey(key))
                            {
                                var dir1 = new Dir
                                {
                                    FolderName = command
                                };

                                dictionarys.Add(key, dir1);
                            }

                            currentDirrD = dictionarys[key];
                            break;
                        }
                    case "..":
                        {
                            stack.Pop();
                            var defKey = stack.ToList();
                            defKey.Reverse();
                            currentDir = string.Join("-", defKey);
                            currentDirrD = dictionarys[currentDir];
                            break;
                        }
                    default:
                        {
                            var defKey = stack.ToList();
                            defKey.Reverse();
                            var key = string.Join("-",defKey) + "-" + command;
                            if (!dictionarys.ContainsKey(key))
                            {
                                var dir1 = new Dir
                                {
                                    FolderName = command
                                };

                                dictionarys.Add(key, dir1);
                            }

                            stack.Push(command);

                            currentDirrD = dictionarys[key];

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
                var key = "";

                var defKey = stack.ToList();
                defKey.Reverse();
                key = string.Join("-",defKey) + "-" + command;


                if (!dictionarys.ContainsKey(key))
                {
                    var dir1 = new Dir
                    {
                        Parent = currentDirrD,
                        FolderName = command
                    };

                    dictionarys.Add(key, dir1);
                }

                currentDirrD.Folders.Add(dictionarys[key]);
            }
            else
            {
                var command = line.Split(" ");
                currentDirrD.Files.Add(new XFile { Size = Int32.Parse(command[0]), FileName = command[1] });
            }
        }

        float result = 0;

        foreach (var val in dictionarys.Values)
        {
            var fileSum = 0F;
            try
            {
                fileSum = val.sumFiles() + sumMe(val.Folders);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{val.FolderName} : TO BIG EXCEPTION");
                continue;
            }


            if (fileSum > 100000)
            {
                Console.WriteLine($"{val.FolderName} : {fileSum} TO BIG");
                continue;
            }
            Console.WriteLine($"{val.FolderName} : {fileSum} ");
            result += fileSum;
        }

        return result;
    }

    public static float sumMe(IList<Dir> dirs)
    {
        if (!dirs.Any())
        {
            return 0;
        }

        if (dirs.Sum(x => x.sumFiles()) > 100000)
        {
            throw new Exception();
        }
        return dirs.Sum(x => x.sumFiles() + sumMe(x.Folders));
    }

    public class Dir
    {
        public Dir Parent { get; set; }
        public string FolderName { get; set; }
        public List<XFile> Files { get; set; } = new List<XFile>();
        public List<Dir> Folders { get; set; } = new List<Dir>();

        public float sumFiles()
        {
            return Files.Sum(x => x.Size);
        }
    }
}
public class XFile
{
    public string FileName { get; set; }
    public float Size { get; set; }
}
