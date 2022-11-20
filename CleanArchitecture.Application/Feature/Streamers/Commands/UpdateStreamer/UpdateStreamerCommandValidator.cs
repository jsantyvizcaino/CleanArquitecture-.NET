﻿using FluentValidation;

namespace CleanArchitecture.Application.Feature.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator:AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator() 
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no permite nulos");
            RuleFor(p => p.Url)
                .NotNull().WithMessage("{Url} no permite nulos");
        }
    }
}
