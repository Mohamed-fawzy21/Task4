using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Abstractions.Persistence;
using Products.Application.DTOs;

namespace Products.Application.Features.Products.Queries;

public sealed class GetProductsQueryHandler(
    IProductRepository productRepository,
    ILogger<GetProductsQueryHandler> logger)
    : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllAsync(cancellationToken);
        var productDtos = products.Select(product => new ProductDto(product.Id, product.Name, product.Price)).ToList();
        logger.LogInformation("Retrieved {ProductCount} products", productDtos.Count);
        return productDtos;
    }
}
