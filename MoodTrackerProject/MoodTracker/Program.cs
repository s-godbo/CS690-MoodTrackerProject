namespace MoodTracker;

using System.Data;
using System.Globalization;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please select mode (Record a day 'R', Display mood data 'M', or Display trigger data 'T'): ");
        string mode = Console.ReadLine();

        if(mode=="R") {

            string command;

            do {

                Console.Write("Please select how you feel your overall mood was today (Excellent, Good, Okay, Bad, or Worst): ");
                string moodName = Console.ReadLine();
                
                int recordNum = 1;
                if (File.Exists("daymood-data.txt"))
                {
                    recordNum = File.ReadAllLines("daymood-data.txt").Length + 1;
                }

                File.AppendAllText("daymood-data.txt",recordNum+":"+moodName+Environment.NewLine);

                Console.Write("Enter a command. 'end' to go back to select a different mode or 'continue' to record another day: ");
                command = Console.ReadLine();

            } while(command!="end");

        }
    }
}
