using snakesandladders;
using Xunit;

namespace snakesandladderstests;

public class RegularSixSidesDiceTest
{
    [Fact]
    public void RollShouldReturnAValueBetween1And6()
    {
        RegularSixSidesDice dice = new RegularSixSidesDice();

        int result = dice.Roll();

        Assert.True(result >= 1 && result <= 6);
    }    
}