﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Dominio.Commands.Tenant.Create
{
    public class CreateTenantRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
