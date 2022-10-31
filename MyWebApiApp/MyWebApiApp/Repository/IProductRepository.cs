using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Repository
{
    public interface IProductRepository
    {
        public Task<List<HangHoaModel>> GetAllProductAsync();
        public Task<HangHoaModel> GetProductAsync(Guid id);
        public Task<Guid> AddProductAsync(HangHoaModel model);
        public Task UpdateProductAsync(Guid id,HangHoaModel model);
        public Task DeleteProductAsync(Guid id);

    }
}
