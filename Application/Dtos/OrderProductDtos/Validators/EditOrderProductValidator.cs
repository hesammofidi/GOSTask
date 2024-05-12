using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.OrderProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderProductDtos.Validators
{
    public class EditOrderProductValidator : AbstractValidator<EditOrderProductDto>
    {
        
        public EditOrderProductValidator()
        {
            Include(new OrderProductValidator());
        }
    }
}
