//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCSTOK.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLMUSTERILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMUSTERILER()
        {
            this.TBLSATISLAR = new HashSet<TBLSATISLAR>();
        }
    
        public int MUSTERIID { get; set; }
        [Required(ErrorMessage ="M��teri Ad�n� Bo� Ge�meyiniz")]
        [StringLength(50,ErrorMessage ="50 karakterden fazla girmeyiniz")]
        public string MUSTERIADI { get; set; }
        [Required(ErrorMessage = "M��teri Soy Ad�n� Bo� Ge�meyiniz")]
        [StringLength(50, ErrorMessage = "50 karakterden fazla girmeyiniz")]
        public string MUSTERISOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSATISLAR> TBLSATISLAR { get; set; }
    }
}
