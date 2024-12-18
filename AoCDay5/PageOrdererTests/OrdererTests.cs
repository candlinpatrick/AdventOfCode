namespace PageOrdererTests;

using PageOrderer;

public class PageOrdererTests
{
    [Fact]
    public void WhenGivenSimpleInputShouldReturn12()
    {
        var input = "13|12/n" + "13|22/n" + "12|22/n" + "\n" + "13,12,22";

        var result = Orderer.GetSumOfMidpoints(input);

        Assert.Equal(12, result);
    }
}
