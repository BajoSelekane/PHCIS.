using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.DB
{

    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options)
    {
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<TimeSlot> Timeslots => Set<TimeSlot>();
        public DbSet<Login> Logins => Set<Login>();
        public DbSet<Register> Registers => Set<Register>();
        public DbSet<ApplicationUser> Users => Set<ApplicationUser>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
           .HasOne(a => a.Patient)
           .WithMany(p => p.Appointments)
           .HasForeignKey(a => a.PatientId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(c => c.EnablePushNotification).HasDefaultValue(true);
            });
            modelBuilder.Entity<Patient>()
                .HasQueryFilter(p => !p.IsDeleted)
                .HasQueryFilter(Patients => Patients.Id == "");

            modelBuilder.Entity<Appointment>()
               .HasQueryFilter(c => !c.IsDeleted)
               .HasQueryFilter(Appointments => Appointments.Id == "");

            modelBuilder.Entity<TimeSlot>()
               .HasQueryFilter(t => !t.IsDeleted)
               .HasQueryFilter(Timeslots => Timeslots.Id == "");

            base.OnModelCreating(modelBuilder);


            modelBuilder.HasDefaultSchema("identity");
        }



    }
}

















//using Application.Abstractions.Data;
//using Domain.Entities;
//using Domain.Entities.User;
//using MediatR;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using SharedLibrary.Shared;

//namespace Infrastructure.DB;

////public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher)
////    : DbContext(options), IApplicationDbContext
//public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//        : DbContext(options), IApplicationDbContext
//{
//    public DbSet<User> Users { get; set; }



//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

//        modelBuilder.HasDefaultSchema(Schemas.Default);
//    }

//    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
//    {
//        // When should you publish domain events?
//        //
//        // 1. BEFORE calling SaveChangesAsync
//        //     - domain events are part of the same transaction
//        //     - immediate consistency
//        // 2. AFTER calling SaveChangesAsync
//        //     - domain events are a separate transaction
//        //     - eventual consistency
//        //     - handlers can fail

//        int result = await base.SaveChangesAsync(cancellationToken);

//        await PublishDomainEventsAsync();

//        return result;
//    }

//    private async Task PublishDomainEventsAsync()
//    {
//        var domainEvents = ChangeTracker
//            .Entries<Entity>()
//            .Select(entry => entry.Entity)
//            .SelectMany(entity =>
//            {
//                List<IDomainEvent> domainEvents = entity.DomainEvents;

//                entity.ClearDomainEvents();

//                return domainEvents;
//            })
//            .ToList();

//        foreach (IDomainEvent domainEvent in domainEvents)
//        {
//            await publisher.Publish(domainEvent);
//        }
//    }
//}
