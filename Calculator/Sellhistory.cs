//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calculator
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sellhistory
    {
        public int Id { get; set; }
        public int stockid { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> Sellprice { get; set; }
        public Nullable<decimal> Sellamount { get; set; }
        public Nullable<int> totalprofit { get; set; }
        public Nullable<decimal> ROI { get; set; }
        public string Note { get; set; }
    }
}
