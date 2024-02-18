﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives.Contract
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }

}
