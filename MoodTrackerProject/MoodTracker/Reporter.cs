namespace MoodTracker;

public class Reporter
{
    public static MoodReport FindMostMood(List<PersonRecord> data)
    {
        Dictionary<string, int> CountPerMood = new Dictionary<string, int>();

        foreach (var piece in data)
        {
            if (!CountPerMood.ContainsKey(piece.Mood.Name))
            {
                CountPerMood.Add(piece.Mood.Name, 0);
            }

            CountPerMood[piece.Mood.Name] += 1;
        }

        string highestMood = "";
        int highest = -1;

        foreach (var moodCountPair in CountPerMood)
        {
            if (moodCountPair.Value > highest)
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

    public static MoodReport FindTrigger(List<PersonRecord> data, string moodName)
    {
        var filtered = data.Where(record => record.Mood.Name == moodName).ToList();

        if (filtered.Count == 0)
        {
            return new MoodReport
            {
                MostMood = new Mood(moodName),
                TotalDays = 0,
                MostCommonStress = "NO DATA ENTERED FOR",
                MostCommonWeather = "NO DATA ENTERED FOR",
                MostCommonSocial = "NO DATA ENTERED FOR",
                MostCommonSleep = "NO DATA ENTERED FOR",

                StressCounts = new Dictionary<string, int>()
                {
                    {"Low", 0},
                    {"High", 0}
                },
                WeatherCounts = new Dictionary<string, int>()
                {
                    {"Sunny", 0},
                    {"Cloudy", 0}
                },
                SocialCounts = new Dictionary<string, int>()
                {
                    {"Positive", 0},
                    {"Negative", 0}
                },
                SleepCounts = new Dictionary<string, int>()
                {
                    {"Feeling Well Rested", 0},
                    {"Feeling Tired", 0}
                }

            };
        }

        var stressCounts = new Dictionary<string, int>()
        {
            {"Low", 0},
            {"High", 0}
        };
        var weatherCounts = new Dictionary<string, int>()
        {
            {"Sunny", 0},
            {"Cloudy", 0}
        };
        var socialCounts = new Dictionary<string, int>()
        {
            {"Negative", 0},
            {"Positive", 0}
        };
        var sleepCounts = new Dictionary<string, int>()
        {
            {"Feeling Well Rested", 0},
            {"Feeling Tired", 0}
        };

        foreach (var record in filtered)
        {
            Count(stressCounts, record.Stress.Name);
            Count(weatherCounts, record.Weather.Name);
            Count(socialCounts, record.SocialInteract.Name);
            Count(sleepCounts, record.Sleep.Name);
        }

        return new MoodReport
        {
            MostMood = new Mood(moodName),
            TotalDays = filtered.Count,
            MostCommonStress = GetMax(stressCounts),
            MostCommonWeather = GetMax(weatherCounts),
            MostCommonSocial = GetMax(socialCounts),
            MostCommonSleep = GetMax(sleepCounts),

            StressCounts = stressCounts,
            WeatherCounts = weatherCounts,
            SocialCounts = socialCounts,
            SleepCounts = sleepCounts

        };
    }

    private static void Count(Dictionary<string, int> dict, string key)
    {
        if (!dict.ContainsKey(key))
            dict[key] = 0;

        dict[key]++;
    }

    private static string GetMax(Dictionary<string, int> dict)
    {
        return dict.OrderByDescending(p => p.Value).First().Key;
    }
}

public class MoodReport
{
    public Mood MostMood { get; set; }
    public int TotalDays { get; set; }
    public Dictionary<string, int> MoodCounts { get; set; }

    public string MostCommonStress { get; set; }
    public string MostCommonWeather { get; set; }
    public string MostCommonSocial { get; set; }
    public string MostCommonSleep { get; set; }

    public Dictionary<string, int> StressCounts { get; set; }
    public Dictionary<string, int> WeatherCounts { get; set; }
    public Dictionary<string, int> SocialCounts { get; set; }
    public Dictionary<string, int> SleepCounts { get; set; }

}

public static class MoodScale
{
    public static int ToNumber(string moodName)
    {
        return moodName.ToLower() switch
        {
            "worst" => 1,
            "bad" => 2,
            "okay" => 3,
            "good" => 4,
            "excellent" => 5,
            _ => 3 // default to neutral
        };
    }
}

