using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategories();

            return _mapper.Map<IEnumerable<ProductDTO>>(categoriesEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByID(id);

            return _mapper.Map<ProductDTO>(categoryEntity);
        }

        public async Task Add(ProductDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);

            await _categoryRepository.Create(categoryEntity);
        }

        public async Task Update(ProductDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);

            await _categoryRepository.Update(categoryEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetByID(id).Result;

            await _categoryRepository.Remove(categoryEntity);

        }
    }
}
