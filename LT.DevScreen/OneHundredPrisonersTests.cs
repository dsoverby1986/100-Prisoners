using FluentAssertions;

namespace LT.DevScreen;

public class OneHundredPrisonersTests
{
    /// <summary>
    /// This test runs the trial many times to ensure that there is about a 31% success rate.
    /// </summary>
    [Test]
    public void One_Hundred_Prisoners_Optimal_Strategy_Has_31_Percent_Success_Rate()
    {
        const int trials = 333_333;
        var successes = Enumerable.Range(0, trials).Count(_ => OneHundredPrisoners.RunSimulation());
        var successRate = successes / (double) trials;
        successRate.Should().BeApproximately(.31, 0.005);
    }
}