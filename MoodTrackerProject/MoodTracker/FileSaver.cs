namespace MoodTracker;

using System.IO;

public class FileSaver
{
    string fileName;

    public FileSaver(string fileName)
    {
        this.fileName = fileName;
        if(!File.Exists(this.fileName)) {
            File.Create(this.fileName).Close();
        }
    }

    public void AppendLine(string line) {
        File.AppendAllText(this.fileName, line + Environment.NewLine);
    }

    public void AppendData(PersonRecord data)
    {
        File.AppendAllText(this.fileName, data.RecordNum + ":" + data.Mood + ":" + data.Stress + ":" + data.Weather + ":" + data.SocialInteract + ":" + data.Sleep + Environment.NewLine);
    }
}