
namespace Downloader
{
    public class DownloadDataReceivedEventArgs : DownloadEventArgs
    {
        public DownloadDataReceivedEventArgs()
        {
        }

        public DownloadDataReceivedEventArgs(IDownload download, byte[] data, long offset, int count)
        {
            this.Download = download;
            this.Data = data;
            this.Offset = offset;
            this.Count = count;
        }

        public byte[] Data { get; set; }

        public long Offset { get; set; }

        public int Count { get; set; }
    }
}
