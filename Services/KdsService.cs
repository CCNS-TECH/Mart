using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Kdss;
using resm_app.Models.IBusinessObject;

namespace resm_app.Services
{
    public class KdsService
    {
        private readonly Ikds<Kds> _kds;

        public KdsService(Ikds<Kds> kds)
        {
            _kds = kds;
        }

        public async Task<List<Kds>> GetKdss()
        {
            return await _kds.GetKdss();
        }
    }
}