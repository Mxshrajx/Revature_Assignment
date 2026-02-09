using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<IMessageReader, TwitterMessageReader>();
            services.AddScoped<IMessageWriter, InstagramMessageWriter>();
            services.AddScoped<IMessageWriter, PdfMessageWriter>();
            services.AddScoped<IMyLogger, ConsoleLogger>();
            services.AddScoped<App>();
            var serviceProvider = services.BuildServiceProvider();
            var app = serviceProvider.GetService<App>();
            app.Run();
        }
    }
    public class App
    {
        private readonly IMessageReader _messageReader;
        private readonly IEnumerable<IMessageWriter> _messageWriters;
        public App(IMessageReader reader, IEnumerable<IMessageWriter> writers)
        {
            _messageReader = reader;
            _messageWriters = writers;
        }
        public void Run()
        {
            var message = _messageReader.ReadMessage();

            foreach (var writer in _messageWriters)
            {
                writer.WriteMessage(message);
            }
        }
    }
    public interface IMessageReader
    {
        string ReadMessage();
    }

    public class MessageReader : IMessageReader
    {
        public string ReadMessage() => "Hello, World!";
    }

    public class TwitterMessageReader : IMessageReader
    {
        public string ReadMessage() => "Hello, From Twitter!";
    }
    public interface IMessageWriter
    {
        void WriteMessage(string message);
    }

    public class MessageWriter : IMessageWriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class InstagramMessageWriter : IMessageWriter
    {
        private readonly IMyLogger _logger;

        public InstagramMessageWriter(IMyLogger logger)
        {
            _logger = logger;
        }

        public void WriteMessage(string message)
        {
            _logger.Log();
            Console.WriteLine($"{message} posted to Instagram");
        }
    }

    public class PdfMessageWriter : IMessageWriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"PDF: {message}");
        }
    }
    public interface IMyLogger
    {
        void Log();
    }

    public class ConsoleLogger : IMyLogger
    {
        public void Log()
        {
            Console.WriteLine("Entering ConsoleLogger...");
        }
    }
}
