//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnQLNS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhanVien_PhongBan
    {
        public string IDHopDong { get; set; }
        public int IDPhongBan { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string QuyetDinhSo { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
    
        public virtual HoDongLaoDong HoDongLaoDong { get; set; }
        public virtual PhongBan PhongBan { get; set; }
    }
}
