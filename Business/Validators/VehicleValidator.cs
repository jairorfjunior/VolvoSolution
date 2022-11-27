using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(c => c.VehicleDescription)
                .NotEmpty().WithMessage("Por favor informe a descrição do veículo.")
                .NotNull().WithMessage("Por favor informe a descrição do veículoe.");

          

            RuleFor(c => c.VehicleYearManufacture)
                .NotEmpty().WithMessage("Favor informar a data de fabricação.")
                .NotNull().WithMessage("Favor informar a data de fabricação.");


        }
    }
}
