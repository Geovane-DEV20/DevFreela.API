﻿using DevFreela.Application.Commands.InsertProject;
using FluentValidation;

namespace DevFreela.API.Validators
{
    public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
    {

        public InsertProjectValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Não pode vazio").MaximumLength(50).WithMessage("Tamanho máximo é 50.");

            RuleFor(p => p.TotalCost).GreaterThanOrEqualTo(1000).WithMessage("O projeto deve custar pelo menos R$1000,00");
        }
    }
}
