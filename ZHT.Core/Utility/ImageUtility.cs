using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace ZHT.Core.Utility
{
    public static class ImageUtility
    {
        public static Image MakeThumbnail(this Image b, int destWidth, int destHeight)
        {
            Image imgSource = b;
            int sW = 0, sH = 0;
            // 按比例缩放           
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }
            Image outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);

            g.Clear(Color.White);
            // 设置画布的描绘质量         
            //g.CompositingQuality = CompositingQuality.HighSpeed;
            ////g.SmoothingMode = SmoothingMode.HighSpeed;
            //g.InterpolationMode = InterpolationMode.Low;
            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Flush();
            g.Dispose();
            imgSource.Dispose();
            //// 以下代码为保存图片时，设置压缩质量     
            //EncoderParameters encoderParams = new EncoderParameters();
            //long[] quality = new long[1];
            //quality[0] = 100;
            //EncoderParameter encoderParam = new EncoderParameter(Encoder.Quality, quality);
            //encoderParams.Param[0] = encoderParam;
            //imgSource.Dispose();
            return outBmp;
        }
    }
}
