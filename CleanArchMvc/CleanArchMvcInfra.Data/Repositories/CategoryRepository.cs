using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categorycontext;
        public CategoryRepository(ApplicationDbContext context)
        {
           _categorycontext = context;
        }

        public async Task<Category> Create(Category category)
        {
            _categorycontext.Add(category);
            await _categorycontext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByID(int? id)
        {
            return await _categorycontext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categorycontext.Categories.ToListAsync();
        }

        public async Task<Category> Remove(Category category)
        {
            _categorycontext.Remove(category);
            await _categorycontext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _categorycontext.Update(category);
            await _categorycontext.SaveChangesAsync();
            return category;
        }
    }
}
