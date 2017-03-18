using Emgu.CV;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace VideoControl
{
    class Program
    {
        static void Main(string[] args)
        {
            MotionDetector detector = new MotionDetector();
            detector.Start();
        }
    }
}
