using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.ViewModels;

namespace resm_app.Models.IBusinessObject
{
    public interface ISection<TEntity>
    {
        Task<int> InsertSection(Section section);
        Task<int> UpdateSection(long id, Section section);
        Task<int> DeleteSection(long id, Section section);
        Task<int> CheckInSection(long id, Section section);
        Task<int> UpdateSectionAfterPaid(Section section);

        Task<List<SectionType>> GetSectionTypes();

        Task<Section> GetSection(long id);
        Task<List<Section>> GetSections();
        Task<List<Section>> GetSectionByTypeId(long id);
        Task<long> TransferSection(long id, SectionTransferViewModel tranfer);
        Task<int> TransferSectionCheckIn(long id, Section section);
    }
    public interface IGroupSection<TEntity>
    {
        Task<int> InsertGroupSection(GroupSection groupSection);
        Task<int> UpdateGroupSection(long id, GroupSection groupSection);
        Task<int> DeleteGroupSection(long id);

        Task<GroupSection> GetGroupSection(long id);
        Task<List<GroupSection>> GetGroupSections();
    }

    public interface IBookingSection<TEntity>
    {
        Task<long> InsertBooking(BookingSection section);
        Task<int> UpdateBooking(long id,BookingSection booking);
        Task<int> CancelBooking(long id,BookingSection booking);

        Task<TEntity> GetBookingSectionById(long id);
        Task<List<TEntity>> GetBookingSections();
        Task<int> ConfirmBooking(long id, BookingSection booking);
        Task<int> CheckSectionBooking(long id, Section section);

    }
    public interface ICheckInSection<TEntity>
    {
        Task<long> InsertCheckIn(SectionCheckIn checkIn);
        Task<int> UpdateCheckIn(long id,SectionCheckIn checkin);
        Task<int> CancelCheckIn(long id,SectionCheckIn checkin);
        Task<int> CheckSectionPrintBill(long id, Section section);
        Task<int> UpdateSectionCheckInById(long id);

        Task<TEntity> GetCheckInSectionById(long id);
        Task<List<TEntity>> GetCheckInSections();
        Task<int> UpdateCheckInAfterPaid(SectionCheckIn sectionCheckIn);
    }
}