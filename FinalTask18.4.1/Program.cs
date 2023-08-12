using System;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask18._4._1
{
    internal class Program
    {
        public static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\YourVideo.mp4";
        //private static string VideoURL = "https://www.youtube.com/watch?v=JT9tHO2vBF0";
        //const string defaultVideoName = "https://www.youtube.com/watch?v=A7MNA-qMOMM";

        static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string videoURL = string.Empty;
            Console.Write("Введите ссылку на видео с YouTube: ");
            videoURL = Console.ReadLine();
            Console.WriteLine();

            // создаем отправителя
            var sender = new Sender();

            // создаем получателя
            var receiver = new Receiver();

            // создаем команду
            var commandOne = new CommandOne(receiver);

            // инициализиуем команду
            sender.SetCommand(commandOne);

            // выполняем команду по выводу информации
            sender.ConsoleOutput(videoURL);
            Console.WriteLine();

            // выполняем команду по скачиванию
            sender.DownloadVideo(videoURL, filePath);
            Console.ReadKey();
        }
    }
}