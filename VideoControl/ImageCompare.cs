using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoControl
{
    public class ImageCompare
    {
        private string _imagePath1;
        private string _imagePath2;

        public ImageCompare(string imagePath1, string imagePath2)
        {
            _imagePath1 = imagePath1;
            _imagePath2 = imagePath2;
        }

        public bool Compare()
        {
            Log.Info("Compare:");
            Log.Info(_imagePath1);
            Log.Info(_imagePath2);
            Log.Info("_____________________________");
            try
            {
                using (var image1 = new Mat(_imagePath1, LoadImageType.AnyColor))
                {
                    using (var image2 = new Mat(_imagePath2, LoadImageType.AnyColor))
                    {
                        Compare(image1, image2);
                    }
                }
            }
            catch(Exception e)
            {
                Log.Error(e);
            }

            
            return true;
        }

        private void Compare(Mat image1, Mat image2)
        {
            using (var difImage = new Mat())
            {
                CvInvoke.AbsDiff(image1, image2, difImage);

                var viewer = new ImageViewer();
                viewer.Image = difImage;
               // viewer.ShowDialog();
            }
        }
    }
}
