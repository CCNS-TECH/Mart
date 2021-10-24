using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor.Extensions;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.IBusinessObject;

namespace resm_app.Services
{
    public class ItemService
    {
        private readonly IProduct<Item> _product;

        public ItemService(IProduct<Item> product)
        {
            _product = product;
        }
        public async Task<List<Item>> ItemLists()
        {
            return await _product.GetItemAll();
        }
    }
}