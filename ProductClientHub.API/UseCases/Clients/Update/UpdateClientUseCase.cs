using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.Validator;
using ProductClientHub.Exceptions.ExceptionsBase;
using ProductsClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Clients.Update;

public class UpdateClientUseCase
{
    public void Execute(Guid clientId, RequestClientJson request)
    {
        Validate(request);

        var dbContext = new ProductClientHubDbContext();
        
        var entity = dbContext.Clients.FirstOrDefault(client => client.Id == clientId);

        if (entity == null)
        {
            throw new NotFoundException("Cliente não encontrado.");
        }
        
        entity.Name = request.Name;
        entity.Email = request.Email;
        
        dbContext.Clients.Update(entity);
        dbContext.SaveChanges();
    }

    private void Validate(RequestClientJson request)
    {
        var validator = new RegisterClientValidator();
        
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}