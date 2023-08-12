using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using System.Threading.Tasks;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace FinalTask18._4._1
{
    internal class Receiver
    {
        YoutubeClient youtube = new YoutubeClient();
        public string VideoName { get; set; }
        VideoId videoId;

        public void Operation()
        {
            Console.WriteLine("Процесс запущен");
        }

        bool ValidateVideo()
        {
            try
            {
                this.videoId = VideoId.Parse(this.VideoName);
                Console.WriteLine($"Found video: {videoId}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No video \"{this.VideoName}\" found. Exception Message: {ex.Message}");
                return false;
            }
        }

        public void GetVideoInfo(string url)
        {
            VideoName = url;
            if (!ValidateVideo()) return;

            var videoInfo = youtube.Videos.GetAsync(videoId);

            Console.WriteLine($"Название: {videoInfo.Result.Title}");
            Console.WriteLine($"Продолжительность: {videoInfo.Result.Duration}");
            Console.WriteLine($"Автор: {videoInfo.Result.Author}");
        }

        public async Task DownloadVideo(string url, string outputFilePath)
        {
            try
            {
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
                var streamInfo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();
                if (streamInfo is null)
                {
                    Console.Error.WriteLine("This video has no muxed streams.");
                    return;
                }

                Console.Write($"Downloading stream: {streamInfo.Container.Name}");                
                await youtube.Videos.Streams.DownloadAsync(streamInfo, outputFilePath);
                Console.WriteLine($"Video saved to '{outputFilePath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured while downloading: {ex.Message}");
            }
        }
    }
}