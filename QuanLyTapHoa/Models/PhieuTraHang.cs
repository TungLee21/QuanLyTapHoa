//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTapHoa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuTraHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuTraHang()
        {
            this.ChiTietPhieuTraHangs = new HashSet<ChiTietPhieuTraHang>();
        }
    
        public string MaPhieuTra { get; set; }
        public double TongSoTienTra { get; set; }
        public short TongSoLuongTra { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuTraHang> ChiTietPhieuTraHangs { get; set; }
    }
}
