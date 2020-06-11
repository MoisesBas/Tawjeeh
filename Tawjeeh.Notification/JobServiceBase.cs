
using log4net;
using System;
using System.Timers;

namespace Tawjeeh.Notification
{
    public abstract class JobServiceBase : IJobService
    {
        private readonly System.Timers.Timer _timer;
        protected readonly ILog Logger = LogManager.GetLogger(typeof(JobServiceBase));
        //private int Interval => int.Parse(ConfigurationManager.AppSettings["interval"] ?? (1 * 60 * 1000).ToString());
        //private int Interval = 300000;
        private int Interval = 100000;
        protected JobServiceBase()
        {
            _timer = new Timer(Interval) { AutoReset = true };
            _timer.Elapsed += _timer_Elapsed;
        }
        protected abstract void Execute();
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Stop();
            try
            {
                Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Start();
            }
        }
        public void Start()
        {           
            _timer.Start();
        }
        public void Stop()
        {            
            _timer.Stop();
        }
    }
}
