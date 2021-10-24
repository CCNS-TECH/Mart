using resm_app.Models.BusinessObjects.BusinessPartners;
using resm_app.Models.IBusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace resm_app.Models.Repositories
{
    public class BusinessPartnerRepository:IBusinessPartner
    {
        private readonly AppDbContext _dbContext;
        public BusinessPartnerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add_New(BusinessPartner partner)
        {
            await _dbContext.BusinessPartners.AddAsync(partner);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete_BPN(long id)
        {
            var partner = _dbContext.BusinessPartners.FirstOrDefault(p => p.VendorId == id);
            partner.Delete = "Y";

            _dbContext.BusinessPartners.Update(partner);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Edit_BPN(BusinessPartner partner)
        {
            var part = _dbContext.BusinessPartners.FirstOrDefault(p => p.VendorId == partner.VendorId);

            part.Address = partner.Address;
            part.Email = partner.Email;
            part.Gender = partner.Gender;
            part.Phone1 = partner.Phone1;
            part.Phone2 = partner.Phone2;
            part.PriceListId = partner.PriceListId;
            part.VendorName = partner.VendorName;
            part.UpdateById = partner.UpdateById;
            part.UpdateByName = partner.UpdateByName;
            part.UpdateDate = partner.UpdateDate;

            _dbContext.BusinessPartners.Update(part);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BusinessPartner>> GetBusinessPartners()
        {
            try
            {
                var partners = await _dbContext.BusinessPartners.Where(p=>p.Delete=="N").ToListAsync();
                return partners;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
           
        }
    }
}
