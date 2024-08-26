using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler(IProductRepository productRepository) : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            {
                var result = await _productRepository.RemoveAsync(product);
                return result;
            }
        }
    }
}
