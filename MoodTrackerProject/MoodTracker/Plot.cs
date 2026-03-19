namespace MoodTracker;

using ScottPlot;

public static class Plot
{
    public static void CreateMoodPlot(List<PersonRecord> records)
    {
        
        var ordered = records.OrderBy(r => r.RecordNum).ToList();
        double[] days = ordered.Select(r => (double)r.RecordNum).ToArray();
        double[] moodValues = ordered.Select(r =>
            (double)MoodScale.ToNumber(r.Mood.Name)
        ).ToArray();

        var plt = new ScottPlot.Plot();

        plt.Add.Scatter(days, moodValues);
        plt.Axes.Bottom.Label.Text = "Days";
        plt.Axes.Left.Label.Text = "Mood";
        plt.Axes.Left.SetTicks(
            new double[] { 1, 2, 3, 4, 5 },
            new string[] { "Worst", "Bad", "Okay", "Good", "Excellent" }
        );

        plt.SavePng("mood_plot.png", 600, 400);

    }
}

