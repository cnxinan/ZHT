using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Framework
{
    public class GetDistanseHelper
    {
        #region 地图经纬度计算距离
        /// <summary>  
        /// 获取两个经纬度之间的距离  
        /// </summary>  
        /// <param name="LonA">经度A</param>  
        /// <param name="LatA">纬度A</param>  
        /// <param name="LonB">经度B</param>  
        /// <param name="LatB">经度B</param>  
        /// <returns>距离（千米）</returns>  
        public static double getDistance(double LonA, double LatA, double LonB, double LatB)
        {
            // 东西经，南北纬处理，只在国内可以不处理(假设都是北半球，南半球只有澳洲具有应用意义)  
            double MLonA = LonA;
            double MLatA = LatA;
            double MLonB = LonB;
            double MLatB = LatB;
            // 地球半径（千米）  
            double R = 6371.004;
            double C = Math.Sin(rad(LatA)) * Math.Sin(rad(LatB)) + Math.Cos(rad(LatA)) * Math.Cos(rad(LatB)) * Math.Cos(rad(MLonA - MLonB));
            double distance = Convert.ToDouble(string.Format("{0:0.0}", (R * Math.Acos(C))).ToString());
            return distance;
        }

        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }
        #endregion
    }
}
