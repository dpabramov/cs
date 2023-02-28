using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reminder.Storage.Core;


namespace EntityFrameworkCreateDbExample
{
    public class ReminderStorageContext : DbContext
    {
        public DbSet<ReminderItem> ReminderItems { get; set; }

        public ReminderStorageContext(DbContextOptions<ReminderStorageContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReminderItem>(entity =>
            {
                entity.ToTable("Reminder");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ContactId)
                    .IsRequired();

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnType("datetimeoffset(7)");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .IsUnicode(true);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("StatusId")
                    .HasConversion(new EnumToNumberConverter<ReminderItemStatus, int>());
            });
        }
    }
}
