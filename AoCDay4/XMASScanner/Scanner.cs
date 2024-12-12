namespace XMASScanner;

public static class Scanner
{
    public static int FindAll(string path, string pattern) => 
    File.ReadLines(path)?.Select(line => line).Count() ?? 0;
}
