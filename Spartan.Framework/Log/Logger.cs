using System.Reflection;
using log4net;

namespace Spartan.Framework.Log
{
    public class Logger 
    {
        private static readonly ILog _log = null;
        private static readonly object Obj = new object();
        static Logger()
        {
            lock (Obj)
            {
                if (_log != null) return;
                lock (Obj)
                {
                    if (_log == null)
                    {
                        //TODO 无法记录日志
                        _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    }
                }
            }
        }
        public static ILog Log { get { return _log; } }

    }
}
