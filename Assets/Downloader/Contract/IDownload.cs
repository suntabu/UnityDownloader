using System;

namespace Downloader
{
    public interface IDownload : IDisposable
    {
        event DownloadDelegates.DownloadDataReceivedHandler DataReceived;

        event DownloadDelegates.DownloadStartedHandler DownloadStarted;

        event DownloadDelegates.DownloadCompletedHandler DownloadCompleted;

        event DownloadDelegates.DownloadStoppedHandler DownloadStopped;

        event DownloadDelegates.DownloadCancelledHandler DownloadCancelled;

        DownloadState State { get; }

        void Start();

        void Stop();

        void DetachAllHandlers();
    }
}