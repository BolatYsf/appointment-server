﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAppointmentServer.Domain.Entities
{
    public sealed class Patient
    {
        public Patient()
        {
            // her bir instance urettiginde otomatik guid id uretecek
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty ;
        public string FullName => string.Join("-", FirstName, LastName);
        public string IdentityNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
