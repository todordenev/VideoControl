using Emgu.CV;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VideoControl
{
    public class MotionDetector:IDisposable
    {
        private CaptureTimer _captureTimer;
        private Stack<string> Images = new Stack<string>();
        private Timer _compareTimer;
        ImageViewer viewer;
        private bool _compareIsRunning;

        public void Dispose()
        {
            if(_compareTimer != null)
            {
                _compareTimer.Dispose();
            }
        }

        public void Start()
        {
            viewer = new ImageViewer();

            _captureTimer = new CaptureTimer();
            _captureTimer.PictureCaptured += new PictureCapturedHandler(PictureCaptured);
            _captureTimer.Start();

            _compareTimer = new Timer(StartCompare,null,0,2000);
            
            viewer.ShowDialog();
        }

        private void StartCompare(object state)
        {
            if (_compareIsRunning)
            {
                return;
            }
            if (!Images.Any())
            {
                return;
            }
            _compareIsRunning = true;
            try
            {
                Compare();
            }catch(Exception e)
            {

            }
            finally
            {
                _compareIsRunning = false;
            }
            

        }

        private void Compare()
        {
            throw new NotImplementedException();
        }

        private void PictureCaptured(string imagePath)
        {
            var oldImage = viewer.Image;
            viewer.Image = new Mat(imagePath,Emgu.CV.CvEnum.LoadImageType.AnyColor);
            if(oldImage != null)
            {
                oldImage.Dispose();
            }       
        }

    }
}
