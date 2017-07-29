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

    public struct FlagStatus
    {
        public const int SpamData = -1;// Post spam
        public const int ServerError = 0;//Server lỗi
        public const int Success = 1;//Thao tác thành công
        public const int IputError = 2;//Dữ liệu nhập vào không đúng
        public const int NotAccess = 3;//Không có quyền truy cập (User này vào sửa tin bài của user khác,....)
        public const int DataNotFound = 4;// Dữ liệu không tồn tại
        public const int Duplicate = 5;//Dữ liệu trùng lặp
    }
}