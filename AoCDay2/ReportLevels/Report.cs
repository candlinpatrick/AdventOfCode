using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace ReportLevels;

public class Report
{
    private const string increasing = "increasing";
    private const string decreasing = "decreasing";
    private const string noTrend = "no trend";
    public List<int> Levels;

    private string RawReport
    {
        get;
        set;
    }

    public Report(string rawReport)
    {
        RawReport = rawReport;
        Levels = rawReport.Split(" ").Select(x => int.Parse(x)).ToList();
    }

    public bool IsSafe(List<int> levels)
    {
        if (levels.Count < 2)
        {
            return true;
        }
        var differnce = levels[0] - levels[1];
        var absDiffernce = Math.Abs(differnce);

        if (0 == absDiffernce)
        {
            return false;
        }

        if (absDiffernce > 3)
        {
            return false;
        }

        var sign = differnce / absDiffernce;

        for(int i = 1; i < levels.Count - 1; i++)
        {
            var currentDiff = levels[i] - levels[i + 1];
            var abscurrentDiff = Math.Abs(currentDiff);

            if (abscurrentDiff > 3)
            {
                return false;
            }

            if (abscurrentDiff == 0)
            {
                return false;
            }

            var currentSign = currentDiff / abscurrentDiff;

            if (sign != currentSign)
            {
                return false;
            }
        }  

        return true;      
    }

    public bool IsSafeWithLevelRemoved(List<int> levels)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            var newList = levels.ToList();
            newList.RemoveAt(i);
            var isSafe = IsSafe(newList);
            if (isSafe)
            {
                return true;
            }
        }

        return false;
    }
}
