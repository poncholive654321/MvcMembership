using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace MvcMembership.Services
{
    public class FtpReaderService
    {
        private static FtpReaderService _instance = null;
        private FtpReaderService() {
            
        }
        
        public static FtpReaderService GetInstance() {
            if (_instance == null) _instance = new FtpReaderService();
            return _instance;
        }

        public object GetFiles(string userName) {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://190.2.62.29/");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(userName, GetFtpPassword(userName));

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            return reader.ReadToEnd();
        }

        private string GetFtpPassword(string userName)
        {
            //mocking ftp password store
            switch (userName)
            {
                case "lperdomo":
                    return "base321+";
                default:
                    return "";
            }
        }

    }
}