using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace InSiteXmlClient4Core.Util
{
   public static class LogHelper
    {
        public static void Error<T>(string msg)
        {
           
            ILogger logger = new LoggerFactory() .CreateLogger<T>();
            logger.LogError(msg);
        }
        public static void Information<T>(string msg)
        {

            ILogger logger = new LoggerFactory().CreateLogger<T>();
            logger.LogInformation(msg);
        }
        public static void Warning<T>(string msg)
        {

            ILogger logger = new LoggerFactory().CreateLogger<T>();
            logger.LogWarning(msg);
        }
    }
}
