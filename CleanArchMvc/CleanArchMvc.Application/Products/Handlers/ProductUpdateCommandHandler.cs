﻿using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler(IProductRepository productRepository) : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            product.Update(
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.Image,
                request.CategoryId);

            return await _productRepository.UpdateAsync(product);

        }
    }
}
