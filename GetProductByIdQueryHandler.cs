using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Abstractions.Persistence;
using Products.Application.DTOs;

namespace Products.Application.Features.Products.Queries;

public sealed class GetProductByIdQueryHandler(
    IProductRepository productRepository,
    ILogger<GetProductByIdQueryHandler> logger)
    : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
        {
            logger.LogWarning("Product {ProductId} was not found", request.Id);
            return null;
        }

        logger.LogInformation("Retrieved product {ProductId}", product.Id);
        return new ProductDto(product.Id, product.Name, product.Price);
    }
}