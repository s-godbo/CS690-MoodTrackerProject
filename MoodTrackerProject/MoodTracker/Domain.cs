namespace MoodTracker;

public class Person
{
    public string Name { get; }

    public Person(string name)
    {
        this.Name = name;
    }
}

public class Mood
{
    public string Name { get; }

    public Mood(string name)
    {
        this.Name = name;
    }

    public override string ToString()
    {
        return this.Name;
    }
}

public class Trigger
{
    public string Name { get; }

    public Trigger(string name)
    {
        this.Name = name;
    }
}

public class Stress
{
    public string Name { get; }

    public Stress(string name)
    {
        this.Name = name;
    }

    public override string ToString()
    {
        return this.Name;
    }
}

public class Weather
{
    public string Name { get; }

    public Weather(string name)
    {
        this.Name = name;
    }

    public override string ToString()
    {
        return this.Name;
    }
}

public class SocialInteract
{
    public string Name { get; }

    public SocialInteract(string name)
    {
        this.Name = name;
    }

    public override string ToString()
    {
        return this.Name;
    }
}

public class Sleep
{
    public string Name { get; }

    public Sleep(string name)
    {
        this.Name = name;
    }

    public override string ToString()
    {
        return this.Name;
    }
}

public class SuggestAction
{
    public string Name { get; }

    public SuggestAction(string name)
    {
        this.Name = name;
    }
}

public class PersonRecord
{
    public int RecordNum { get; }
    public Mood Mood { get; }
    public Stress Stress { get; }
    public Weather Weather { get; }
    public SocialInteract SocialInteract { get; }
    public Sleep Sleep{ get; }

    public PersonRecord(int recordNum, Mood mood, Stress stress, Weather weather, SocialInteract socialInteract, Sleep sleep)
    {
        this.RecordNum = recordNum;
        this.Mood = mood;
        this.Stress = stress;
        this.Weather = weather;
        this.SocialInteract = socialInteract;
        this.Sleep = sleep;

    }
}