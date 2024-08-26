using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService(IMapper mapper, IMediator mediator) : IProductService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productsQuery = new GetProductsQuery() ?? throw new ApplicationException($"Entity could not be leaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDto>>(result);

        }

        public async Task<ProductDto> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value) ?? throw new ApplicationException($"Entity could not be leaded.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDto>(result);
        }

        public async Task Add(ProductDto productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);

            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDto productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);

        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value) ?? throw new ApplicationException($"Entity could not be leaded.");

            await _mediator.Send(productRemoveCommand);

        }
    }
}
