using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Abstractions.Persistence;
using Products.Domain.Entities;

namespace Products.Application.Features.Products.Commands;

public sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    ILogger<CreateProductCommandHandler> logger) : IRequestHandler<CreateProductCommand, int>
{
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price);
        await productRepository.AddAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Created product {ProductId}", product.Id);
        return product.Id;
    }
}