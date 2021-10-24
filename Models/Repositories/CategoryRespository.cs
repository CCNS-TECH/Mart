using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Categories;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class CategoryRespository:ICategory<Category>,ISubCategory<SubCategoryL1>,ISubcategoryL2<SubCategoryL2>
    {
        private readonly AppDbContext _context;

        public CategoryRespository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            var cates = await _context.Categories.Where(p=>p.Status=="Y" && p.Deleted=="N").ToListAsync();
            return cates;
        }
        public async Task<int> InsertCate(Category category)
        {
            await _context.Categories.AddAsync(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCate(long id, Category category)
        {
            var cate = await _context.Categories.FirstOrDefaultAsync(p => p.CateId == id);
            cate.Cate_En = category.Cate_En;
            cate.Cate_Str = category.Cate_Str;
            cate.Updated_Date=DateTime.Now;
            cate.Updated_By_Id = category.Updated_By_Id;
            cate.Updated_By_Name = category.Updated_By_Name;

            _context.Categories.Update(cate);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCate(long id,Category category)
        {
            var cate = await _context.Categories.FirstOrDefaultAsync(p => p.CateId == id);
            cate.Deleted = "Y";
            cate.Status = "N";
            cate.Deleted_Date=DateTime.Now;
            cate.Deleted_By_Id = category.Deleted_By_Id;
            cate.Deleted_By_Name = category.Deleted_By_Name;

            _context.Categories.Update(cate);
            return await _context.SaveChangesAsync();
        }

        public async Task<Category> GetCategory(long id)
        {
            var cate = await _context.Categories.FirstOrDefaultAsync(p => p.CateId == id && p.Status=="Y");
            return cate;
        }
        public async Task<List<Category>> GetCateList()
        {
            var cates = await _context.Categories.Where(p=>p.Status=="Y" && p.Deleted=="N").ToListAsync();
            return cates;
        }
        public async Task<List<SubCategoryL1>> GetSubCateL1ByCate(long id)
        {
            return await _context.SubCategoryL1s.Where(p => p.Cate_Id == id && p.Deleted=="N").ToListAsync();
        }

        public async Task<int> InsertSubCateL1(SubCategoryL1 subCategoryL1)
        {
            await _context.SubCategoryL1s.AddAsync(subCategoryL1);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateSubCateL1(long id, SubCategoryL1 subCategoryL1)
        {
            var subcate = await _context.SubCategoryL1s.FirstOrDefaultAsync(p => p.SubCateL1_Id == id && p.Status=="Y");
            subcate.SubCateL1_En = subCategoryL1.SubCateL1_En;
            subcate.SubCateL1_Str = subCategoryL1.SubCateL1_Str;
            subcate.Cate_Id = subCategoryL1.Cate_Id;
            subcate.Cate_Str = subCategoryL1.Cate_Str;
            subcate.ColorL1 = subcate.ColorL1;
            subcate.Updated_Date=DateTime.Now;
            subcate.Updated_By_Id = subCategoryL1.Updated_By_Id;
            subcate.Updated_By_Name = subCategoryL1.Updated_By_Name;

            _context.SubCategoryL1s.Update(subcate);
            return await _context.SaveChangesAsync();

        }
        public async Task<int> DeleteSubCateL1(long id, SubCategoryL1 subCategoryL1)
        {
            var subcate = await _context.SubCategoryL1s.FirstOrDefaultAsync(p => p.SubCateL1_Id == id && p.Status=="Y");
            subcate.Deleted_Date=DateTime.Now;
            subcate.Deleted_By_Id = subCategoryL1.Deleted_By_Id;
            subcate.Deleted_By_Name = subCategoryL1.Deleted_By_Name;
            subcate.Deleted = "Y";
            subcate.Status = "N";

            _context.SubCategoryL1s.Update(subcate);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<SubCategoryL1>> GetSubCategoryByCategory(long id)
        {
            var subcates = await _context.SubCategoryL1s.Where(p => p.Cate_Id == id && p.Deleted=="N").ToListAsync();
            return subcates;
        }

        public async Task<SubCategoryL1> GetSubCateL1(long id)
        {
            var cates = await _context.Categories.Where(p=>p.Status=="Y" && p.Deleted=="N").ToListAsync();
            var subcate = await _context.SubCategoryL1s.FirstOrDefaultAsync(p => p.SubCateL1_Id == id && p.Status=="Y");
            subcate.Category = cates.FirstOrDefault(p => p.CateId == subcate.Cate_Id);
            return subcate;
        }

        public async Task<List<SubCategoryL1>> GetSubL1All()
        {
            var cates = await _context.Categories.Where(p=>p.Status=="Y" && p.Deleted=="N").ToListAsync();
            var subcates = await _context.SubCategoryL1s.Where(p => p.Status=="Y").ToListAsync();
            var subs = (from s in subcates
                        select new SubCategoryL1()
                        {
                            Cate_Id=s.Cate_Id,
                            Cate_Str=s.Cate_Str,
                            SubCateL1_Id = s.SubCateL1_Id,
                            SubCateL1_En = s.SubCateL1_En,
                            SubCateL1_Str = s.SubCateL1_Str,
                            Status = s.Status,
                            Deleted = s.Deleted,
                            Category = (from c in cates
                                    where c.CateId == s.Cate_Id
                                    select new Category()
                                    {
                                        Cate_En = c.Cate_En,
                                        Cate_Str = c.Cate_Str
                                    }).FirstOrDefault()
                        }).ToList();
            return subs;
        }

        public async Task<int> InsertSubCateL2(SubCategoryL2 subCategoryL2)
        {
            if (subCategoryL2.SubCateL2_Id != 0)
            {
                await UpdateSubCateL2(subCategoryL2.SubCateL2_Id, subCategoryL2);
            }
            else { 
                await _context.SubCategoryL2s.AddAsync(subCategoryL2);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateSubCateL2(long id, SubCategoryL2 subCategoryL2)
        {
            var subcate = await _context.SubCategoryL2s.FirstOrDefaultAsync(p => p.SubCateL2_Id == id && p.Status=="Y");
            subcate.SubCateL2_En = subCategoryL2.SubCateL2_En;
            subcate.SubCateL2_Str = subCategoryL2.SubCateL2_Str;
            subcate.SubCateL1_Id = subCategoryL2.SubCateL1_Id;
            subcate.SubCateL1_Str = subCategoryL2.SubCateL1_Str;
            subcate.Updated_Date=DateTime.Now;
            subcate.Updated_By_Id = subCategoryL2.Updated_By_Id;
            subcate.Updated_By_Name = subCategoryL2.Updated_By_Name;

            _context.SubCategoryL2s.Update(subcate);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSubCateL2(long id, SubCategoryL2 subCategoryL2)
        {
            var subcate = await _context.SubCategoryL2s.FirstOrDefaultAsync(p => p.SubCateL2_Id == id && p.Status=="Y");
            subcate.Deleted_Date=DateTime.Now;
            subcate.Deleted_By_Id = subCategoryL2.Deleted_By_Id;
            subcate.Deleted_By_Name = subCategoryL2.Deleted_By_Name;
            subcate.Deleted = "Y";
            subcate.Status = "N";

            _context.SubCategoryL2s.Update(subcate);
            return await _context.SaveChangesAsync();
        }

        public async Task<SubCategoryL2> GetSubCateL2(long id)
        {
            var cates = await _context.Categories.Where(p=>p.Status=="Y" && p.Deleted=="N").ToListAsync();
            var subcates = await _context.SubCategoryL1s.Where(p => p.Status=="Y").ToListAsync();
            var subcateL2 = await _context.SubCategoryL2s.FirstOrDefaultAsync(p =>p.SubCateL2_Id==id && p.Status=="Y");

            subcateL2.SubCategoryL1 = (from cs in subcates
                where cs.SubCateL1_Id == subcateL2.SubCateL1_Id
                select new SubCategoryL1()
                {
                    SubCateL1_Id = cs.SubCateL1_Id,
                    SubCateL1_En = cs.SubCateL1_En,
                    SubCateL1_Str = cs.SubCateL1_Str,
                    Status = cs.Status,
                    Deleted = cs.Deleted,
                    Category = (from c in cates
                        where c.CateId == cs.Cate_Id
                        select new Category()
                        {
                            Cate_En = c.Cate_En,
                            Cate_Str = c.Cate_Str
                        }).FirstOrDefault()
                }).FirstOrDefault();
            return subcateL2;
        }

        public async Task<List<SubCategoryL2>> GetSubL2All()
        {
            var cates = await _context.Categories.Where(p=>p.Status=="Y" && p.Deleted=="N").ToListAsync();
            var subcates = await _context.SubCategoryL1s.Where(p => p.Status=="Y").ToListAsync();
            var subcateL2s = await _context.SubCategoryL2s.Where(p => p.Status=="Y").ToListAsync();
            var subs = (from sL2 in subcateL2s
                select new SubCategoryL2()
                {
                    SubCateL2_Id = sL2.SubCateL2_Id,
                    SubCateL2_En = sL2.SubCateL2_En,
                    SubCateL2_Str = sL2.SubCateL2_Str,
                    Status = sL2.Status,
                    Deleted = sL2.Deleted,
                    SubCategoryL1 = (from cs in subcates
                        where cs.SubCateL1_Id == sL2.SubCateL1_Id
                        select new SubCategoryL1()
                        {
                        SubCateL1_Id = cs.SubCateL1_Id,
                        SubCateL1_En = cs.SubCateL1_En,
                        SubCateL1_Str = cs.SubCateL1_Str,
                        Status = cs.Status,
                        Deleted = cs.Deleted,
                        Category = (from c in cates
                            where c.CateId == cs.Cate_Id
                            select new Category()
                            {
                                Cate_En = c.Cate_En,
                                Cate_Str = c.Cate_Str
                            }).FirstOrDefault()
                        }).FirstOrDefault()
                }).ToList();
            return subs;
        }
    }
}