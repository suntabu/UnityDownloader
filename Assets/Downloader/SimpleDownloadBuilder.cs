using System;


namespace Downloader
{
    public class SimpleDownloadBuilder : IDownloadBuilder
    {
        private readonly IWebRequestBuilder requestBuilder;

        private readonly IDownloadChecker downloadChecker;

        public SimpleDownloadBuilder(IWebRequestBuilder requestBuilder, IDownloadChecker downloadChecker)
        {
            if (requestBuilder == null)
                throw new ArgumentNullException("requestBuilder");

            if (downloadChecker == null)
                throw new ArgumentNullException("downloadChecker");

            this.requestBuilder = requestBuilder;
            this.downloadChecker = downloadChecker;
        }

        public IDownload Build(Uri url, int bufferSize, long? offset, long? maxReadBytes)
        {
            return new SimpleDownload(url, bufferSize, offset, maxReadBytes, this.requestBuilder, this.downloadChecker);
        }
    }
}