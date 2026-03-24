namespace MoodTracker.Tests;

public class ReporterTests
{
    [Fact]
    public void FindMostMood_ReturnsCorrectMostMood()
    {
        
        var data = new List<PersonRecord>
        {
            new PersonRecord(1, new Mood("Good"),
                                new Stress("Low"),
                                new Weather("Sunny"),
                                new SocialInteract("Positive"),
                                new Sleep("Feeling Well Rested")),

            new PersonRecord(2, new Mood("Good"),
                                new Stress("High"),
                                new Weather("Cloudy"),
                                new SocialInteract("Negative"),
                                new Sleep("Feeling Tired")),

            new PersonRecord(3, new Mood("Bad"),
                                new Stress("High"),
                                new Weather("Sunny"),
                                new SocialInteract("Positive"),
                                new Sleep("Feeling Tired"))
        };

        
        var report = Reporter.FindMostMood(data);

        Assert.Equal("Good", report.MostMood.Name);
        Assert.Equal(3, report.TotalDays);
        Assert.Equal(2, report.MoodCounts["Good"]);
        Assert.Equal(1, report.MoodCounts["Bad"]);
    }

    [Fact]
    public void FindTrigger_NoDataForMood_ReturnsZeroCounts()
    {
        var data = new List<PersonRecord>();

        var report = Reporter.FindTrigger(data, "Good");

        Assert.Equal(0, report.TotalDays);
        Assert.Equal("NO DATA ENTERED FOR", report.MostCommonStress);
        Assert.Equal(0, report.StressCounts["Low"]);
        Assert.Equal(0, report.StressCounts["High"]);
    }

    [Fact]
    public void FindTrigger_ReturnsCorrectMostCommonTriggers()
    {
        var data = new List<PersonRecord>
        {
            new PersonRecord(1, new Mood("Good"),
                                new Stress("Low"),
                                new Weather("Sunny"),
                                new SocialInteract("Positive"),
                                new Sleep("Feeling Well Rested")),

            new PersonRecord(2, new Mood("Good"),
                                new Stress("High"),
                                new Weather("Sunny"),
                                new SocialInteract("Negative"),
                                new Sleep("Feeling Tired")),

            new PersonRecord(3, new Mood("Good"),
                                new Stress("High"),
                                new Weather("Cloudy"),
                                new SocialInteract("Negative"),
                                new Sleep("Feeling Tired"))
        };

        var report = Reporter.FindTrigger(data, "Good");
        
        Assert.Equal(3, report.TotalDays);
        Assert.Equal("High", report.MostCommonStress);
        Assert.Equal("Sunny", report.MostCommonWeather);
        Assert.Equal("Negative", report.MostCommonSocial);
        Assert.Equal("Feeling Tired", report.MostCommonSleep);
    }
}
