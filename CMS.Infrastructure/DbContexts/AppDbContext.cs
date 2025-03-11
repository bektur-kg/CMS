using CMS.Domain.Modules.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CMS.Domain.Modules.Appointments;
using CMS.Domain.Modules.Diagnoses;
using CMS.Domain.Modules.DoctorProfiles;
using CMS.Domain.Modules.MedicalCards;
using CMS.Domain.Modules.Medications;
using CMS.Domain.Modules.Reviews;
using CMS.Domain.Modules.Visits;
using CMS.Domain.Modules.Qualifications;
using CMS.Domain.Modules.TimeSlots;

namespace CMS.Infrastructure.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<DoctorProfile> DoctorProfiles => Set<DoctorProfile>();
    public DbSet<MedicalCard> MedicalCards => Set<MedicalCard>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<TimeSlot> TimeSlots => Set<TimeSlot>();
    public DbSet<Visit> Visits => Set<Visit>();
    public DbSet<Diagnosis> Diagnoses => Set<Diagnosis>();
    public DbSet<Medication> Medications => Set<Medication>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Qualification> Qualifications => Set<Qualification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

