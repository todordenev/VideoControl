using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoControl
{
    public static class Log
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void Info(string value)
        {
            logger.Info(value);
        }

        internal static void Error(Exception e)
        {
            logger.Error(e);
        }
    }
}
