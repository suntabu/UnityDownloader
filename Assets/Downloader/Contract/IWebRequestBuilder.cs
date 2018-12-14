using System;
using System.Net;

namespace Downloader
{
    public interface IWebRequestBuilder
    {
        HttpWebRequest CreateRequest(Uri url, long? offset);
    }
}
