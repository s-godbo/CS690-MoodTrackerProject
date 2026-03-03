namespace MoodTracker;

public class Reporter{


    public static MoodReport FindMostMood(List<PersonRecord> data)
    {
        Dictionary<string, int> CountPerMood = new Dictionary<string, int>();

        foreach(var piece in data)
        {
            if(!CountPerMood.ContainsKey(piece.Mood.Name))
            {
                CountPerMood.Add(piece.Mood.Name, 0);
            }

            CountPerMood[piece.Mood.Name] += 1;
        }
        //find the highest mood
        String highestMood = "";
        int highest = -1;

        foreach(var moodCountPair in CountPerMood)
        {
            if(moodCountPair.Value>highest)
            {
                highestMood = moodCountPair.Key;
                highest = moodCountPair.Value;
            }
        }
        return new MoodReport
        {
            MostMood = new Mood(highestMood),
            TotalDays = data.Count,
            MoodCounts = CountPerMood
        };
    }
}

public class MoodReport
{
    public Mood MostMood { get; set; }
    public int TotalDays {get; set; }
    public Dictionary<string, int> MoodCounts {get; set; }
}