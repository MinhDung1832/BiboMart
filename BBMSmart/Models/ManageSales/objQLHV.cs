using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageSales
{
    public class objQLHV
    {
        public string MaKH { set; get; }
        public string MaCH { set; get; }
        public string PhoneNo { set; get; }
    }
    public class objTienSansms
    {
        public string MaKH { set; get; }
        public string MaCH { set; get; }
        public string MaCHafter { set; get; }
        public string Name { set; get; }
        public string campaign { set; get; }
        public string PhoneNo { set; get; }
        public string HanhDong { set; get; }
        public string SMS_TimeSend { set; get; }
        public string StartDate { set; get; }
        public string TimeHour { set; get; }
        public string TimeSend { set; get; }
        public string SMS_Type { set; get; }
        public string SMS_Amount { set; get; }
        public string SMS_sl { set; get; }
        public string SMS_TieuDe { set; get; }
        public string SMS_NoiDung { set; get; }
        public int status { set; get; }
        public string CreateBy { set; get; }
        public string ModifyBy { set; get; }
        public string StatusSend { set; get; }
        public string Remind { set; get; }
        public string AnalyticsId { set; get; }
    }
}