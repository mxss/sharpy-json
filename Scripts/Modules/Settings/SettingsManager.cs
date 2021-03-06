﻿using System.Collections.Generic;
using System.Configuration;

namespace SharpyJson.Scripts.Modules.Settings
{
    public class SettingsManager
    {
        private static SettingsManager instance;

        public static SettingsManager get() {
            instance = instance ?? new SettingsManager();

            return instance;
        }

        public string ConfigAbsolutePath = null;
        protected string Environment;
        
        private readonly int microserviceId;
        private readonly string host;
        private readonly int port;
        
        public readonly Dictionary<string, string> DbConfig;

        public int GetMicroserviceId() {
            return microserviceId;
        }
        
        public string GetHostName() {
            return host;
        }
        
        public int GetPort() {
            return port;
        }

        private SettingsManager() {
            DbConfig = new Dictionary<string, string> {
                {"host", ConfigurationManager.AppSettings["db_host"]},
                {"login", ConfigurationManager.AppSettings["db_login"]},
                {"pass", ConfigurationManager.AppSettings["db_pass"]},
                {"db", ConfigurationManager.AppSettings["db_name"]}
            };

            microserviceId = System.Convert.ToInt32(ConfigurationManager.AppSettings["microservice_id"]);
            
            host = ConfigurationManager.AppSettings["host_name"];
            port = System.Convert.ToInt32(ConfigurationManager.AppSettings["host_port"]);
        }
    }
}