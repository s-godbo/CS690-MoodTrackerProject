namespace MoodTracker;

public class DataManager
{
    FileSaver fileSaver;
    public List<Mood> Moods { get; }
    public List<Stress> Stresses { get; }
    public List<Weather> Weathers { get; }
    public List<SocialInteract> SocialInteracts { get; }
    public List<Sleep> Sleeps { get; }
    public List<PersonRecord> PersonRecord { get; }

    public DataManager()
    {
        
        fileSaver = new FileSaver("daymood-data.txt");

        Moods = new List<Mood>();
        Moods.Add(new Mood("Excellent"));
        Moods.Add(new Mood("Good"));
        Moods.Add(new Mood("Okay"));
        Moods.Add(new Mood("Bad"));
        Moods.Add(new Mood("Worst"));

        Stresses = new List<Stress>();
        Stresses.Add(new Stress("Low"));
        Stresses.Add(new Stress("High"));

        Weathers = new List<Weather>();
        Weathers.Add(new Weather("Sunny"));
        Weathers.Add(new Weather("Cloudy"));

        SocialInteracts = new List<SocialInteract>();
        SocialInteracts.Add(new SocialInteract("Positive"));
        SocialInteracts.Add(new SocialInteract("Negative"));

        Sleeps = new List<Sleep>();
        Sleeps.Add(new Sleep("Feeling Well Rested"));
        Sleeps.Add(new Sleep("Feeling Tired"));

        PersonRecord = new List<PersonRecord>();
    }

    public void AddNewPersonRecord(PersonRecord data)
    {
        this.PersonRecord.Add(data);
        this.fileSaver.AppendData(data);
    }
}