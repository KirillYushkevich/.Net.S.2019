using System;
using NLog;
using UrlToXml.Interfaces;

namespace HomeworkDay11.BooksLoger
{
    internal class Nloger : ILoger
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message, Exception exception = null)
        {
            _logger.Debug(exception, message);
        }

        public void Error(string message, Exception exception = null)
        {
            _logger.Error(exception, message);
        }

        public void Fatal(string message, Exception exception = null)
        {
            _logger.Fatal(exception, message);
        }

        public void Info(string message, Exception exception = null)
        {
            _logger.Info(exception, message);
        }

        public void Trace(string message, Exception exception = null)
        {
            _logger.Trace(exception, message);
        }

        public void Warn(string message, Exception exception = null)
        {
            _logger.Warn(exception, message);
        }
    }
}
