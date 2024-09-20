using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using GenericRepository;

internal sealed class PatientReository : Repository<Patient, ApplicationDbContext>, IPatientRepository
{
    public PatientReository(ApplicationDbContext context) : base(context)
    {
    }
}