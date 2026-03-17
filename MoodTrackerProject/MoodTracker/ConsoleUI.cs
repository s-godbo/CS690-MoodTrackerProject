using Spectre.Console;

namespace MoodTracker;

public class ConsoleUI
{
    DataManager dataManager;

   
    public ConsoleUI()
    {
        dataManager = new DataManager();

    }

    public void Show()
    {
        var loginornot = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                                .Title("To enter the Mood Tracker please select login:")
                                .AddChoices(new[]
                                {
                                    "login","never mind"
                                })
            );
        if (loginornot == "never mind")
        {
            Console.WriteLine("Bye for now! Please select login next time if you want to enter the Mood Tracker!");
            return;
        }

        string name = AskForInput("Please enter your name: ");
        Console.WriteLine($"Hi {name}! You have entered the Mood Tracker!");
        Console.WriteLine("");
        
        string mode;
        do {
            mode = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("Please select choice")
                                .AddChoices(new[]
                                {
                                    "record a day","display mood data","display trigger data","logout"
                                })
            );

            if(mode=="record a day") {

                string command;

                do {

                    Mood selectedMood = AnsiConsole.Prompt(
                                new SelectionPrompt<Mood>()
                                .Title("Please select how you feel your overall mood was today")
                                .AddChoices(dataManager.Moods));
                    Console.WriteLine("You selected that your mood was "+selectedMood.Name+" today.");

                    Stress selectedStress = AnsiConsole.Prompt(
                                new SelectionPrompt<Stress>()
                                .Title("Please select how you feel your overall stress was today")
                                .AddChoices(dataManager.Stresses)); 
                    Console.WriteLine("You selected that your overall stress was "+selectedStress.Name+" today.");   

                    Weather selectedWeather = AnsiConsole.Prompt(
                                new SelectionPrompt<Weather>()
                                .Title("Please select the overall weather today")
                                .AddChoices(dataManager.Weathers));  
                    Console.WriteLine("You selected that the weather was mostly "+selectedWeather.Name+" today.");

                    SocialInteract selectedSocialInteract = AnsiConsole.Prompt(
                                new SelectionPrompt<SocialInteract>()
                                .Title("Please select how you felt your social interactions were today")
                                .AddChoices(dataManager.SocialInteracts));   
                    Console.WriteLine("You selected that your social interactions were mostly "+selectedSocialInteract.Name+" today.");     

                    Sleep selectedSleep = AnsiConsole.Prompt(
                                new SelectionPrompt<Sleep>()
                                .Title("Please select how you felt when you woke up today")
                                .AddChoices(dataManager.Sleeps));   
                    Console.WriteLine("You selected that you felt "+selectedSleep.Name+" today.");                    

                    int recordNum = 1;
                    if (File.Exists("daymood-data.txt"))
                    {
                        recordNum = File.ReadAllLines("daymood-data.txt").Length + 1;
                    }

                    PersonRecord data = new PersonRecord(recordNum, selectedMood, selectedStress, selectedWeather, selectedSocialInteract, selectedSleep);
                    
                    dataManager.AddNewPersonRecord(data);

                    command = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("Do you want to 'continue' to record another day or 'end'?")
                                .AddChoices(new[]
                                {
                                    "continue","end"
                                }));
                

                } while(command!="end");

            } else if(mode=="display mood data")
            {
                string command;
                do
                {
                    var result = Reporter.FindMostMood(dataManager.PersonRecord);
                    Console.WriteLine("");
                    Console.WriteLine("Overall you had more "+result.MostMood.Name+" mood days.");
                    Console.WriteLine("");
                    Console.WriteLine("You recorded a total number of "+result.TotalDays+" days.");
                    Console.WriteLine("");
                    foreach (var pair in result.MoodCounts)
                    {
                        Console.WriteLine($"{pair.Value} days were {pair.Key} ");
                    }
                    Console.WriteLine("");


                command = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("Do you want to 'continue' to continue to look at the mood data or 'end'?")
                                .AddChoices(new[]
                                {
                                    "continue","end"
                                })); 
                } while(command!="end");

            } else if (mode == "logout")
            {
                Console.WriteLine("Logging out...");
                break;
            }   

        } while(mode!="logout");
    }

    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}