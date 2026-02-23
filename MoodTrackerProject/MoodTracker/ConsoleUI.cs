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
        string mode = AskForInput("Please select mode (Record a day 'R', Display mood data 'M', or Display trigger data 'T'): ");

        if(mode=="R") {

            string command;

            do {

                string moodName = AskForInput("Please select how you feel your overall mood was today (Excellent, Good, Okay, Bad, or Worst): ");
                
                int recordNum = 1;
                if (File.Exists("daymood-data.txt"))
                {
                    recordNum = File.ReadAllLines("daymood-data.txt").Length + 1;
                }

                fileSaver.AppendLine(recordNum+":"+moodName);

                command = AskForInput("Enter a command. 'end' to go back to select a different mode or 'continue' to record another day: ");

            } while(command!="end");
        }    

    }

    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}