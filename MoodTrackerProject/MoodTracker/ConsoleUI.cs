using Spectre.Console;

namespace MoodTracker;

public class ConsoleUI
{
    FileSaver fileSaver;

    List<Mood> moods;
    List<Stress> stresses;
    List<Weather> weathers;
    List<SocialInteract> socialInteracts;
    List<Sleep> sleeps;

    public ConsoleUI()
    {
        fileSaver = new FileSaver("daymood-data.txt");

        moods = new List<Mood>();
        moods.Add(new Mood("Excellent"));
        moods.Add(new Mood("Good"));
        moods.Add(new Mood("Okay"));
        moods.Add(new Mood("Bad"));
        moods.Add(new Mood("Worst"));

        stresses = new List<Stress>();
        stresses.Add(new Stress("Low"));
        stresses.Add(new Stress("High"));

        weathers = new List<Weather>();
        weathers.Add(new Weather("Sunny"));
        weathers.Add(new Weather("Cloudy"));

        socialInteracts = new List<SocialInteract>();
        socialInteracts.Add(new SocialInteract("Positive"));
        socialInteracts.Add(new SocialInteract("Negative"));

        sleeps = new List<Sleep>();
        sleeps.Add(new Sleep("Feeling Well Rested"));
        sleeps.Add(new Sleep("Feeling Tired"));

    }

    public void Show()
    {
        var mode = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Please select choice")
                            .AddChoices(new[]
                            {
                                "record a day","display mood data","display trigger data"
                            })
        );

        if(mode=="record a day") {

            string command;

            do {

                Mood selectedMood = AnsiConsole.Prompt(
                            new SelectionPrompt<Mood>()
                            .Title("Please select how you feel your overall mood was today")
                            .AddChoices(moods));
                Console.WriteLine("You selected that your mood was "+selectedMood.Name+" today.");

                Stress selectedStress = AnsiConsole.Prompt(
                            new SelectionPrompt<Stress>()
                            .Title("Please select how you feel your overall stress was today")
                            .AddChoices(stresses)); 
                Console.WriteLine("You selected that your overall stress was "+selectedStress.Name+" today.");   

                Weather selectedWeather = AnsiConsole.Prompt(
                            new SelectionPrompt<Weather>()
                            .Title("Please select the overall weather today")
                            .AddChoices(weathers));  
                Console.WriteLine("You selected that the weather was mostly "+selectedWeather.Name+" today.");

                SocialInteract selectedSocialInteract = AnsiConsole.Prompt(
                            new SelectionPrompt<SocialInteract>()
                            .Title("Please select how you felt your social interactions were today")
                            .AddChoices(socialInteracts));   
                Console.WriteLine("You selected that your social interactions were mostly "+selectedSocialInteract.Name+" today.");     

                Sleep selectedSleep = AnsiConsole.Prompt(
                            new SelectionPrompt<Sleep>()
                            .Title("Please select how you felt when you woke up today")
                            .AddChoices(sleeps));   
                Console.WriteLine("You selected that you felt "+selectedSleep.Name+" today.");                    

                int recordNum = 1;
                if (File.Exists("daymood-data.txt"))
                {
                    recordNum = File.ReadAllLines("daymood-data.txt").Length + 1;
                }

                PersonRecord data = new PersonRecord(recordNum, selectedMood, selectedStress, selectedWeather, selectedSocialInteract, selectedSleep);
                fileSaver.AppendData(data);

                command = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Do you want to 'continue' to record another day or 'end'?")
                            .AddChoices(new[]
                            {
                                "continue","end"
                            }));
            

            } while(command!="end");
        }    

    }

    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}