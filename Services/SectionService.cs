using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.IBusinessObject;

namespace resm_app.Services
{
    public class SectionService
    {
        private readonly IGroupSection<GroupSection> _groupSection;
        private readonly ISection<Section> _section;

        public SectionService(IGroupSection<GroupSection> groupSection,ISection<Section> section)
        {
            _groupSection = groupSection;
            _section = section;
        }
        public async Task<List<GroupSection>> GetGroupSections()
        {
            return await _groupSection.GetGroupSections();
        }
        public async Task<List<Section>> GetSections()
        { 
            return  await _section.GetSections();
        }

        public async Task<List<SectionType>> GetSectionTypes()
        {
            return await _section.GetSectionTypes();
        }
        public async Task<List<Section>> GetSectionByGroupId(long id)
        {
            var sections=await _section.GetSections();
            var sects = sections.Where(p => p.GSectionId == id).ToList();
            return sects;
        }
    }
}