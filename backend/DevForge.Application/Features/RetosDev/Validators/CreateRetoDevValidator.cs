using FluentValidation;
using DevForge.Application.Features.RetosDev.DTOs;

namespace DevForge.Application.Features.RetosDev.Validators;

public class CreateRetoDevValidator : AbstractValidator<CreateRetoDevRequestDto>
{
    public CreateRetoDevValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("El título del reto no puede estar vacío.")
            .MinimumLength(3).WithMessage("El título debe tener al menos 3 caracteres.")
            .MaximumLength(150).WithMessage("El título no puede superar los 150 caracteres.");

        RuleFor(x => x.Descripcion)
            .NotEmpty().WithMessage("La descripción del reto no puede estar vacía.")
            .MaximumLength(1000).WithMessage("La descripción no puede superar los 1000 caracteres.");
    }
}