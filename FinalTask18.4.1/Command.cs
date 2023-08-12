namespace FinalTask18._4._1
{
    abstract class Command
    {
        public abstract void ConsoleOutput(string url);
        public abstract void DownloadVideo(string url, string outputFilePath);
    }
}