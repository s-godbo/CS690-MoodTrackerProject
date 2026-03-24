namespace MoodTracker.Tests;

public class DataManagerTests
{
    private readonly string moodsFile = "moods.txt";
    private readonly string dataFile = "daymood-data.txt";

    public DataManagerTests()
    {
        if (File.Exists(moodsFile))
            File.Delete(moodsFile);

        if (File.Exists(dataFile))
            File.Delete(dataFile);

        File.WriteAllLines(moodsFile, new[]
        {
            "Good",
            "Bad",
            "Okay"
        });
    }

    [Fact]
    public void DataManager_LoadsMoodsFromFile()
    {
        var dm = new DataManager();

        Assert.Equal(3, dm.Moods.Count);
        Assert.Contains(dm.Moods, m => m.Name == "Good");
        Assert.Contains(dm.Moods, m => m.Name == "Bad");
        Assert.Contains(dm.Moods, m => m.Name == "Okay");
    }

    [Fact]
    public void Test_AddNewPersonRecord()
    {
        var dm = new DataManager();

        var record = new PersonRecord(
            1,
            new Mood("Good"),
            new Stress("Low"),
            new Weather("Sunny"),
            new SocialInteract("Positive"),
            new Sleep("Feeling Well Rested")
        );

        dm.AddNewPersonRecord(record);

        Assert.Single(dm.PersonRecord);
        Assert.Equal("Good", dm.PersonRecord[0].Mood.Name);
    }

    [Fact]
    public void AddNewPersonRecord_WritesToFile()
    {
        var dm = new DataManager();

        var record = new PersonRecord(
            1,
            new Mood("Good"),
            new Stress("Low"),
            new Weather("Sunny"),
            new SocialInteract("Positive"),
            new Sleep("Feeling Well Rested")
        );

        dm.AddNewPersonRecord(record);

        Assert.True(File.Exists(dataFile));

        var content = File.ReadAllText(dataFile);
        Assert.Equal("1:Good:Low:Sunny:Positive:Feeling Well Rested" + Environment.NewLine, content);
    }

    [Fact]
    public void DataManager_LoadsExistingPersonRecords()
    {
        File.WriteAllLines(dataFile, new[]
        {
            "1:Good:Low:Sunny:Positive:Feeling Well Rested",
            "2:Bad:High:Cloudy:Negative:Feeling Tired"
        });

        var dm = new DataManager();

        Assert.Equal(2, dm.PersonRecord.Count);

        Assert.Equal("Good", dm.PersonRecord[0].Mood.Name);
        Assert.Equal("Bad", dm.PersonRecord[1].Mood.Name);
    }
}
