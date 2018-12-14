using System;

namespace Downloader
{
    public class DownloadCancelledEventArgs : DownloadEventArgs
    {
        public DownloadCancelledEventArgs()
        {
        }

        public DownloadCancelledEventArgs(IDownload download, Exception exception)
        {
            this.Download = download;
            this.Exception = exception;
        }

        public Exception Exception { get; set; }
    }
}
