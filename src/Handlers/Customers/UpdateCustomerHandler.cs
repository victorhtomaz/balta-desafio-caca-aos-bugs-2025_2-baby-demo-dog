using BugStore.Domain.Repositories;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using MediatR;

namespace BugStore.Handlers.Customers;

public class UpdateCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
{
    public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetById(request.Id);
        if (customer is null)
            return new UpdateCustomerResponse(false, "Cliente não encontrado");

        customer.Name = request.Name;
        customer.Email = request.Email;
        customer.Phone = request.Phone;

        customerRepository.Update(customer);
        await unitOfWork.Commit();

        return new UpdateCustomerResponse(true, "Atualizado com sucesso");
    }
}
