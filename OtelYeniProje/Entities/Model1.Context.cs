﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OtelYeniProje.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbOtelEntities2 : DbContext
    {
        public DbOtelEntities2()
            : base("name=DbOtelEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ilceler> ilcelers { get; set; }
        public virtual DbSet<iller> illers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TblBirim> TblBirims { get; set; }
        public virtual DbSet<TblDepartman> TblDepartmen { get; set; }
        public virtual DbSet<TblDurum> TblDurums { get; set; }
        public virtual DbSet<TblEkibimiz> TblEkibimizs { get; set; }
        public virtual DbSet<TblGorev> TblGorevs { get; set; }
        public virtual DbSet<TblHakkimda> TblHakkimdas { get; set; }
        public virtual DbSet<TblIletisim> TblIletisims { get; set; }
        public virtual DbSet<TblKasa> TblKasas { get; set; }
        public virtual DbSet<TblKur> TblKurs { get; set; }
        public virtual DbSet<TblMailBirakanlar> TblMailBirakanlars { get; set; }
        public virtual DbSet<TblMesaj> TblMesajs { get; set; }
        public virtual DbSet<TblMesaj2> TblMesaj2 { get; set; }
        public virtual DbSet<TblMisafir> TblMisafirs { get; set; }
        public virtual DbSet<TblOda> TblOdas { get; set; }
        public virtual DbSet<TblPersonel> TblPersonels { get; set; }
        public virtual DbSet<TblRezervasyon> TblRezervasyons { get; set; }
        public virtual DbSet<TblTelefon> TblTelefons { get; set; }
        public virtual DbSet<TblUlke> TblUlkes { get; set; }
        public virtual DbSet<TblUrun> TblUruns { get; set; }
        public virtual DbSet<TblUrunGrup> TblUrunGrups { get; set; }
        public virtual DbSet<TblUrunHareket> TblUrunHarekets { get; set; }
        public virtual DbSet<TblYeniKayit> TblYeniKayits { get; set; }
    }
}