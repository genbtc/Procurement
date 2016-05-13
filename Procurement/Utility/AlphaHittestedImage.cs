using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Procurement.Utility
{
    public class AlphaHittestedImage : Image
    {
        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            var alpha = GetAlphaColor(hitTestParameters.HitPoint);
            if (alpha == 0)
                return null;

            return base.HitTestCore(hitTestParameters);
        }

        private byte GetAlphaColor(Point hitPoint)
        {
            var image = (BitmapImage)Source;
            int stride = (image.PixelWidth * image.Format.BitsPerPixel + 7) / 8;
            var pixels = new byte[image.PixelHeight * stride];

            image.CopyPixels(pixels, stride, 0);

            int index = (int)hitPoint.Y * stride + 4 * (int)hitPoint.X;

            if (pixels.Length <= index)
                return 0;

            return pixels[index];
        }
    }
}
