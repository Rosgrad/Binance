using System;
using System.Threading;
using WebSocketSharp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ws = new WebSocket("wss://ws/<symbol>@trade:9443"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    Console.WriteLine("Message received : " + e.Data);
                    if (e.Data == "alreadyConnected")
                    {
                        ws.Send("forceConnect");
                    }
                    if (e.Data == "connexionEstablished")
                    {
                        ws.Send("Hello server");
                    }
                };

                ws.OnOpen += (sender, e) =>
                {
                    Console.WriteLine("Connexion has been established");
                    ws.Send("some message");
                };

                ws.OnClose += (sender, e) =>
                {
                    Console.WriteLine("Connexion has been lost");
                    if (!e.WasClean)
                    {
                        if (!ws.IsAlive)
                        {
                            Thread.Sleep(5000);
                            ws.Connect();
                        }
                    }
                };

                ws.OnError += (sender, e) =>
                {
                    Console.WriteLine("Connexion has led to an error");
                };

                ws.Connect();
                Console.ReadKey(true);
            }
        }
    }
}