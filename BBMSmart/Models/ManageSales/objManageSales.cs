using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageSales
{
    //API APP get analytics 
    public class User
    {
        public string _id { get; set; }
        public int status { get; set; }
        public string phone { get; set; }
    }
    public class RootAppAnalytics
    {
        public string _id { get; set; }
        public int jobStatus { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string cover { get; set; }
        public string content { get; set; }
        public List<User> users { get; set; }
    }
    //en API APP get analytics 

    //API APP Push App
    public class Body
    {
        public string title { get; set; }
        public string description { get; set; }
        public string cover { get; set; }
        public string type { get; set; }
        public string kind { get; set; }
        public string content { get; set; }
        public object specialTime { get; set; }
    }

    public class Notification
    {
        public int status { get; set; }
        public int jobStatus { get; set; }
        public string type { get; set; }
        public string kind { get; set; }
        public int group { get; set; }
        public List<object> @params { get; set; }
        public string _id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string cover { get; set; }
        public string content { get; set; }
        public object specialTime { get; set; }
        public DateTime published { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
    }

    public class Receiver
    {
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string cover { get; set; }
        public string user { get; set; }
    }
    public class RootPushApp
    {
        public Body body { get; set; }
        public Notification notification { get; set; }
        public List<Receiver> receivers { get; set; }
    }

    //end 

    // API send SMS 
    public class Root2
    {
        public string code_number { get; set; }
        public bool code_status { get; set; }
        public string content { get; set; }
    }

    public class SendMessage
    {
        public List<string> to { get; set; }
        public object telcoFilter { get; set; }
        public int ignoreError { get; set; }
        public string from { get; set; }
        public string message { get; set; }
        public string scheduled { get; set; }
        public object requestId { get; set; }
        public int useUnicode { get; set; }
        public object ext { get; set; }
    }

    public class Success
    {
        public string telco { get; set; }
        public int total { get; set; }
        public int countMT { get; set; }
        public List<string> to { get; set; }
        public int msgLength { get; set; }
    }

    public class NotValid
    {
        public string errorCode { get; set; }
        public string telco { get; set; }
        public List<string> msisdns { get; set; }
    }

    public class Root3
    {
        public SendMessage sendMessage { get; set; }
        public int total { get; set; }
        public List<Success> success { get; set; }
        public List<NotValid> notValid { get; set; }
        public string account { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public string referentId { get; set; }
    }

    // End API send SMS
    public class objCustomer
    {
        public string PhoneNo { set; get; }
        public string DivisionCode { set; get; }
        public string CategoryCode { set; get; }
        public string FunctionCode { set; get; }
        public string BrandCode { set; get; }
        public string ItemNo { set; get; }

    }

    public class objHeader
    {
        public string HeaderId { set; get; }
    }
    public class objCoupon
    {
        public string AccountNo { set; get; }
        public string Coupon { set; get; }
        public string PhoneNo { set; get; }
        public string CampaignCode { set; get; }
    }
    public class objManageSales
    {
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string GiaNhap { set; get; }
        public string GiaBan { set; get; }
        public decimal GP { set; get; }
        public decimal L4LSL { set; get; }
        public string L4LDT { set; get; }
        public string L4LGP { set; get; }
        public int XepHang631SKUs { set; get; }
        public decimal DTSKU { set; get; }
    }
    public class WholeSales
    {
        public string Division { set; get; }
        public string Brand { set; get; }
        public string Brand_Code { set; get; }
        public string TenNCC { set; get; }
        public string Function { set; get; }
        public string HHKGTKE { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string HinhAnh { set; get; }
        public string XepHang631 { set; get; }
        public string SoCHCaiAR { set; get; }
        public string SoNgayKinhDoanh { set; get; }
        public string GiaBan { set; get; }
        public string GP { set; get; }
        public string SlBanY1 { set; get; }
        public string SlBanYSlBanYTD { set; get; }
        public string SlBanD30 { set; get; }
        public decimal SlTon { set; get; }
        public decimal Range { set; get; }
        public decimal GiaSi { set; get; }
        public int SoLuongBan { set; get; }
        public decimal ThanhTien { set; get; }
        public string GBLAll { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
    }

    public class Marcom_CouponCode_ERP
    {

        public string CouponCode { set; get; }
        public string MACOUPON { set; get; }
        public string Price { set; get; }
        public string DateKetThuc { set; get; }
        public string status { set; get; }
    }
}