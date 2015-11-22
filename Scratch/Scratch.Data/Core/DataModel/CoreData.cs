using System.Data.Entity;

namespace Scratch.Data.Core.DataModel
{
    internal class CoreData : DbContext
    {
        public virtual DbSet<Setting> Settings { get; set; }

        public virtual DbSet<ContentType> ContentTypes { get; set; }

        public virtual DbSet<Field> Fields { get; set; }

        public CoreData(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Settings

            modelBuilder.Entity<Setting>()
                .HasKey(a => new { a.Section, a.Key });

            modelBuilder.Entity<Setting>()
                .Property(a => a.Section)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true)
                .IsVariableLength();

            modelBuilder.Entity<Setting>()
                .Property(a => a.Key)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true)
                .IsVariableLength();

            modelBuilder.Entity<Setting>()
                .Property(a => a.Value)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true)
                .IsVariableLength();

            #endregion

            #region ContentTypes

            modelBuilder.Entity<ContentType>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<ContentType>()
                .Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true)
                .IsVariableLength();

            modelBuilder.Entity<ContentType>()
                .Property(a => a.ParentId)
                .IsOptional();

            modelBuilder.Entity<ContentType>()
                .HasOptional(a => a.Parent)
                .WithMany(a => a.Children)
                .HasForeignKey(a => a.ParentId);

            modelBuilder.Entity<ContentType>()
                .HasMany(a => a.Fields)
                .WithRequired(a => a.ContentType)
                .HasForeignKey(a => a.ContentTypeId);

            #endregion

            #region Fields

            modelBuilder.Entity<Field>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Field>()
                .Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true)
                .IsVariableLength();

            modelBuilder.Entity<Field>()
                .Property(a => a.Description)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true)
                .IsVariableLength();

            modelBuilder.Entity<Field>()
                .Property(a => a.IsNullable)
                .IsRequired();

            modelBuilder.Entity<Field>()
                .Property(a => a.FieldTypeValue)
                .IsRequired();

            modelBuilder.Entity<Field>()
                .Ignore(a => a.FieldType);

            #endregion
        }
    }
}
