using System;

namespace FinalTask18._4._1
{
    internal class CommandOne : Command
    {
        Receiver receiver;

        public CommandOne(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public override void ConsoleOutput(string url)
        {
            Console.WriteLine("Команда вывода");
            receiver.Operation();
            receiver.GetVideoInfo(url);
        }

        public override void DownloadVideo(string url, string outputFilePath)
        {
            Console.WriteLine("Команда скачки");
            receiver.Operation();
            receiver.DownloadVideo(url, outputFilePath);
        }
    }
}