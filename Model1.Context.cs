﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class tiket_reservationEntities3 : DbContext
    {
        public tiket_reservationEntities3()
            : base("name=tiket_reservationEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<detil_pesan_tiket> detil_pesan_tiket { get; set; }
        public virtual DbSet<pajak_bandara> pajak_bandara { get; set; }
        public virtual DbSet<pembeli> pembelis { get; set; }
        public virtual DbSet<pembeli_validasi> pembeli_validasi { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tgl_pesan> tgl_pesan { get; set; }
    }
}