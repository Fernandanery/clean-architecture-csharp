using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<CategoryDTO>> GetProducts();
        Task<CategoryDTO> GetById(int id);
        Task<CategoryDTO> GetProductCategory(int id);
        Task Add(CategoryDTO productDto);
        Task Update(CategoryDTO productDto);
        Task Remove(int? id);
    }
}
