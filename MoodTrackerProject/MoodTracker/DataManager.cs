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
        var moodsFileContent = File.ReadAllLines("moods.txt");

        foreach(var moodName in moodsFileContent)
        {
            Moods.Add(new Mood(moodName));
        }

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

        if(File.Exists("daymood-data.txt"))
        {
            var personFileContent = File.ReadAllLines("daymood-data.txt");
            foreach(var line in personFileContent)
            {
                var splitted = line.Split(":",StringSplitOptions.RemoveEmptyEntries);
                var recordNum = int.Parse(splitted[0]);

                var moodName = splitted[1];
                var mood = new Mood(moodName);

                var stressName = splitted[2];
                var stress = new Stress(stressName);

                var weatherName = splitted[3];
                var weather = new Weather(weatherName);

                var socialInteractName = splitted[4];
                var socialInteract = new SocialInteract(socialInteractName);

                var sleepName = splitted[5];
                var sleep = new Sleep(sleepName);

                PersonRecord.Add(new PersonRecord(recordNum,mood,stress,weather,socialInteract,sleep));
            }
        }
    }

    public void AddNewPersonRecord(PersonRecord data)
    {
        this.PersonRecord.Add(data);
        this.fileSaver.AppendData(data);
    }
}