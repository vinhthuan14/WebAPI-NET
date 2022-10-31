using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddProductAsync(HangHoaModel model)
        {
            var newProduct = _mapper.Map<HangHoa>(model);
            _context.HangHoas.Add(newProduct);
            await _context.SaveChangesAsync();

            return newProduct.MaHh;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var deleteProduct = _context.HangHoas!.SingleOrDefault(p => p.MaHh == id);
            if (deleteProduct != null)
            {
                _context.HangHoas.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HangHoaModel>> GetAllProductAsync()
        {
            var products = await _context.HangHoas!.ToListAsync();
            return _mapper.Map<List<HangHoaModel>>(products);
        }

        public async Task<HangHoaModel> GetProductAsync(Guid id)
        {
            var product = await _context.HangHoas!.FindAsync(id);
            return _mapper.Map<HangHoaModel>(product);
        }

        public async Task UpdateProductAsync(Guid id, HangHoaModel model)
        {
            if (id == model.MaHh)
            {
                var updateProduct = _mapper.Map<HangHoa>(model);
                _context.HangHoas!.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
