using BugStore.Domain.Models;
using BugStore.Domain.Repositories;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using MediatR;

namespace BugStore.Handlers.Customers;

public class CreateCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            BirthDate = request.BirthDate
        };

        await customerRepository.Add(customer);
        await unitOfWork.Commit();

        return new CreateCustomerResponse(true, "Criado com sucesso");
    }
}
