using BugStore.Domain.Repositories;
using BugStore.Requests.Customers;
using BugStore.Responses.Customers;
using MediatR;

namespace BugStore.Handlers.Customers;

public class DeleteCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
{
    public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetById(request.Id);
        if (customer is null)
            return new DeleteCustomerResponse(false, "Cliente não encontrado");

        customerRepository.Delete(customer);
        await unitOfWork.Commit();

        return new DeleteCustomerResponse(true, "Deletado com sucesso");
    }
}
