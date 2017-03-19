using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VideoControl.Test
{
    [TestClass]
    public class CompareTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var imagePath1 = "C:\\temp\\VideoControl\\Img_19.03.17_12.13.56.jpg";
            var imagePath2 = "C:\\temp\\VideoControl\\Img_19.03.17_12.16.54.jpg";
            var comparer = new ImageCompare(imagePath1, imagePath2);
            comparer.Compare();
        }
    }
}
