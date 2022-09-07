using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.Po
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class RootMemberContact
    {
        public string keyField { get; set; }
        public string account_NoField { get; set; }
        public string contact_NoField { get; set; }
        public int contact_TypeField { get; set; }
        public bool contact_TypeFieldSpecified { get; set; }
        public string nameField { get; set; }
        public object ma_chiet_khauField { get; set; }
        public object nhómField { get; set; }
        public string addressField { get; set; }
        public string address_2Field { get; set; }
        public object post_CodeField { get; set; }
        public object cityField { get; set; }
        public object house_NoField { get; set; }
        public string e_MailField { get; set; }
        public object districtField { get; set; }
        public object wardField { get; set; }
        public object streetField { get; set; }
        public int receive_Informaiton_ViaField { get; set; }
        public bool receive_Informaiton_ViaFieldSpecified { get; set; }
        public object bank_Card_NoField { get; set; }
        public string club_CodeField { get; set; }
        public string scheme_CodeField { get; set; }
        public string phone_NoField { get; set; }
        public object mobile_Phone_NoField { get; set; }
        public bool blockedField { get; set; }
        public bool blockedFieldSpecified { get; set; }
        public bool main_ContactField { get; set; }
        public bool main_ContactFieldSpecified { get; set; }
        public int genderField { get; set; }
        public bool genderFieldSpecified { get; set; }
        public DateTime date_of_BirthField { get; set; }
        public bool date_of_BirthFieldSpecified { get; set; }
        public int marital_StatusField { get; set; }
        public bool marital_StatusFieldSpecified { get; set; }
        public object territory_CodeField { get; set; }
        public object iD_CardField { get; set; }
        public string membership_Card_NoField { get; set; }
        public int occupationField { get; set; }
        public bool occupationFieldSpecified { get; set; }
        public object customer_TypeField { get; set; }
        public object customer_SubTypeField { get; set; }
        public object created_From_StoreField { get; set; }
        public object number_of_Family_MembersField { get; set; }
        public object number_of_Children_U18Field { get; set; }
        public DateTime child_1_YearField { get; set; }
        public bool child_1_YearFieldSpecified { get; set; }
        public int child_1_GenderField { get; set; }
        public bool child_1_GenderFieldSpecified { get; set; }
        public DateTime child_2_YearField { get; set; }
        public bool child_2_YearFieldSpecified { get; set; }
        public int child_2_GenderField { get; set; }
        public bool child_2_GenderFieldSpecified { get; set; }
        public DateTime child_3_YearField { get; set; }
        public bool child_3_YearFieldSpecified { get; set; }
        public int child_3_GenderField { get; set; }
        public bool child_3_GenderFieldSpecified { get; set; }
        public DateTime child_4_YearField { get; set; }
        public bool child_4_YearFieldSpecified { get; set; }
        public int child_4_GenderField { get; set; }
        public bool child_4_GenderFieldSpecified { get; set; }
        public DateTime created_DateField { get; set; }
        public bool created_DateFieldSpecified { get; set; }
        public string created_byField { get; set; }
        public object reason_BlockedField { get; set; }
        public DateTime date_BlockedField { get; set; }
        public bool date_BlockedFieldSpecified { get; set; }
        public object blocked_byField { get; set; }
    }



    public class itemBST
    {
        public string ThuongHieu { set; get; }
        public string DaiTuoi { set; get; }
    }

    public class ObjMemberContact
    {
        public string MemberCard { get; set; }
        public string AccountNo { get; set; }
        public string PhoneNo { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

    }
    public class Obj_HistoryCoins
    {
        public string AccountNo { get; set; }
        public string PhoneNo { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

    }
    public class Obj_CustomersChange
    {
        public string AccountNo { get; set; }
        public string PhoneNo { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string DateBirth { get; set; }
        public string MemberCard { get; set; }
        public string GioiTinh { get; set; }
        public string DateBirth_News { get; set; }

    }

    public class ObjPushSales
    {
        public string SourceHangMua { get; set; }
        public string SourceHangTang { get; set; }
        public string PushSalesId { get; set; }
        public string MemberCard { get; set; }
        public string PhoneNo { get; set; }
        public string FullName { get; set; }

    }
    public class ObjPushSalesLine
    {
        public string LineID { get; set; }
        public string PushSaleID { get; set; }
        public string Type { get; set; }
        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public string GBL { get; set; }
        public string SLTon { get; set; }
        public string SoLuong { get; set; }
        public string StoreNo { get; set; }
        public string FunctionCode { get; set; }
        public string BrandCode { get; set; }

    }

    public class PushSalesOrder
    {
        public string PushSaleID { get; set; }
        public string Status { get; set; }
        public string PhoneNo { get; set; }
        public string MemberCard { get; set; }
        public string CreateBy { get; set; }
        public string AccountNo { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public string GBL { get; set; }
        public string SoLuong { get; set; }
        public string StoreNo { get; set; }
    }

    public class ItemPushSales
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string GBL { get; set; }
        public string StoreNo { get; set; }
        public string SlTon { get; set; }
        public string HinhAnh { get; set; }
        public string link { get; set; }
        public string MDSNotKM { get; set; }
        public string GiaNhap { get; set; }
        public string KM { get; set; }
        public string PushSaleNotKM { get; set; }
        public string TDH { get; set; }
        public string Bonus { get; set; }
    }

    public class objStore
    {
        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }
}