
namespace Downloader
{
    public class DownloadStartedEventArgs : DownloadEventArgs
    {
        public DownloadStartedEventArgs()
        {
        }

        public DownloadStartedEventArgs(IDownload download, DownloadCheckResult checkResult,
            long alreadyDownloadedSize = 0)
        {
            this.Download = download;
            this.CheckResult = checkResult;
            this.AlreadyDownloadedSize = alreadyDownloadedSize;
        }

        public DownloadCheckResult CheckResult { get; set; }

        public long AlreadyDownloadedSize { get; set; }
    }
}