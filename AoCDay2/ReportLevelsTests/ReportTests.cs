namespace ReportLevelsTests;

using ReportLevels;

public class ReportTests
{
    [Fact]
    public void ReportInitTest()
    {
        var report = new Report("1 2 3");
        Assert.Equal(new int[]{1,2,3}, report.Levels);
    }

    [Theory]
    [InlineData("1 3 2")] // three items should pass
    [InlineData("4 1 2 3")] // remove 1st itme
    [InlineData("1 4 2 3")] // remove 2nd item
    [InlineData("4 3 5 1")] // remove 3rd item
    [InlineData("1 2 4 3")] //remove outside(4th) item
    public void WhenGiveOneWrongValueIsSafeShouldReturnTrue(string rawReport)
    {   
        var report = new Report(rawReport);

        Assert.True(report.IsSafeWithLevelRemoved(report.Levels));
    }
}
// 4 2 4 2
// 1 2 4 3
// [10 11 8 9 12]