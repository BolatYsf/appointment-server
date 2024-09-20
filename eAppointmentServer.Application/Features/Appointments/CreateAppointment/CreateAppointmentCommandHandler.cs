using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointments.CreateAppointment
{
    internal sealed class CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork, IPatientRepository patientRepository) : IRequestHandler<CreateAppointmentCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {

            DateTime startDate = Convert.ToDateTime(request.StartDate);
            DateTime endDate = Convert.ToDateTime(request.EndDate);
            Patient patient = new();

            if(request.PatientId is null) {

                patient.IdentityNumber=request.IdentityNumber;
                patient.FirstName=request.FirstName;
                patient.LastName=request.LastName;
                patient.FullAddress=request.FullAddress;


            }
            await patientRepository.AddAsync(patient, cancellationToken);

            bool isAppointmentDateAvailable = await appointmentRepository.AnyAsync(p => p.DoctorId == request.DoctorId &&
               ((p.StartDate < endDate && p.StartDate >= startDate) || (p.EndDate > startDate && p.EndDate <= endDate) || (p.StartDate >= startDate && p.EndDate <= endDate)
                || (p.StartDate <= startDate && p.EndDate >= endDate)), cancellationToken

               );

            if (isAppointmentDateAvailable)
            {
                return Result<string>.Failure("This appointment day full.");
            }



            Appointment appointment = new()
            {
                DoctorId = request.DoctorId,
                PatientId = request.PatientId ?? patient.Id,
                StartDate = Convert.ToDateTime(request.StartDate),
                EndDate = Convert.ToDateTime(request.EndDate),
                IsCompleted = false
            };

            await appointmentRepository.AddAsync(appointment, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Appointment was created";

        }


    }
}
