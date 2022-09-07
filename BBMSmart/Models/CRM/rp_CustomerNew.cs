using Lib.Utils.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.CRM
{
    public class rp_CustomerNew
    {
        public string RESOURCE { set; get; }
        public string ID { set; get; }
        public string FULL_NAME { set; get; }
        public string MOBILE { set; get; }
        public string FACEBOOK_ID { set; get; }
        public string EMAIL { set; get; }
        public string PROVINCE { set; get; }
        public string planDateBirth { set; get; }
        public string DateBirthBaby1 { set; get; }
        public string DateBirthBaby2 { set; get; }
        public string DateBirthBaby3 { set; get; }
        public string DateBirthBaby4 { set; get; }
        public string LabelMilk { set; get; }
        public string LabelDiapers { set; get; }
        public string ONLOFL { set; get; }
        public string FirtBuyDate { set; get; }
        public string isApp { set; get; }
        public string totalSaleAmount { set; get; }
        public string GPKH { set; get; }
        public string Suggestion { set; get; }
        public string Suggestion_Content { set; get; }
        public int isAction { set; get; } = 0;
        public string definedDate { set; get; }
        public string isAppNoti { set; get; }
        public string isEmail { set; get; }
        public string isSMS { set; get; }
        public string isCouponAssign { set; get; }
        public string isCouponUsed { set; get; }
        public string C_Code { set; get; }
        public string C_Value { set; get; }
        public string C_Expired { set; get; }
        public string C_SendDate { set; get; }
        public string C_UsedDate { set; get; }
        public string C_SaleAmount { set; get; }
        public string C_ItemSales { set; get; }



    }

    public class rp_CRM_Lead: rp_CustomerNew
    {
        public string partialDay { set; get; }
        public string isReceived { set; get; }
        public string isUsed { set; get; }
    }

    partial class ComboAction : ComBox
    {
        public string nextLink { set; get; }
    }
}