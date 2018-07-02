using System;
using System.Web.Configuration;

namespace Wostal.WCF.Restaurant.Config
{
    public class Setting
    {
        public Setting()
        {
            DbAddress = WebConfigurationManager.AppSettings["dbAddress"];
            var portString = WebConfigurationManager.AppSettings["emailPort"];
            EmailHost = WebConfigurationManager.AppSettings["emailHost"];
            EmailUsername = WebConfigurationManager.AppSettings["emailUsername"];
            EmailPassword = WebConfigurationManager.AppSettings["emailPassword"];


            if (string.IsNullOrEmpty(DbAddress) ||
                string.IsNullOrEmpty(portString) ||
                string.IsNullOrEmpty(EmailHost) ||
                string.IsNullOrEmpty(EmailUsername) ||
                string.IsNullOrEmpty(EmailPassword))
                throw new Exception("Nie skonfigurowano projektu!!");
            var portInt = 0;
            if (int.TryParse(portString, out portInt)) EmailPort = portInt;
            else
                throw new Exception("Port w ustawieniach nie jest liczbą!!");
        }

        public string DbAddress { get; }

        public int EmailPort { get; }

        public string EmailHost { get; }

        public string EmailUsername { get; }

        public string EmailPassword { get; }
    }
}