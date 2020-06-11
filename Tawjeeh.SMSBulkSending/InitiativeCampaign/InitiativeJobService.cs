using log4net;
using System;
using System.Threading;
using System.Timers;
using Topshelf;

namespace Tawjeeh.SMSBulkSending.InitiativeCampaign
{
    public class InitiativeJobService
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(InitiativeJobService));
        private System.Timers.Timer _syncTimer;
        private static object _lock = new object();
        private IInitiativeJobService _iniJobService;

        public InitiativeJobService(IInitiativeJobService iniJobService)
        {
            _iniJobService = iniJobService;
        }           

        public bool Start()
        {
            _syncTimer = new System.Timers.Timer
            {
                //_syncTimer.Interval = TimeSpan.FromHours(24).TotalMinutes;
                Interval = TimeSpan.FromMinutes(4).TotalMinutes,
                Enabled = true
            };
            _syncTimer.Elapsed += RunJob;
            return true;
        }
        private void RunJob(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Testing Service");

            //if (Monitor.TryEnter(_lock))
            //{
            //    try
            //    {
            //        _iniJobService.Execute();
            //    }
            //    finally
            //    {
            //        Monitor.Exit(_lock);
            //    }
            //}
        }

        public bool Stop()
        {
            _syncTimer.Enabled = false;
            return true;
        }
    }
}
