namespace FinalTask18._4._1
{
    internal class Sender
    {
        Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        // Вывод в консоль
        public void ConsoleOutput(string url)
        {
            _command.ConsoleOutput(url);
        }

        // Скачивание
        public void DownloadVideo(string url, string outputFilePath)
        {
            _command.DownloadVideo(url, outputFilePath);
        }
    }
}