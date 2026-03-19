using Spectre.Console;

namespace MoodTracker;

public static class ConsolePlot
{
    public static void ShowMoodPlot(List<PersonRecord> records)
    {
        var ordered = records.OrderBy(r => r.RecordNum).ToList();

        var moodValues = ordered
            .Select(r => MoodScale.ToNumber(r.Mood.Name))
            .ToList();

        var moodLabels = new[]
        {
            "Excellent",
            "Good",
            "Okay",
            "Bad",
            "Worst"
        };

        var lines = new List<string>();

        for (int moodLevel = 5; moodLevel >= 1; moodLevel--)
        {
            string label = moodLabels[5 - moodLevel].PadRight(10);
            string row = label + " | ";

            foreach (var value in moodValues)
            {
                row += (value == moodLevel) ? "* " : "  ";
            }

            lines.Add(row);
        }

        string axis = "           " + new string('-', moodValues.Count * 2);
        string days = "             ";

        for (int i = 0; i < moodValues.Count; i++)
            days += $"{ordered[i].RecordNum} ";

        
        var output = string.Join("\n", lines) + "\n" + axis + "\n" + days;

        AnsiConsole.Write(output);
    }
}

