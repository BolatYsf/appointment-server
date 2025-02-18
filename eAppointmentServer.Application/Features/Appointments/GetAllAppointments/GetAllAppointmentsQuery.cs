﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointments.GetAllAppointments
{
    public sealed record GetAllAppointmentsQuery(Guid DoctorId) : IRequest<Result<List<GetAllAppointmentsQueryResponse>>>;
}
