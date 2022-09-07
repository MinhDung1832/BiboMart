using Newtonsoft.Json;
using ProductAllTool.DataAccess;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace ProductAllTool.Common
{
    public class Constants
    {

        #region URLs PARTIAL VIEWs
        public const string Partial_ManageSales_Index = "~/Views/ManageSales/Partial/__Index.cshtml";
        public const string Partial_ManageSales_Online = "~/Views/ManageSales/Partial/__ManageSalesOnline.cshtml";
        public const string Partial_ManageSales_Inventory = "~/Views/ManageSales/Partial/__Inventory.cshtml";
        public const string Partial_ManageSales_Competeonline = "~/Views/ManageSales/Partial/__Competeonline.cshtml";
        public const string Partial_ManageSales_Competeoffline = "~/Views/ManageSales/Partial/__Competeoffline.cshtml";
        public const string Partial_ManageSales_Customerloyalty = "~/Views/ManageSales/Partial/__Customerloyalty.cshtml";
        #endregion URLs PARTIAL VIEWs

        #region URLs PARTIAL VIEWs
        public const string Partial_ManageUse_Index = "~/Views/ManageUser/Partial/__Index.cshtml";
        public const string Partial_QLNCC_Index = "~/Views/QLNCC/Partial/__Index.cshtml";
        public const string Partial_QLNCC_Product = "~/Views/QLNCC/Partial/__Product.cshtml";
        public const string Partial_QLNCC_RangeReviewNDAccept = "~/Views/QLNCC/Partial/__RangeReviewNDAccept.cshtml";
        public const string Partial_QLNCC_RangeReviewNDHistory = "~/Views/QLNCC/Partial/__RangeReviewNDHistory.cshtml";
        public const string Partial_QLNCC_PurchasingKPIReportND = "~/Views/QLNCC/Partial/__PurchasingKPIReportND.cshtml";

        public const string Partial_QLNCC_RRNDKGUIHQ = "~/Views/QLNCC/Partial/__RRNDKGUIHQ.cshtml";
        public const string Partial_QLNCC_RRNDKGUINEW = "~/Views/QLNCC/Partial/__RRNDKGUINEW.cshtml";
        public const string Partial_QLNCC_RRNDTKE = "~/Views/QLNCC/Partial/__RRNDTKE.cshtml";
        public const string Partial_QLNCC_RRNDXATON = "~/Views/QLNCC/Partial/__RRNDXATON.cshtml";

        public const string Partial_QLNCC_RRNDODMOEM = "~/Views/QLNCC/Partial/__RRNDODMOEM.cshtml";
        public const string Partial_QLNCC_RRNDPurchase = "~/Views/QLNCC/Partial/__RRNDPurchase.cshtml";
        public const string Partial_QLNCC_RRNDReEntry = "~/Views/QLNCC/Partial/__RRNDReEntry.cshtml";
        public const string Partial_QLNCC_RRNDTKEMB = "~/Views/QLNCC/Partial/__RRNDTKEMB.cshtml";


        public const string Partial_QLDS_ThucDayDoanhSoCH = "~/Views/QLDS/Partial/__ThucdaydoanhsoCH.cshtml";
        public const string Partial_QLDS_DatHangBoSung = "~/Views/QLDS/Partial/__Tangtruongnganhang.cshtml";
        public const string Partial_QLDS_TangTruongNganhHang = "~/Views/QLDS/Partial/__Tangtruongnganhang.cshtml";
        public const string Partial_QLDS_Dieuchinhgiaban = "~/Views/QLDS/Partial/__Dieuchinhgiaban.cshtml";
        public const string Partial_QLDS_Xulyhangtonkho = "~/Views/QLDS/Partial/__Xulyhangtonkho.cshtml";
        public const string Partial_QLDS_ReportPriceSurvey = "~/Views/QLDS/Partial/__ReportPriceSurvey.cshtml";
        public const string Partial_QLDS_ReportEffective = "~/Views/QLDS/Partial/__ReportEffective.cshtml";
        public const string Partial_QLDS_DanhGiaCTKM = "~/Views/QLDS/Partial/__DanhgiaCTKM.cshtml";


        public const string Partial_QLDS_QLChiTieuGP = "~/Views/QLDS/Partial/__QLChiTieuGP.cshtml";
        public const string Partial_QLDS_QLChiTieuDS = "~/Views/QLDS/Partial/__QLChiTieuDoanhSo.cshtml";
        public const string Partial_QLDS_QLChiTieuDSOnline = "~/Views/QLDS/Partial/__QLChiTieuDSOnline.cshtml";
        public const string Partial_QLDS_QLChiTieuDSOffline = "~/Views/QLDS/Partial/__QLChiTieuDSOffline.cshtml";
        public const string Partial_QLDS_QLChiTieuDSKenhSi = "~/Views/QLDS/Partial/__QLChiTieuDSKenhSi.cshtml";


        #endregion URLs PARTIAL VIEWs


        #region URLs PARTIAL VIEWs
        public const string Partial_Order_Index = "~/Views/Order/Partial/__Index.cshtml";
        public const string Partial_Order_Detail = "~/Views/Order/Partial/__Detail.cshtml";
        public const string Partial_TradingTerm_Index = "~/Views/TradingTermVendor/Partial/__Index.cshtml";
        public const string Partial_TradingTerm_Duyet_TRADING_TERM = "~/Views/TradingTermVendor/Partial/__DuyetTradingTerm.cshtml";

        #endregion URLs PARTIAL VIEWs

        #region [Date Formats]

        public const string SQLDateFormat = "yyyy-MM-dd";
        public const string SiteDateFormat = "dd/MM/yyyy";
        public const string SiteDateTimeFormat = "dd/MM/yyyy HH:mm:ss";
        public const string TimestampFormat = "yyyyMMddHHmmssfff";
        public static readonly string[] NullDate = { "01/01/0001", "01/01/1753", "31/12/9998", "31/12/9999" };

        #endregion

        public static string Format_Price(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return str.Replace(",", ",");
            }
            else
                return "";
        }
        public static string Price(string Dat, string POQuahan)
        {
            double POQuahans = Convert.ToDouble(POQuahan.ToString());
            if (POQuahans > 0)
            {
                return Dat.ToString();
            }
            else
                return "0";
        }
        public static return_Item EmailSend_Send_BCC(string str_title, string str_content, string BCC, string mailTog)
        {
            return_Item rt = new return_Item();
            String FROM = ConfigurationManager.AppSettings.Get("SG_FROM");
            String FROMNAME = ConfigurationManager.AppSettings.Get("SG_FROMNAME");
            String SG_TokenKey = ConfigurationManager.AppSettings.Get("SG_TokenKey");
            String mailTo_HangHoa_ERP = ConfigurationManager.AppSettings.Get("mailTo_HangHoa_ERP");

            String HOST = "smtp.sendgrid.net";
            int PORT = 587;
            // The subject line of the email
            String SUBJECT = str_title;

            // The body of the email
            String BODY = str_content;

            // Create and build a new MailMessage object
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(BCC));
            //message.Bcc.Add(new MailAddress(BCC));

            //foreach (var address in mailTog.Split(','))
            //{
            //    message.To.Add(new MailAddress(address.Trim(), ""));
            //}

            message.Subject = SUBJECT;
            message.Body = BODY;
            // Comment or delete the next line if you are not using a configuration set
            //message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                // Pass SMTP credentials
                client.Credentials = new NetworkCredential("apikey", SG_TokenKey);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.
                try
                {
                    client.Send(message);
                    LogBuild.CreateLogger(mailTo_HangHoa_ERP + "Mail done", "_sendmail");
                    rt.code_status = true;
                    rt.content = "";
                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(ex.ToString(), "_sendmail");
                    rt.code_status = false;
                    rt.content = JsonConvert.SerializeObject(ex);
                }
                return rt;
            }
        }
        #region Mail
        public class return_Item
        {
            public string code_number { set; get; }
            public bool code_status { set; get; }
            public string content { set; get; }
        }

        public static return_Item EmailSend_Send(string str_title, string str_content)
        {
            return_Item rt = new return_Item();
            String FROM = ConfigurationManager.AppSettings.Get("SG_FROM");
            String FROMNAME = ConfigurationManager.AppSettings.Get("SG_FROMNAME");
            String SG_TokenKey = ConfigurationManager.AppSettings.Get("SG_TokenKey");
            String mailTo_HangHoa_ERP = ConfigurationManager.AppSettings.Get("mailTo_HangHoa_ERP");

            String HOST = "smtp.sendgrid.net";
            int PORT = 587;
            // The subject line of the email
            String SUBJECT = str_title;

            // The body of the email
            String BODY = str_content;

            // Create and build a new MailMessage object
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(mailTo_HangHoa_ERP));
            //  message.Bcc.Add(new MailAddress("dungnvbb@gmail.com,dungnv@bibomart.net"));
            //string StringofEmails = "dungnvbb@gmail.com,dungnv@bibomart.net";
            //foreach (var address in StringofEmails.Split(','))
            //{
            //    message.Bcc.Add(new MailAddress(address.Trim(), ""));
            //}

            message.Subject = SUBJECT;
            message.Body = BODY;
            // Comment or delete the next line if you are not using a configuration set
            //message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                // Pass SMTP credentials
                client.Credentials = new NetworkCredential("apikey", SG_TokenKey);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.
                try
                {
                    client.Send(message);
                    LogBuild.CreateLogger(mailTo_HangHoa_ERP + "Mail done", "_sendmail");
                    rt.code_status = true;
                    rt.content = "";
                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(ex.ToString(), "_sendmail");
                    rt.code_status = false;
                    rt.content = JsonConvert.SerializeObject(ex);
                }
                return rt;
            }
        }
        #endregion
        public class Commond
        {
            public static string FormatMoney_VND(string money)
            {
                if (money.Length > 0)
                {
                    double value = Convert.ToDouble(money.ToString());
                    string str = value.ToString("#,##,##");
                    return str.Replace(",", ",");
                }
                else
                {
                    return "0";
                }
            }
        }

    }
}



