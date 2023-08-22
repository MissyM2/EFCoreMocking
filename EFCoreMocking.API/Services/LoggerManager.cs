using System;
using EFCoreMocking.API.Contracts;
using NLog;

namespace EFCoreMocking.API.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Info(message);
        public void LogWarn(string message) => logger.Warn(message);
    }
}

