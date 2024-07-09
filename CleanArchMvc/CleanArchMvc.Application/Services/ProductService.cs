using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetProducts()
        {
            var productEntity = await _productRepository.GetProductAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(productEntity);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<CategoryDTO>(productEntity);
        }

        public async Task<CategoryDTO> GetProductCategory(int id)
        {
            var productEntity = await _productRepository.GetProductCategoryAsync(id);

            return _mapper.Map<CategoryDTO>(productEntity);
        }

        public async Task Add(CategoryDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);

            await _productRepository.CreateAsync(productEntity);
        }

        public async Task Update(CategoryDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);

            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _productRepository.GetByIdAsync(id).Result;

            await _productRepository.RemoveAsync(productEntity);

        }
    }
}
