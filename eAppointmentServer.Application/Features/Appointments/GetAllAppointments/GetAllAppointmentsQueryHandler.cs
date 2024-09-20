using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointments.GetAllAppointments
{
    internal sealed class GetAllAppointmentsQueryHandler(IAppointmentRepository appointmentRepository) : IRequestHandler<GetAllAppointmentsQuery, Result<List<GetAllAppointmentsQueryResponse>>>
    {
        public async Task<Result<List<GetAllAppointmentsQueryResponse>>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            List<Appointment> appointments = await appointmentRepository.Where(p=>p.DoctorId ==request.DoctorId).Include(p=>p.Patient).ToListAsync(cancellationToken);

            List<GetAllAppointmentsQueryResponse> response = appointments.Select(s=> new GetAllAppointmentsQueryResponse(
                s.Id,
                s.StartDate,
                s.EndDate,
                s.Patient!.FullName,
                s.Patient)).ToList();

            return response;
        }
    }
}
