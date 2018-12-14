using System;

namespace Downloader
{
    public class TooManyRetriesException : Exception
    {
        public TooManyRetriesException()
            : base()
        {
        }
    }
}
