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
}
