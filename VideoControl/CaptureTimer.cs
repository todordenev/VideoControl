using Emgu.CV;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace VideoControl
{

    public delegate void PictureCapturedHandler(string imagePath);
    public class CaptureTimer : IDisposable
    {
        private Capture _capture;
        private Timer _timer;
        private string _fileName;

        public CaptureTimer()
        {
            _capture = new Capture(1);
        }

        public event PictureCapturedHandler PictureCaptured;
        public void Start()
        {
            _timer = new Timer(TakeImage, null, 0, 2000);
            _fileName = Path.GetTempFileName();
        }

        private void TakeImage(object state)
        {
            using (var image = _capture.QueryFrame())
            {
                try
                {

                    var imagePath = GetImagePath();
                    image.Save(imagePath);
                    Log.Info("Capured:" + imagePath);
                    PictureCaptured(imagePath);
                }
                catch(Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        private string GetImagePath()
        {
            var imagePathBuilder = new StringBuilder("C:\\temp\\VideoControl\\");
            imagePathBuilder.Append("Img_");
            imagePathBuilder.Append(DateTime.Now.ToString("dd.MM.yy_HH.mm.ss"));
            imagePathBuilder.Append(".jpg");
            var imagePath = imagePathBuilder.ToString();
            return imagePath;
        }

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }
            if (_capture != null)
            {
                _capture.Stop();
                _capture.Dispose();
            }
        }
    }
}
