using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace FinalTask18._4._1
{
    internal class Receiver
    {
        public void Operation()
        {
            Console.WriteLine("Процесс запущен");
        }

        public void GetVideoInfo(string url)
        {
            YoutubeClient youtube = new YoutubeClient();
            var videoInfo = youtube.Videos.GetAsync(url).Result;
            Console.WriteLine($"Название: {videoInfo.Title}");
            Console.WriteLine($"Продолжительность: {videoInfo.Duration}");
            Console.WriteLine($"Автор: {videoInfo.Author}");
        }

        public void DownloadVideo(string url, string outputFilePath)
        {
            YoutubeClient youtube = new YoutubeClient();
            youtube.Videos.DownloadAsync(url, outputFilePath, builder => builder.SetPreset(ConversionPreset.UltraFast)); // Файл фактически не скачивается. Не могу понять почему...
            Console.WriteLine("Ждем...");            
            Task.WaitAll();
            Console.WriteLine("Скачивание завершено!");            
        }
    }
}