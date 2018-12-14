
namespace Downloader
{
    public class DownloadEventArgs
    {
        public IDownload Download { get; set; }

        public DownloadEventArgs()
        {
        }

        public DownloadEventArgs(IDownload download)
        {
            this.Download = download;
        }
    }
}
