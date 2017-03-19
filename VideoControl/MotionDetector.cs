using Emgu.CV;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VideoControl
{
    public class MotionDetector : IDisposable
    {
        private CaptureTimer _captureTimer;
        private Queue<string> Images = new Queue<string>();
        private Timer _compareTimer;
        ImageViewer viewer;
        private bool _compareIsRunning;
        private object _compareLockObject = new object();


        public void Dispose()
        {
            if (_compareTimer != null)
            {
                _compareTimer.Dispose();
            }
        }

        public void Start()
        {

            _captureTimer = new CaptureTimer();
            _captureTimer.PictureCaptured += new PictureCapturedHandler(PictureCaptured);
            _captureTimer.Start();

            _compareTimer = new Timer(StartCompare, null, Constants.TakePictureInterval, Constants.TakePictureInterval);
            
        }

        private void StartCompare(object state)
        {
            if (_compareIsRunning)
            {
                return;
            }
            lock (_compareLockObject)
            {

                if (Images.Count()<2)
                {
                    return;
                }
                _compareIsRunning = true;
                try
                {
                    Compare();
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
                finally
                {
                    _compareIsRunning = false;
                }
            }
        }

        private void Compare()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            var imagePath1 = Images.Dequeue();
            var imagePath2 = Images.Peek();
            var comparer = new ImageCompare(imagePath1, imagePath2);
            comparer.Compare();
            stopWatch.Stop();
            var elapsedTime= stopWatch.Elapsed;
            Log.Info(string.Format("Compare duration:{0}", elapsedTime.ToString("mm\\:ss\\.ffff")));
        }

        private void PictureCaptured(string imagePath)
        {
            Images.Enqueue(imagePath);            
        }
    }
}
