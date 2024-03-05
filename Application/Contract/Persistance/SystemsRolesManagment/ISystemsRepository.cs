﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Persistance.SystemsRolesManagment
{
    public interface ISystemsRepository : IGenericSqlRepository<Systems, int>
    {
        Task<bool> ExistTitle(string title);
        Task<bool> ExistTitleInEdit(string title,int Id);
    }
}
