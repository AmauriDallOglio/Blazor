﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Dominio.CQRS.Tenant.Find
{
    public interface IFindTenantHandler
    {

        FindTenantByIdResponse Handle(FindTenantByIdRequest command);

    }
}
