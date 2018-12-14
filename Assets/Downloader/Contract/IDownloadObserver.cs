using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Downloader
{
    public interface IDownloadObserver
    {
        void Attach(IDownload download);

        void Detach(IDownload download);

        void DetachAll();
    }
}