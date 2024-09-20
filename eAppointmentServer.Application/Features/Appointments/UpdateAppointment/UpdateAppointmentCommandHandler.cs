using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointments.UpdateAppointment
{
    internal sealed class UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateAppointmentCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            DateTime startDate = Convert.ToDateTime(request.StartDate);
            DateTime endDate = Convert.ToDateTime(request.EndDate);

            Appointment? appointment = await appointmentRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

            if (appointment is null)
            {
                return Result<string>.Failure("Appointment not found");
            }

            bool isAppointmentDateAvailable = await appointmentRepository.AnyAsync(p => p.DoctorId == appointment.DoctorId &&
                ((p.StartDate < endDate && p.StartDate >= startDate) || (p.EndDate > startDate && p.EndDate <= endDate) || (p.StartDate >= startDate && p.EndDate <= endDate)
                 || (p.StartDate <= startDate && p.EndDate >= endDate)), cancellationToken

                );

            if(isAppointmentDateAvailable)
            {
                return Result<string>.Failure("This appointment day full.");
            }

            appointment.StartDate = Convert.ToDateTime(request.StartDate);
            appointment.EndDate = Convert.ToDateTime(request.EndDate);

            //appointmentRepository.Update(appointment); bunu zaten yukarda trackingasync de isaretliyor o yuzden tekrar yazmana gerek yok
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Appointment was updated.";
        }
    }
}
