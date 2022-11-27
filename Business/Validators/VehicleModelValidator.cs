using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators
{
    public class VehicleModelValidator : AbstractValidator<VehicleModel>
    {
        public VehicleModelValidator()
        {
            RuleFor(c => c.VehicleModelDescription)
                .NotEmpty().WithMessage("Por favor informe a descrição do modelo.")
                .NotNull().WithMessage("Por favor informe a descrição do modelo.");

             
        }
    }
}
