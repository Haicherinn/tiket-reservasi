//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tiket_reservation
{
    using System;
    using System.Collections.Generic;
    
    public partial class detil_pesan_tiket
    {
        public string prefix { get; set; }
        public int id_pembeli { get; set; }
        public string nm_pembeli { get; set; }
        public decimal harga_tiket { get; set; }
        public decimal total_transfer { get; set; }
        public string pilihan_bank { get; set; }
        public int bandara_berangkat { get; set; }
        public int bandara_tujuan { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual pajak_bandara pajak_bandara { get; set; }
    }
}
