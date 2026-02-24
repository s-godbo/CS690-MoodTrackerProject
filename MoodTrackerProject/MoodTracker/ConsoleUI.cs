using Spectre.Console;

namespace MoodTracker;

public class ConsoleUI
{
    FileSaver fileSaver;

    public ConsoleUI()
    {
        fileSaver = new FileSaver("daymood-data.txt");
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

                string moodName = AskForInput("Please select how you feel your overall mood was today (Excellent, Good, Okay, Bad, or Worst): ");
                
                int recordNum = 1;
                if (File.Exists("daymood-data.txt"))
                {
                    recordNum = File.ReadAllLines("daymood-data.txt").Length + 1;
                }

                fileSaver.AppendLine(recordNum+":"+moodName);

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