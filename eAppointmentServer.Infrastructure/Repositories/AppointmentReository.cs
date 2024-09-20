using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using GenericRepository;

namespace eAppointmentServer.Infrastructure.Repositories
{
    internal sealed class AppointmentReository : Repository<Appointment, ApplicationDbContext>, IAppointmentRepository
    {
        public AppointmentReository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
