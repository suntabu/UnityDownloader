using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Downloader
{
    public interface IDownloadBuilder
    {
        IDownload Build(Uri url, int bufferSize, long? offset, long? maxReadBytes);
    }
}