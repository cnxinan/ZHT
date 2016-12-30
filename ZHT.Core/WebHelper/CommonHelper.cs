using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZHT.Core.WebHelper
{
    public class CommonHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
                return false;

            email = email.Trim();
            var result = Regex.IsMatch(email, "^(?:[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+\\.)*[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!\\.)){0,61}[a-zA-Z0-9]?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\\[(?:(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\.){3}(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\]))$", RegexOptions.IgnoreCase);
            return result;
        }

        /// <summary>
        /// Generate random digit code
        /// </summary>
        /// <param name="length">Length</param>
        /// <returns>Result string</returns>
        public static string GenerateRandomDigitCode(int length)
        {
            var random = new Random();
            string str = string.Empty;
            for (int i = 0; i < length; i++)
                str = String.Concat(str, random.Next(10).ToString());
            return str;
        }

        /// <summary>
        /// Returns an random interger number within a specified rage
        /// </summary>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <returns>Result</returns>
        public static int GenerateRandomInteger(int min = 0, int max = int.MaxValue)
        {
            var randomNumberBuffer = new byte[10];
            new RNGCryptoServiceProvider().GetBytes(randomNumberBuffer);
            return new Random(BitConverter.ToInt32(randomNumberBuffer, 0)).Next(min, max);
        }

        /// <summary>
        /// 微信订单随机号
        /// </summary>
        /// <returns></returns>
        public static string GetWeixinRandom()
        {
            Random r = new Random();
            const string _chars = "0123456789";
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string data = DateTime.Now.Day.ToString();
            if (month.Length == 1) { month = 0 + month; }
            char[] buffer = new char[10];
            for (int i = 0; i < 10; i++)
            {
                buffer[i] = _chars[r.Next(_chars.Length)];
            }
            return year + month + data + new string(buffer);
        }

        /// <summary>
        /// 创建二维码
        /// </summary>
        /// <param name="path">保存路径</param>
        /// <param name="value">二维码内容</param>
        public static void CreateQrCode(string path, string value)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = qrEncoder.Encode(value);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(3, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
            }
        }
        /// <summary>
        /// 将Value生成二维码,并写入流中
        /// </summary>
        /// <param name="value">二维码内容</param>
        /// <param name="stream">药写入的流</param>
        /// <returns></returns>
        public static bool CreateQrCode(string value, MemoryStream stream)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode;
            if (qrEncoder.TryEncode(value, out qrCode))
            {
                GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(3, QuietZoneModules.Two), Brushes.Black, Brushes.White);
                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
