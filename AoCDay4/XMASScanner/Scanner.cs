namespace XMASScanner;
using System.Text.RegularExpressions;

public static class Scanner
{
    public static int FindAll(string[] lines, string pattern)
    {
        var count = 0;
        var charArr =  pattern.ToCharArray();
        var reversed = charArr.Reverse().ToArray();
        var backwardsPattern = new string(reversed);

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            var fowardMatches = Regex.Matches(line, pattern);
            var backwardsMathces = Regex.Matches(line, backwardsPattern);

            count += fowardMatches.Count();
            count += backwardsMathces.Count();

            var firstLetterMatches = Regex.Matches(line, "X|S");

            if (i + 3 < lines.Length)
            {
                foreach (Match match in firstLetterMatches)
                {
                    var matchIndex = match.Index;

                    var virtical = new string(
                        new char[] 
                        {
                            lines[i][matchIndex],
                            lines[i+1][matchIndex],
                            lines[i+2][matchIndex],
                            lines[i+3][matchIndex],
                        });

                    count += Regex.Matches(virtical, pattern+"|"+backwardsPattern).Count();
                    
                    if (matchIndex + 3 < line.Length)
                    {
                        var diagonal = new string(
                            new char[] 
                            {
                                lines[i][matchIndex],
                                lines[i+1][matchIndex + 1],
                                lines[i+2][matchIndex + 2],
                                lines[i+3][matchIndex + 3],
                            });
                        
                        count += Regex.Matches(diagonal, pattern+"|"+backwardsPattern).Count();
                    }    

                    if (matchIndex >= 3)
                    {
                        var negDiagonal = new string(
                            new char[] 
                            {
                                lines[i][matchIndex],
                                lines[i+1][matchIndex - 1],
                                lines[i+2][matchIndex - 2],
                                lines[i+3][matchIndex - 3],
                            });

                        count += Regex.Matches(negDiagonal, pattern+"|"+backwardsPattern).Count();
                    }
                }
            }
        }
        
        return count;
    }

}
