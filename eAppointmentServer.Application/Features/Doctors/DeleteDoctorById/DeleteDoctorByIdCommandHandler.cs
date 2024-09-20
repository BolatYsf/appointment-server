using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.DeleteDoctorById
{
    internal sealed class DeleteDoctorByIdCommandHandler(IDoctorRepository repository , IUnitOfWork unitOfWork) : IRequestHandler<DeleteDoctorByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
        {
            Doctor? doctor = await repository.GetByExpressionAsync(p=>p.Id ==request.id , cancellationToken);
            if(doctor is null)
            {
                return Result<string>.Failure("Doctor not found,");
            }
            repository.Delete(doctor);
            await unitOfWork.SaveChangesAsync();

            return "Doctor delete is succesful.";
        }
    }
}
