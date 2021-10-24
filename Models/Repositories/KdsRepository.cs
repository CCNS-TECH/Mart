using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Kdss;
using resm_app.Models.BusinessObjects.Taxs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class KdsRepository:Ikds<Kds>
    {
        private readonly AppDbContext _context;

        public KdsRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> InsertKds(Kds kds)
        {
            await _context.Kdss.AddAsync(kds);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateKds(long id, Kds kds)
        {
            var kd = await _context.Kdss.FirstOrDefaultAsync(p => p.Id == id);
            kd.GKdsStr = kds.GKdsStr;

            _context.Kdss.Update(kd);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteKds(long id)
        {
            var kds = await _context.Kdss.FirstOrDefaultAsync(p => p.Id == id);
            kds.Deleted = "Y";
            _context.Kdss.Update(kds);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Kds>> GetKdss()
        {
            return await _context.Kdss.Where(p => p.Deleted == "N").ToListAsync();
        }

        public async Task<Kds> GetKds(long id)
        {  
            return  await _context.Kdss.FirstOrDefaultAsync(p => p.Id == id && p.Deleted=="N");
        }
    }
}