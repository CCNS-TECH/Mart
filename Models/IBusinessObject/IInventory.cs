using resm_app.Models.BusinessObjects.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Products;

namespace resm_app.Models.IBusinessObject
{
    public interface IInventory
    {
        Task<long> Save_Purchase(Purchase purchase);
        Task<int> Save_Purchase01(Purchase01 purchase01);

        Task<Purchase> GetPurchaseByCode(long id);

        Task<int> Save_Batch(Batch batch);
        Task<int> Save_Serial(Serial serial);
        Task<Batch> GetBatch(long itemid, string batch);
        Task<Serial> GetSerial(long itemid, string serial);

        Task<long> Save_Issue(GoodsIssue issue);
        Task<int> Save_Issue01(GoodsIssue01 issue01);

        Task<long> Save_Receipt(GoodsReceipt receipt);
        Task<int> Save_Receipt01(GoodsReceipt01 receipt01);

        Task<int> Update_Batch(Batch batch, string type);
        Task<int> Update_Serial(Serial serial, string type);


        Task<List<Item>> GetItems();
    }
}
