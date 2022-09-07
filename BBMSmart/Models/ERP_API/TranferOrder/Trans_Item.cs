using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.TranferOrder
{
    public class Trans_Item
    {
        public string Transfer_from_Code { set; get; }
        public string Transfer_to_Code { set; get; }
        public List<TransLine> TransferLines { set; get; }
    }
}