using System;
using XMASScanner;

namespace XMASScannerTests;

public class XScannerTests
{
    [Fact]
    public void GivenEmptyString_ShouldReturnZero()
    {
        var result = XScanner.FindAll(new string[] { });

        Assert.Equal(0, result);
    } 

    [Fact]
    public void GivenOneXMas_ShouldReturnOne()
    {
        var xmas = new string[]
        {
            "MBM",
            "BAB",
            "SAS",
        };

        var result = XScanner.FindAll(xmas);

        Assert.Equal(1,result);
    }

    [Fact]
    public void GivenUsideDownXMas_ShouldReturnOne()
    {
        var xmas = new string[]
        {
            "SBS",
            "BAB",
            "MAM",
        };

        var result = XScanner.FindAll(xmas);

        Assert.Equal(1,result);
    }

    [Fact]
    public void GivenOnSideXMas_ShouldReturnOne()
    {
        var xmas = new string[]
        {
            "MBS",
            "BAB",
            "MAS",
        };

        var result = XScanner.FindAll(xmas);

        Assert.Equal(1,result);
    }

    [Fact]
    public void GivenOnOtherSideXMas_ShouldReturnOne()
    {
        var xmas = new string[]
        {
            "SBM",
            "BAB",
            "SAM",
        };

        var result = XScanner.FindAll(xmas);

        Assert.Equal(1,result);
    }

    [Fact]
    public void GivenExmapleCase_ShouldReturnExpected()
    {
        var sample = new string[]
            {
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            };
        var result = XScanner.FindAll(sample);

        Assert.Equal(9,result);
    }
}
