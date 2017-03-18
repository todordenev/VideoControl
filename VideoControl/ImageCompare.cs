using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoControl
{
    public class ImageCompare
    {
        private Mat _image1;
        private Mat _image2;

        public ImageCompare(Mat image1, Mat image2)
        {
            _image1 = image1;
            _image2 = image2;
        }

        public bool AreSimilar()
        {
            return true;
        }

    }
}
