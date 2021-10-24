using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Categories;
using resm_app.Models.BusinessObjects.UoMs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Services
{
    public class UoMService
    {
        private readonly IUoM<UoM> _uom;
        private readonly IGroupUoM<GroupUoM> _groupUoM;
        private readonly IDefineUoM<DefineUoM> _defineUom;

        public UoMService(IUoM<UoM> uom,IGroupUoM<GroupUoM> groupUoM,IDefineUoM<DefineUoM> defineUom)
        {
            _defineUom = defineUom;
            _uom = uom;
            _groupUoM = groupUoM;
        }
        public async Task<List<UoM>> GetUoMList()
        {
            return await _uom.GetUoMAll();
        }
        public async Task<List<GroupUoM>> GetGUoMList()
        {
            return await _groupUoM.GetGroupUoMs();
        }

        public async Task<List<DefineUoM>> GetUoMByGroup(long id)
        {
            var uoms = await _defineUom.GetDefineUoMs();
            var uomlist = uoms.Where(p => p.GUoM_Id == id).ToList();
            return uomlist;
        }
    }
}