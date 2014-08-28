﻿using System;
using Quobject.EngineIoClientDotNet.Client;
using System.IO;
using System.Web.Script.Serialization;

namespace Quobject.EngineIoClientDotNet_Tests.ClientTests
{
    public class Connection
    {
        public static readonly int TIMEOUT = 300000;
        public static readonly int PORT = 80;
        public static readonly int SECURE_PORT = 443;

        protected Socket.Options CreateOptions()
        {

            var config = ConfigBase.Load();


            var options = new Socket.Options();
            options.Port = config.port;
            options.Hostname = "localhost";
            return options;
        }


        protected Socket.Options CreateOptionsSecure()
        {
            var config = ConfigBase.Load();
            var options = new Socket.Options();
            options.Port = config.ssl_port;
            options.Hostname = "localhost";
            options.Secure = true;
            options.IgnoreServerCertificateValidation = true;
            return options;
        }
    }

    public class ConfigBase
    {
        public string version { get; set; }
        public int port { get; set; }
        public int ssl_port { get; set; }

        public static ConfigBase Load()
        {
            var configString = File.ReadAllText("../../../grunt/config.json");
            //Console.WriteLine("configString = {0}", configString);

            var ser = new JavaScriptSerializer();
            var config = ser.Deserialize<ConfigBase>(configString);
            return config;
        }
    }
}