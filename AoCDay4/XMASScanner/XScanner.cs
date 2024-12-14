using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace XMASScanner;

public static class XScanner
{
    public static int FindAll(string[] lines)
    {
        int count = 0;
        var topOfXPattern = "M[A-Z]M|S[A-Z]S|S[A-Z]M|M[A-Z]S";
        
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            var matches = Regex.Matches(line, topOfXPattern);

            foreach(Match match in matches)
            {
                var matchIndex = match.Index;
                var bottomPattern = BottomPatternHelper(match.Value);
                var middlePattern = "A";

                if (i + 2 < lines.Length 
                    && lines[i + 1][matchIndex + 1] == 'A' 
                    && Regex.IsMatch(lines[i + 2][matchIndex].ToString()+lines[i +2][matchIndex+1].ToString()+lines[i +2][matchIndex +2].ToString(),bottomPattern))
                {
                     count += 1;
                }
            }
        }

        return count;
    }

    private static string BottomPatternHelper(string topValueMatch)
    {
        if (Regex.IsMatch(topValueMatch, "M[A-Z]M")) return "S[A-Z]S";

        if (Regex.IsMatch(topValueMatch, "S[A-Z]S")) return "M[A-Z]M";

        if (Regex.IsMatch(topValueMatch,"S[A-Z]M")) return "S[A-Z]M";

        if (Regex.IsMatch(topValueMatch, "M[A-Z]S")) return "M[A-Z]S";

        return "none";
    }
}
