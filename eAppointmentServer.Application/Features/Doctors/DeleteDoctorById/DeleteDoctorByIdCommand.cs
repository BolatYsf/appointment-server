using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.DeleteDoctorById
{
    public sealed record DeleteDoctorByIdCommand(Guid id): IRequest<Result<string>>;
}
