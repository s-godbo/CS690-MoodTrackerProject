namespace MoodTracker.Tests;

using MoodTracker;

public class FileSaverTests
{
    FileSaver fileSaver;
    string testFileName;

    public FileSaverTests()
    {
        testFileName = "test-doc.txt";
        fileSaver = new FileSaver(testFileName);
    }
    
    [Fact]
    public void Test_FileSaver_Append()
    {
        fileSaver.AppendLine("Hello, World!");
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("Hello, World!"+Environment.NewLine,contentFromFile);
    }

    [Fact]
    public void Test_FileSaver_AppendData()
    {
        Mood sampleMood = new Mood("MyMood");
        Stress sampleStress = new Stress("MyStress");
        Weather sampleWeather = new Weather("MyWeather");
        SocialInteract sampleSocialInteract = new SocialInteract("MySocialInteract");
        Sleep sampleSleep = new Sleep("MySleep");
        PersonRecord sampleData = new PersonRecord(1,sampleMood,sampleStress,sampleWeather,sampleSocialInteract,sampleSleep);

        fileSaver.AppendData(sampleData);
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("1:MyMood:MyStress:MyWeather:MySocialInteract:MySleep"+Environment.NewLine,contentFromFile);
    }
}
