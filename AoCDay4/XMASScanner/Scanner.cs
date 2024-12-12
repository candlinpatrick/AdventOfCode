namespace XMASScanner;

public static class Scanner
{
    public static int FindAll(string path, string pattern)
    {
        var count = 0;

        try
        {
            var lines = File.ReadAllLines(path);
        }
        catch (Exception ex)
        {
            return 0;
        }
        
        return count;
    }

}
