//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using System.Data;
//using Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using System.Data.Entity.Infrastructure;

//namespace DAL
//{
//    public class EFrameContenxt : DbContext
//    {
//        public EFrameContenxt(string Connec)
//            : base(Connec)
//        {
//            this.Configuration.ProxyCreationEnabled = false;
//        }

//        public DbSet<WeChat_VoteInfoEntity> WeChat_VoteInfo { get; set; }
//        public DbSet<WeChat_VoteOptionEntity> WeChat_VoteOption { get; set; }
//        public DbSet<WeChat_VoteRecordEntity> WeChat_VoteRecord { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

//            modelBuilder.Entity<WeChat_VoteInfoEntity>().HasKey(s => s.VoteInfoID).ToTable("WeChat_VoteInfo");
//            modelBuilder.Entity<WeChat_VoteOptionEntity>().HasKey(s => s.OptionID).ToTable("WeChat_VoteOption");
//            modelBuilder.Entity<WeChat_VoteRecordEntity>().HasKey(s => s.RecordId).ToTable("WeChat_VoteRecord");
//        }

//    }
//}
