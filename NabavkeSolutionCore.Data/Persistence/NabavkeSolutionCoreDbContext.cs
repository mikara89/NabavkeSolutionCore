using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NabavkeSolutionCore.Data.Models.Code_First_DB;


namespace NabavkeSolutionCore.Data.Persistence 
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
        public DbSet<UpdateDBLogs> UpdateDblogs { get; set; }
        public DbSet<VrstaPostupka> VrstaPostupka { get; set; }

        public NabavkeSolutionCoreDbContext(DbContextOptions<NabavkeSolutionCoreDbContext> options)
            : base(options) { }


     
    }
}
