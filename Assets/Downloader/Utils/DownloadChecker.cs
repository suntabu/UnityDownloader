using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Downloader
{
    public class DownloadChecker : IDownloadChecker
    {
        public DownloadCheckResult CheckDownload(WebResponse response)
        {
            var result = new DownloadCheckResult();
            var acceptRanges = response.Headers["Accept-Ranges"];
            result.SupportsResume = !string.IsNullOrEmpty(acceptRanges) && acceptRanges.ToLower().Contains("bytes");
            result.Size = response.ContentLength;
            var webResponse = response as HttpWebResponse;
            if (webResponse != null)
                result.StatusCode = (int?) (response as HttpWebResponse).StatusCode;
            result.Success = true;
            return result;
        }


        public DownloadCheckResult CheckDownload(Uri url, IWebRequestBuilder requestBuilder)
        {
            try
            {
                var request = requestBuilder.CreateRequest(url, null);

                using (var response = request.GetResponse())
                {
                    return CheckDownload(response);
                }
            }
            catch (WebException ex)
            {
                var webResponse = ex.Response as HttpWebResponse;
                int code = 0;
                if (webResponse != null)
                    code = (int) webResponse.StatusCode;
                return new DownloadCheckResult()
                {
                    Exception = ex,

                    StatusCode = code
                };
            }
            catch (Exception ex)
            {
                return new DownloadCheckResult() {Exception = ex};
            }
        }

        public bool MyRemoteCertificateValidationCallback(System.Object sender,
            X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            //Return true if the server certificate is ok
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                Debug.Log("certificate is OK");
                return true;
            }

            bool acceptCertificate = true;
            string msg = "The server could not be validated for the following reason(s):\r\n";

            //The server did not present a certificate
            if ((sslPolicyErrors &
                 SslPolicyErrors.RemoteCertificateNotAvailable) == SslPolicyErrors.RemoteCertificateNotAvailable)
            {
                msg = msg + "\r\n    -The server did not present a certificate.\r\n";
                acceptCertificate = false;
            }
            else
            {
                //The certificate does not match the server name
                if ((sslPolicyErrors &
                     SslPolicyErrors.RemoteCertificateNameMismatch) == SslPolicyErrors.RemoteCertificateNameMismatch)
                {
                    msg = msg + "\r\n    -The certificate name does not match the authenticated name.\r\n";
                    acceptCertificate = false;
                }

                //There is some other problem with the certificate
                if ((sslPolicyErrors &
                     SslPolicyErrors.RemoteCertificateChainErrors) == SslPolicyErrors.RemoteCertificateChainErrors)
                {
                    foreach (X509ChainStatus item in chain.ChainStatus)
                    {
                        if (item.Status != X509ChainStatusFlags.RevocationStatusUnknown &&
                            item.Status != X509ChainStatusFlags.OfflineRevocation)
                            break;

                        if (item.Status != X509ChainStatusFlags.NoError)
                        {
                            msg = msg + "\r\n    -" + item.StatusInformation;
                            acceptCertificate = false;
                        }
                    }
                }
            }

            //If Validation failed, present message box
            if (acceptCertificate == false)
            {
                msg = msg + "\r\nDo you wish to override the security check?";
                
//          if (MessageBox.Show(msg, "Security Alert: Server could not be validated",
//                       MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                acceptCertificate = true;
            }
            Debug.Log(msg);

            return acceptCertificate;
        }
    }
}