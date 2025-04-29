using FluentValidation;
using ProductsClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Products.Validator;

public class RequestProductValidator : AbstractValidator<RequestProductJson>
{
    public RequestProductValidator()
    {
        RuleFor(product => product.Name).NotEmpty().WithMessage("Nome do produto inválido.");
        RuleFor(product => product.Brand).NotEmpty().WithMessage("Marca do produto inválido.");
        RuleFor(product => product.Price).GreaterThan(0).WithMessage("Preço do produto inválido.");
    }
}