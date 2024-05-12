using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.OrderDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderDtos.Validators
{
    public class AddOrderValidator : AbstractValidator<AddOrderDto>
    {
        
        public AddOrderValidator()
        {
            Include(new OrderValidator());
        }
    }
}
