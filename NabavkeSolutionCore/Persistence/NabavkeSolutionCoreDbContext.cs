using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NabavkeSolutionCore.Models.Code_First_DB;


namespace NabavkeSolutionCore.Persistence 
{
    public partial class NabavkeSolutionCoreDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Delatnost> Delatnost { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        public DbSet<Mesto> Mesto { get; set; }
        public DbSet<Nabavka> Nabavke { get; set; }
        public DbSet<NabavkaUpdate> NabavkeUpdate { get; set; }
        public DbSet<OblikOrg> OblikOrg { get; set; }
        public DbSet<OblikSvoj> OblikSvoj { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        //public DbSet<Pracenjes> Pracenjes { get; set; }
        public DbSet<UpdateDBLogs> UpdateDblogs { get; set; }
        public DbSet<VrstaPostupka> VrstaPostupka { get; set; }

        public NabavkeSolutionCoreDbContext(DbContextOptions<NabavkeSolutionCoreDbContext> options)
            : base(options) { }


        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {


        //        modelBuilder.Entity<Delatnost>(entity =>
        //        {
        //            entity.HasKey(e => e.IdDelatnost);

        //            entity.Property(e => e.IdDelatnost).ValueGeneratedNever();
        //        });

        //        modelBuilder.Entity<Kategorija>(entity =>
        //        {
        //            entity.HasKey(e => e.IdKategorija);

        //            entity.Property(e => e.IdKategorija).ValueGeneratedNever();
        //        });

        //        modelBuilder.Entity<Mesto>(entity =>
        //        {
        //            entity.HasKey(e => e.IdMesta);

        //            entity.Property(e => e.IdMesta).ValueGeneratedNever();
        //        });



        //        modelBuilder.Entity<Nabavke>(entity =>
        //        {
        //            entity.HasIndex(e => e.IdDelatnost)
        //                .HasName("IX_IdDelatnost");

        //            entity.HasIndex(e => e.IdKategorija)
        //                .HasName("IX_IdKategorija");

        //            entity.HasIndex(e => e.IdMesto)
        //                .HasName("IX_IdMesto");

        //            entity.HasIndex(e => e.IdOblikOrg)
        //                .HasName("IX_IdOblikOrg");

        //            entity.HasIndex(e => e.IdOblikSvoj)
        //                .HasName("IX_IdOblikSvoj");

        //            entity.HasIndex(e => e.IdOpstina)
        //                .HasName("IX_IdOpstina");

        //            entity.HasIndex(e => e.IdVrstaPostupka)
        //                .HasName("IX_IdVrstaPostupka");

        //            entity.Property(e => e.DatumPoslednjeIzmene).HasColumnType("datetime");

        //            entity.Property(e => e.LastUpdated).HasColumnType("datetime");

        //            entity.Property(e => e.MisljenjeUpraveJn).HasColumnName("MisljenjeUpraveJN");

        //            entity.Property(e => e.ObavestenjeOobustaviPostupkaJavneNabavke).HasColumnName("ObavestenjeOObustaviPostupkaJavneNabavke");

        //            entity.Property(e => e.ObavestenjeOponistenjuPostupka).HasColumnName("ObavestenjeOPonistenjuPostupka");

        //            entity.Property(e => e.ObavestenjeOpriznavanjuKvalifikacije).HasColumnName("ObavestenjeOPriznavanjuKvalifikacije");

        //            entity.Property(e => e.ObavestenjeOpriznavanjuKvalifikacijeOpste).HasColumnName("ObavestenjeOPriznavanjuKvalifikacijeOpste");

        //            entity.Property(e => e.ObavestenjeOpriznavanjuKvalifikacijeUrestriktivnomPostupku).HasColumnName("ObavestenjeOPriznavanjuKvalifikacijeURestriktivnomPostupku");

        //            entity.Property(e => e.ObavestenjeOproduzenjuRoka).HasColumnName("ObavestenjeOProduzenjuRoka");

        //            entity.Property(e => e.ObavestenjeOrezultatuKonkursa).HasColumnName("ObavestenjeORezultatuKonkursa");

        //            entity.Property(e => e.ObavestenjeOsistemuDinamickeNabavke).HasColumnName("ObavestenjeOSistemuDinamickeNabavke");

        //            entity.Property(e => e.ObavestenjeOzakljucenomOkvirnomSporazumu).HasColumnName("ObavestenjeOZakljucenomOkvirnomSporazumu");

        //            entity.Property(e => e.ObavestenjeOzakljucenomUgovoru).HasColumnName("ObavestenjeOZakljucenomUgovoru");

        //            entity.Property(e => e.ObavestenjeOzastitiPrava).HasColumnName("ObavestenjeOZastitiPrava");

        //            entity.Property(e => e.OdlukaKomisijeOzakljucenjuUgovora).HasColumnName("OdlukaKomisijeOZakljucenjuUgovora");

        //            entity.Property(e => e.OdlukaOdodeliOkvirnogSporazuma).HasColumnName("OdlukaODodeliOkvirnogSporazuma");

        //            entity.Property(e => e.OdlukaOdodeliUgovora).HasColumnName("OdlukaODodeliUgovora");

        //            entity.Property(e => e.OdlukaOiskljucenjuKandidata).HasColumnName("OdlukaOIskljucenjuKandidata");

        //            entity.Property(e => e.OdlukaOnastavkuPostupka).HasColumnName("OdlukaONastavkuPostupka");

        //            entity.Property(e => e.OdlukaOobustaviPostupka).HasColumnName("OdlukaOObustaviPostupka");

        //            entity.Property(e => e.OdlukaOpriznavanjuKvalifikacije).HasColumnName("OdlukaOPriznavanjuKvalifikacije");

        //            entity.Property(e => e.Pib).HasColumnName("PIB");

        //            entity.Property(e => e.PodaciOizmeniUgovoraOjavnojNabavci).HasColumnName("PodaciOIzmeniUgovoraOJavnojNabavci");

        //            entity.Property(e => e.PodaciOobjaviIdodeliUgovora).HasColumnName("PodaciOObjaviIDodeliUgovora");

        //            entity.HasOne(d => d.IdDelatnostNavigation)
        //                .WithMany(p => p.Nabavke)
        //                .HasForeignKey(d => d.IdDelatnost)
        //                .HasConstraintName("FK_dbo.Nabavke_dbo.Delatnost_IdDelatnost");

        //            entity.HasOne(d => d.IdKategorijaNavigation)
        //                .WithMany(p => p.Nabavke)
        //                .HasForeignKey(d => d.IdKategorija)
        //                .HasConstraintName("FK_dbo.Nabavke_dbo.Kategorija_IdKategorija");

        //            entity.HasOne(d => d.IdMestoNavigation)
        //                .WithMany(p => p.Nabavke)
        //                .HasForeignKey(d => d.IdMesto)
        //                .HasConstraintName("FK_dbo.Nabavke_dbo.Mesto_IdMesto");

        //            entity.HasOne(d => d.IdOblikOrgNavigation)
        //                .WithMany(p => p.Nabavke)
        //                .HasForeignKey(d => d.IdOblikOrg)
        //                .HasConstraintName("FK_dbo.Nabavke_dbo.OblikOrg_IdOblikOrg");

        //            entity.HasOne(d => d.IdOblikSvojNavigation)
        //                .WithMany(p => p.Nabavke)
        //                .HasForeignKey(d => d.IdOblikSvoj)
        //                .HasConstraintName("FK_dbo.Nabavke_dbo.OblikSvoj_IdOblikSvoj");

        //            entity.HasOne(d => d.IdOpstinaNavigation)
        //                .WithMany(p => p.Nabavke)
        //                .HasForeignKey(d => d.IdOpstina)
        //                .HasConstraintName("FK_dbo.Nabavke_dbo.Opstina_IdOpstina");

        //            entity.HasOne(d => d.IdVrstaPostupkaNavigation)
        //                .WithMany(p => p.Nabavke)
        //                .HasForeignKey(d => d.IdVrstaPostupka)
        //                .HasConstraintName("FK_dbo.Nabavke_dbo.VrstaPostupka_IdVrstaPostupka");
        //        });

        //        modelBuilder.Entity<NabavkeUpdate>(entity =>
        //        {
        //            entity.HasIndex(e => e.IdDelatnost)
        //                .HasName("IX_IdDelatnost");

        //            entity.HasIndex(e => e.IdKategorija)
        //                .HasName("IX_IdKategorija");

        //            entity.HasIndex(e => e.IdMesto)
        //                .HasName("IX_IdMesto");

        //            entity.HasIndex(e => e.IdOblikOrg)
        //                .HasName("IX_IdOblikOrg");

        //            entity.HasIndex(e => e.IdOblikSvoj)
        //                .HasName("IX_IdOblikSvoj");

        //            entity.HasIndex(e => e.IdOpstina)
        //                .HasName("IX_IdOpstina");

        //            entity.HasIndex(e => e.IdVrstaPostupka)
        //                .HasName("IX_IdVrstaPostupka");

        //            entity.Property(e => e.DatumPoslednjeIzmene).HasColumnType("datetime");

        //            entity.Property(e => e.MisljenjeUpraveJn).HasColumnName("MisljenjeUpraveJN");

        //            entity.Property(e => e.ObavestenjeOobustaviPostupkaJavneNabavke).HasColumnName("ObavestenjeOObustaviPostupkaJavneNabavke");

        //            entity.Property(e => e.ObavestenjeOponistenjuPostupka).HasColumnName("ObavestenjeOPonistenjuPostupka");

        //            entity.Property(e => e.ObavestenjeOpriznavanjuKvalifikacije).HasColumnName("ObavestenjeOPriznavanjuKvalifikacije");

        //            entity.Property(e => e.ObavestenjeOpriznavanjuKvalifikacijeOpste).HasColumnName("ObavestenjeOPriznavanjuKvalifikacijeOpste");

        //            entity.Property(e => e.ObavestenjeOpriznavanjuKvalifikacijeUrestriktivnomPostupku).HasColumnName("ObavestenjeOPriznavanjuKvalifikacijeURestriktivnomPostupku");

        //            entity.Property(e => e.ObavestenjeOproduzenjuRoka).HasColumnName("ObavestenjeOProduzenjuRoka");

        //            entity.Property(e => e.ObavestenjeOrezultatuKonkursa).HasColumnName("ObavestenjeORezultatuKonkursa");

        //            entity.Property(e => e.ObavestenjeOsistemuDinamickeNabavke).HasColumnName("ObavestenjeOSistemuDinamickeNabavke");

        //            entity.Property(e => e.ObavestenjeOzakljucenomOkvirnomSporazumu).HasColumnName("ObavestenjeOZakljucenomOkvirnomSporazumu");

        //            entity.Property(e => e.ObavestenjeOzakljucenomUgovoru).HasColumnName("ObavestenjeOZakljucenomUgovoru");

        //            entity.Property(e => e.ObavestenjeOzastitiPrava).HasColumnName("ObavestenjeOZastitiPrava");

        //            entity.Property(e => e.OdlukaKomisijeOzakljucenjuUgovora).HasColumnName("OdlukaKomisijeOZakljucenjuUgovora");

        //            entity.Property(e => e.OdlukaOdodeliOkvirnogSporazuma).HasColumnName("OdlukaODodeliOkvirnogSporazuma");

        //            entity.Property(e => e.OdlukaOdodeliUgovora).HasColumnName("OdlukaODodeliUgovora");

        //            entity.Property(e => e.OdlukaOiskljucenjuKandidata).HasColumnName("OdlukaOIskljucenjuKandidata");

        //            entity.Property(e => e.OdlukaOnastavkuPostupka).HasColumnName("OdlukaONastavkuPostupka");

        //            entity.Property(e => e.OdlukaOobustaviPostupka).HasColumnName("OdlukaOObustaviPostupka");

        //            entity.Property(e => e.OdlukaOpriznavanjuKvalifikacije).HasColumnName("OdlukaOPriznavanjuKvalifikacije");

        //            entity.Property(e => e.Pib).HasColumnName("PIB");

        //            entity.Property(e => e.PodaciOizmeniUgovoraOjavnojNabavci).HasColumnName("PodaciOIzmeniUgovoraOJavnojNabavci");

        //            entity.Property(e => e.PodaciOobjaviIdodeliUgovora).HasColumnName("PodaciOObjaviIDodeliUgovora");

        //            entity.HasOne(d => d.IdDelatnostNavigation)
        //                .WithMany(p => p.NabavkeUpdate)
        //                .HasForeignKey(d => d.IdDelatnost)
        //                .HasConstraintName("FK_dbo.NabavkeUpdate_dbo.Delatnost_IdDelatnost");

        //            entity.HasOne(d => d.IdKategorijaNavigation)
        //                .WithMany(p => p.NabavkeUpdate)
        //                .HasForeignKey(d => d.IdKategorija)
        //                .HasConstraintName("FK_dbo.NabavkeUpdate_dbo.Kategorija_IdKategorija");

        //            entity.HasOne(d => d.IdMestoNavigation)
        //                .WithMany(p => p.NabavkeUpdate)
        //                .HasForeignKey(d => d.IdMesto)
        //                .HasConstraintName("FK_dbo.NabavkeUpdate_dbo.Mesto_IdMesto");

        //            entity.HasOne(d => d.IdOblikOrgNavigation)
        //                .WithMany(p => p.NabavkeUpdate)
        //                .HasForeignKey(d => d.IdOblikOrg)
        //                .HasConstraintName("FK_dbo.NabavkeUpdate_dbo.OblikOrg_IdOblikOrg");

        //            entity.HasOne(d => d.IdOblikSvojNavigation)
        //                .WithMany(p => p.NabavkeUpdate)
        //                .HasForeignKey(d => d.IdOblikSvoj)
        //                .HasConstraintName("FK_dbo.NabavkeUpdate_dbo.OblikSvoj_IdOblikSvoj");

        //            entity.HasOne(d => d.IdOpstinaNavigation)
        //                .WithMany(p => p.NabavkeUpdate)
        //                .HasForeignKey(d => d.IdOpstina)
        //                .HasConstraintName("FK_dbo.NabavkeUpdate_dbo.Opstina_IdOpstina");

        //            entity.HasOne(d => d.IdVrstaPostupkaNavigation)
        //                .WithMany(p => p.NabavkeUpdate)
        //                .HasForeignKey(d => d.IdVrstaPostupka)
        //                .HasConstraintName("FK_dbo.NabavkeUpdate_dbo.VrstaPostupka_IdVrstaPostupka");
        //        });

        //        modelBuilder.Entity<OblikOrg>(entity =>
        //        {
        //            entity.HasKey(e => e.IdOblikOrg);

        //            entity.Property(e => e.IdOblikOrg).ValueGeneratedNever();
        //        });

        //        modelBuilder.Entity<OblikSvoj>(entity =>
        //        {
        //            entity.HasKey(e => e.IdOblikSvoj);

        //            entity.Property(e => e.IdOblikSvoj).ValueGeneratedNever();
        //        });

        //        modelBuilder.Entity<Opstina>(entity =>
        //        {
        //            entity.HasKey(e => e.IdOpstine);

        //            entity.Property(e => e.IdOpstine).ValueGeneratedNever();
        //        });

        //        //modelBuilder.Entity<Pracenjes>(entity =>
        //        //{
        //        //    entity.HasIndex(e => e.NabavkaId)
        //        //        .HasName("IX_NabavkaId");

        //        //    entity.HasIndex(e => e.PratilacId)
        //        //        .HasName("IX_PratilacId");

        //        //    entity.Property(e => e.NabavkaId).HasDefaultValueSql("((0))");

        //        //    entity.Property(e => e.PratilacId).HasMaxLength(128);

        //        //    entity.HasOne(d => d.Nabavka)
        //        //        .WithMany(p => p.Pracenjes)
        //        //        .HasForeignKey(d => d.NabavkaId)
        //        //        .HasConstraintName("FK_dbo.Pracenjes_dbo.Nabavke_NabavkaId");

        //        //    entity.HasOne(d => d.Pratilac)
        //        //        .WithMany(p => p.Pracenjes)
        //        //        .HasForeignKey(d => d.PratilacId)
        //        //        .HasConstraintName("FK_dbo.Pracenjes_dbo.AspNetUsers_PratilacId");
        //        //});

        //        modelBuilder.Entity<UpdateDblogs>(entity =>
        //        {
        //            entity.ToTable("UpdateDBLogs");

        //            entity.Property(e => e.End).HasColumnType("datetime");

        //            entity.Property(e => e.Start).HasColumnType("datetime");
        //        });

        //        modelBuilder.Entity<VrstaPostupka>(entity =>
        //        {
        //            entity.HasKey(e => e.IdVrstaPostupka);

        //            entity.Property(e => e.IdVrstaPostupka).ValueGeneratedNever();
        //        });
        //    }
    }
}
