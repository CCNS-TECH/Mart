using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Companys;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class CompanyRepository:ICompany<Company>
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> InsertCompany(Company company)
        {
            company.Default = "N";
            company.Deleted = "N";
            await _context.Companies.AddAsync(company);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCompany(long id,Company company)
        {
            var cpn = await _context.Companies.FirstOrDefaultAsync(p => p.Id == id);
            cpn.Company_Str = company.Company_Str;
            cpn.Company_En = company.Company_En;
            cpn.Phone1 = company.Phone1;
            cpn.Phone2 = company.Phone2;
            cpn.Email = company.Email;
            cpn.Wifi = company.Wifi;
            cpn.No_Num = company.No_Num;
            cpn.St_Num = company.St_Num;
            cpn.Khan = company.Khan;
            cpn.Province = company.Province;
            cpn.Img = company.Img;
            cpn.Old_Img = company.Old_Img;
            cpn.Updated_By_Id = company.Updated_By_Id;
            cpn.Updated_By_Name = company.Updated_By_Name;
            cpn.Updated_Date=DateTime.Now;
            

            _context.Companies.Update(cpn);
            return  await _context.SaveChangesAsync();
        }

        public async Task<int> SetCompany(long id, Company company)
        {
            var cpn = await _context.Companies.FirstOrDefaultAsync(p => p.Default=="Y" && p.Deleted=="N");
            var cpns = await _context.Companies.FirstOrDefaultAsync(p => p.Id == id && p.Deleted=="N");
            
            cpn.Updated_By_Id = company.Updated_By_Id;
            cpn.Updated_By_Name = company.Updated_By_Name;
            cpn.Updated_Date=DateTime.Now;
            cpn.Default = "N";
            
            _context.Companies.Update(cpn);
            
            cpns.Updated_By_Id = company.Updated_By_Id;
            cpns.Updated_By_Name = company.Updated_By_Name;
            cpns.Updated_Date=DateTime.Now;
            cpns.Default = "Y";
            _context.Companies.Update(cpns);
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCompany(long id,Company company)
        {
            var cpn = await _context.Companies.FirstOrDefaultAsync(p => p.Id == id);
            
            cpn.Deleted_By_Id = company.Updated_By_Id;
            cpn.Deleted_By_Name = company.Updated_By_Name;
            cpn.Deleted_Date=DateTime.Now;
            cpn.Deleted = "Y";

            _context.Companies.Update(cpn);
            return await _context.SaveChangesAsync();
        }

        public async Task<Company> GetCompanyDefault()
        {
            var ctx = await _context.Companies.FirstOrDefaultAsync(p =>p.Default=="Y" && p.Deleted == "N");
            return ctx;
        }

        public async Task<Company> GetCompany(long id)
        {
            var ctx = await _context.Companies.FirstOrDefaultAsync(p =>p.Id==id && p.Deleted == "N");
            ctx.Old_Img = ctx.Img;
            return ctx;
        }

        public async Task<List<Company>> GetListCompany()
        {
            var ctxs = await _context.Companies.Where(p => p.Deleted == "N").ToListAsync();
            return ctxs;
        }
    }
}