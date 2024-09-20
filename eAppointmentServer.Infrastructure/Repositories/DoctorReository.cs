using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using GenericRepository;

internal sealed class DoctorReository : Repository<Doctor, ApplicationDbContext>, IDoctorRepository
{
    public DoctorReository(ApplicationDbContext context) : base(context)
    {
    }
}