using XMASScanner;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("/Users/patrickcandlin/AoC2024/AoCDay4/Input.txt");

var count = Scanner.FindAll(lines, "XMAS");

Console.WriteLine($"XMAS found: {count} times!");

var count2 = XScanner.FindAll(lines);

Console.WriteLine($"X-MAS found: {count2} times!");