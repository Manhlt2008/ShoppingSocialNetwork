using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Common
{
    public struct Const
    {
        //UnitName
        public const int GOI = 1;  //gói
        public const int CHIEC = 2;//Chiếc
        public const int BO = 3;//bộ
        public const int LO = 4;//Lọ
        public static string GetUnitName(int unit)
        {
            string sProductType = string.Empty;
            switch (unit)
            {
                case GOI:
                    sProductType = "Gói";
                    break;
                case CHIEC:
                    sProductType = "Chiếc";
                    break;
                case BO:
                    sProductType = "Bộ";
                    break;
                case LO:
                    sProductType = "Lọ";
                    break;             
            }
            return sProductType;
        }
    }
    public enum UnitName
    {
        /// <summary>
        /// Hoạt động
        /// </summary>
        Active = 0,
        /// <summary>
        /// Khóa
        /// </summary>
        Block = 1
    }
}