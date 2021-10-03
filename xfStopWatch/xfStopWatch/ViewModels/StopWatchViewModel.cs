using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace xfStopWatch.ViewModels
{
    public class StopWatchViewModel : BaseViewModel
    {
        Stopwatch stopwatch = new Stopwatch();

        TimeSpan elapsed;
        public TimeSpan Elapsed
        {
            get { return elapsed; }
            set
            {
                SetProperty(ref elapsed, value);
            }            
        }

        private void start()
        {
            stopwatch.Restart();

            IsRunning = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                ElapsedTime = stopwatch.Elapsed.ToString(@"mm\:ss\.fff");
                return isRunning;
            });
        }

        private void stop()
        {
            stopwatch.Stop();
            IsRunning = false;
        }

        private bool isRunning;
        public bool IsRunning
        {
            get {  return isRunning; }
            set { SetProperty(ref isRunning, value); }
        }

        private string elapsedTime;
        public string ElapsedTime
        {
            get {  return elapsedTime; }
            set {  SetProperty(ref elapsedTime, value);}
        }

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }

        public StopWatchViewModel()
        {
            IsRunning = false;
            StartCommand = new Command(() => start());
            StopCommand = new Command(() => stop());
        }
    }
}
