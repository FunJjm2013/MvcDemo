using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.Models;

namespace MVCDemo.DAL
{
    public class MVCDemoDbContext :DbContext
    {
        #region 用户
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleRelation> UserRoleRelations { get; set; }
        public DbSet<UserConfig> UserConfigs { get; set; }
        #endregion

        #region 内容
        public DbSet<Article> Articles { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommonModel> CommonModels { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        #endregion

        public MVCDemoDbContext() :base("DefaultConnection")
        {
            Database.CreateIfNotExists();
        }
    }
}
