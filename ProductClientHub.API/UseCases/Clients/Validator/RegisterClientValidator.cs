﻿using FluentValidation;
using ProductsClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Clients.Validator;

public class RegisterClientValidator : AbstractValidator<RequestClientJson>
{
    public RegisterClientValidator()
    {
        RuleFor(client => client.Name).NotEmpty().WithMessage("O nome não pode ser vazio.");
        RuleFor(client => client.Email).EmailAddress().WithMessage("O e-mail não é válido.");
    }
}