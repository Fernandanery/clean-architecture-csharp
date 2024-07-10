using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        public async Task<Category> Create(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByID(int? id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> Remove(Category category)
        {
            context.Remove(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            context.Update(category);
            await context.SaveChangesAsync();
            return category;
        }
    }
}
