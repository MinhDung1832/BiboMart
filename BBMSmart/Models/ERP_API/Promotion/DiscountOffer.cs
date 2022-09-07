using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.Promotion
{
    public class DiscountOffer
    {
        public string No { set; get; }
        public string Description { set; get; }
        public string Price_Group { set; get; }
        public string Validation_Period_ID { set; get; }

        public DiscountOfferLine[] DiscountOfferLine;

        public string Customer_Disc_Group { set; get; }
        public string Coupon_Code { set; get; }
        public string Coupon_Qty_Needed { set; get; }
        public string Amount_to_Trigger { set; get; }
        public string Member_Type { set; get; }
        public string Member_Value { set; get; }

    }
}