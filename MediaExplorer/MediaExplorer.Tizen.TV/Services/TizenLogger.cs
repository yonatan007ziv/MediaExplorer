using System;
using Microsoft.Extensions.Logging;

namespace MediaExplorer.Tizen.TV.Services
{
    internal class TizenLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = formatter(state, exception);
            switch (logLevel)
            {
                default:
                case LogLevel.None:
                case LogLevel.Trace:
                    Xamarin.Forms.Platform.Tizen.Log.Info(message);
                    break;
                case LogLevel.Debug:
                    Xamarin.Forms.Platform.Tizen.Log.Debug(message);
                    break;
                case LogLevel.Information:
                    Xamarin.Forms.Platform.Tizen.Log.Info(message);
                    break;
                case LogLevel.Warning:
                    Xamarin.Forms.Platform.Tizen.Log.Warn(message);
                    break;
                case LogLevel.Error:
                    Xamarin.Forms.Platform.Tizen.Log.Error(message);
                    break;
                case LogLevel.Critical:
                    Xamarin.Forms.Platform.Tizen.Log.Fatal(message);
                    break;
            }
        }
    }
}
