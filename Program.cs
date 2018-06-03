﻿using System;
using SharpyJson.Scripts.Modules.Settings;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace SharpyJson
{
    internal class Program
    {
        public const string AppVersion = "v0.2.1";
        
        public class ClientService : WebSocketBehavior
        {
            protected override void OnMessage (MessageEventArgs e)
            {
                Console.WriteLine("Received: " + e.Data);
                var msg = e.Data == "PINGPONG"
                    ? "Ok"
                    : "Not ok";

                Send(msg);
            }
        }
        
        public static void Main(string[] args) {
            SettingsManager.get();
            
            Console.WriteLine("SharpyJson " + AppVersion);
            Console.WriteLine("Press any button to start server...");
            Console.ReadKey();

            var wssv = new WebSocketServer ("ws://localhost:9012");
            wssv.AddWebSocketService<ClientService> ("/");
            
            wssv.Start ();
            Console.WriteLine("Server started");
            Console.WriteLine("Press any button to stop server...");
            Console.ReadKey (true);
            Console.WriteLine("Server stopped");
            wssv.Stop ();
        }
    }
}