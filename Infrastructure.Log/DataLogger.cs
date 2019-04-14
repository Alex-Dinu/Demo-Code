using Serilog.Context;
using System;

namespace Infrastructure.Log
{
    public interface IDataLogger
    {
        string Id { get; set; }
        void LogInformation(string text, params object[] data);
        void LogError(Exception ex, params object[] data);
        void LogError(Exception ex);
    }
    public class DataLogger : IDataLogger
    {
        #region LogId
        private string _id;

        public string Id
        {
            get => _id ?? (_id = GetId());
            set => _id = value;

        }

        private string GetId() => Guid.NewGuid().ToString();
        #endregion



        private Serilog.ILogger _logger;

        /// <inheritdoc />
        public DataLogger(Serilog.ILogger logger)
        {
            _logger = logger;
        }


        public void LogError(Exception ex, params object[] data)
        {
            int dataLogCount = 0;
            string exceptionDataMessage = string.Empty;

            // Log the details
            foreach (var o in data)
            {
                LogInformation(string.Empty, o.GetType().Name, o);
                dataLogCount++;
            }

            if (dataLogCount > 0)
                exceptionDataMessage = "Please review the above " + dataLogCount + " log/s for related data.";

            // Log the error
            using (LogContext.PushProperty("LogId", Id))



                _logger.Error(ex, exceptionDataMessage);
        }

        public void LogError(Exception ex)
        {
            using (LogContext.PushProperty("LogId", Id))



                _logger.Error(ex, string.Empty);
        }


        public void LogInformation(string text, params object[] data)
        {

            if (data != null)
            {
                foreach (var o in data)
                {
                    LogInformation(text, o.GetType().Name, o);
                }
            }

        }

        public void LogInformation(params object[] data)
        {

            if (data != null)
            {
                foreach (var o in data)
                {
                    LogInformation(string.Empty, o.GetType().Name, o);
                }
            }

        }


        private void LogInformation<T>(string text, string dataType, T data)
        {

            using (LogContext.PushProperty("data", @data, true))
            using (LogContext.PushProperty("dataType", dataType))

            using (LogContext.PushProperty("text", text))

            using (LogContext.PushProperty("LogId", Id))
                _logger.Information(text);

        }

    }

}
