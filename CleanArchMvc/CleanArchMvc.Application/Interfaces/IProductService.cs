using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetById(int? id);
        Task Add(ProductDto productDto);
        Task Update(ProductDto productDto);
        Task Remove(int? id);
    }
}
