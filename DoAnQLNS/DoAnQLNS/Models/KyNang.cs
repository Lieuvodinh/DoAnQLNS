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
    
    public partial class KyNang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KyNang()
        {
            this.NhanVien_KyNang = new HashSet<NhanVien_KyNang>();
        }
    
        public int IDKyNang { get; set; }
        public string TenKyNang { get; set; }
        public string MoTa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien_KyNang> NhanVien_KyNang { get; set; }
    }
}
