// See https://aka.ms/new-console-template for more information

using TextFilter;

var fileProcessor = new FileProcessor();
var result = fileProcessor.FilterFile("input.txt");
Console.WriteLine(result);
Console.WriteLine("Press any key to exit.");
Console.ReadKey();