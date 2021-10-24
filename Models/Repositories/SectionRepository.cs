using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Models.Repositories
{
    public class SectionRepository:ISection<Section>,IGroupSection<GroupSection>
    {
        private readonly AppDbContext _context;
        public SectionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> InsertSection(Section section)
        {
            await _context.Sections.AddAsync(section);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateSection(long id, Section section)
        {
            var secs = await _context.Sections.FirstOrDefaultAsync(p => p.Id == id);
            secs.SectionEn = section.SectionEn;
            secs.SectionStr = section.SectionStr;
            secs.GSectionId = section.GSectionId;
            secs.GSectionStr = section.GSectionStr;
            secs.UpdatedById = section.UpdatedById;
            secs.UpdatedByStr = section.UpdatedByStr;
            secs.UpdatedDate = DateTime.Now;
            secs.Price = section.Price;
            secs.TypeId = section.TypeId;

            _context.Sections.Update(secs);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSection(long id, Section section)
        {
            var secs = await _context.Sections.FirstOrDefaultAsync(p => p.Id == id);
            secs.DeletedById = section.DeletedById;
            secs.DeletedByStr = section.DeletedByStr;
            secs.DeletedDate=DateTime.Now;
            secs.Deleted = "Y";

            _context.Sections.Update(secs);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CheckInSection(long id, Section section)
        {
            var sect = await _context.Sections.FirstOrDefaultAsync(p => p.Id == id);
            sect.LineStatus = "B";
            sect.CheckInId = section.CheckInId;

            _context.Sections.Update(sect);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateSectionAfterPaid(Section section)
        {
            try
            {
                var sect = await _context.Sections.FirstOrDefaultAsync(p => p.Id == section.Id);
               sect.BookingId = section.BookingId;
               sect.BookingStatus = section.BookingStatus;
               sect.LineStatus = section.LineStatus;
               sect.CheckInId = section.CheckInId;
               _context.Sections.Update(sect);
               return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<SectionType>> GetSectionTypes()
        {
            return await _context.SectoinTypes.Where(p => p.Status == "Y").ToListAsync();
        }

        public async Task<Section> GetSection(long id)
        {
            var secs = await _context.Sections.FirstOrDefaultAsync(p => p.Id == id);
            var gsect = await _context.GroupSections.FirstOrDefaultAsync(p => p.Id == secs.GSectionId);
            var sectType = await _context.SectoinTypes.FirstOrDefaultAsync(p => p.Id == secs.TypeId);
            secs.GroupSection = gsect;
            secs.SectionType = sectType;
            
            return secs;
        }
        public async Task<List<Section>> GetSections()
        {
            var sections = await _context.Sections.Where(p => p.Deleted == "N").ToListAsync();
            var gsect = await _context.GroupSections.ToListAsync();
            var type = await _context.SectoinTypes.ToListAsync();
            var checkins = await _context.SectionCheckIns.ToListAsync();
            var bookings = await _context.BookingSections.ToListAsync();
            var orders = await _context.Orders.ToListAsync();
            var sects = (from s in sections
                select new Section
                {
                    Id = s.Id,
                    SectionStr = s.SectionStr,
                    SectionEn = s.SectionEn,
                    BookingId = s.BookingId,
                    BookingStatus = s.BookingStatus,
                    LineStatus = s.LineStatus,
                    GSectionId = s.GSectionId,
                    Price = s.Price,
                    GroupSection = (from g in gsect 
                                    where g.Id==s.GSectionId 
                                          select new GroupSection
                                          {
                                           Id   = g.Id,
                                           GSectionEn = g.GSectionEn,
                                           GSectionStr = g.GSectionStr
                                          }).FirstOrDefault(),
                    SectionCheckIn = (from chck in checkins 
                                    where chck.Id==s.CheckInId  
                                          select new SectionCheckIn()
                                          {
                                            Id  = chck.Id,
                                            SectionId = chck.SectionId,
                                            SectionStr = chck.SectionStr,
                                            StartDate = chck.StartDate,
                                            StartTime = chck.StartTime,
                                            EndTime = chck.EndTime,
                                            EndDate = chck.EndDate,
                                            CheckedInById = chck.CheckedInById,
                                            CheckedInByStr = chck.CheckedInByStr,
                                            CheckedInDate = chck.CheckedInDate,
                                            Pax = chck.Pax
                                          }
                            ).FirstOrDefault(),
                    BookingSection = (from b in bookings
                                        where b.SectionId==s.Id 
                                              && b.LineStatus=="O"
                                    select new BookingSection
                                  {
                                      Id = b.Id,
                                      SectionId = b.SectionId,
                                      SectionStr = b.SectionStr,
                                      StartDate = b.StartDate,
                                      StartTime = b.StartTime,
                                      Hour = b.Hour,
                                      Minute = b.Minute,
                                      EndHour = b.EndHour,
                                      EndTime = b.EndTime,
                                      EndMinute = b.EndMinute,
                                      BookedById = b.BookedById,
                                      BookedByName = b.BookedByName,
                                      BookedDate = b.BookedDate,
                                      CancelStatus = b.ConfirmStatus,
                                      LineStatus = b.LineStatus,
                                      Deleted = b.Deleted,
                                      ConfirmStatus = b.ConfirmStatus
                                  }).FirstOrDefault(),
                    SectionType=(from t in type 
                                where t.Id==s.TypeId
                                      select new SectionType
                                      {
                                          Id = t.Id,
                                          Type = t.Type
                                      }).FirstOrDefault(),
                    Order = (from o in orders
                            where o.SectionId == s.Id && o.DocStatus=="I"
                                  select new Order
                                  {
                                      DocEntry = o.DocEntry,
                                      SectionId = o.SectionId,
                                      SectionStr = o.SectionStr,
                                      Duration = o.Duration,
                                      SectionPrice = o.SectionPrice,
                                      SectionAmount = o.SectionAmount
                                  }).FirstOrDefault()
                }).ToList();
            return sects;
        }

        public async Task<int> InsertGroupSection(GroupSection groupSection)
        {
            await _context.GroupSections.AddAsync(groupSection);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateGroupSection(long id, GroupSection groupSection)
        {
            var gs = await _context.GroupSections.FirstOrDefaultAsync(p => p.Id == id);
            gs.GSectionEn = groupSection.GSectionEn;
            gs.GSectionStr = groupSection.GSectionStr;

            _context.GroupSections.Update(gs);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteGroupSection(long id)
        {
            var gs = await _context.GroupSections.FirstOrDefaultAsync(p => p.Id == id);
            gs.Deleted = "Y";

            _context.GroupSections.Update(gs);
            return await _context.SaveChangesAsync();
        }

        public async Task<GroupSection> GetGroupSection(long id)
        {
            return await _context.GroupSections.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<GroupSection>> GetGroupSections()
        {
            return await _context.GroupSections.Where(p => p.Deleted == "N").ToListAsync();
        }

        public async Task<List<Section>> GetSectionByTypeId(long id)
        {
            var sections = await _context.Sections.Where(p => p.TypeId == id && p.LineStatus=="N").ToListAsync();
            return sections;
        }
        public async Task<long> TransferSection(long id, SectionTransferViewModel transfer)
        {
            try
            {
                var checkin = await _context.SectionCheckIns.FirstOrDefaultAsync(p => p.SectionId == id && p.LineStatus=="O");
                var order = await _context.Orders.FirstOrDefaultAsync(p =>
                    p.SectionId == transfer.FromSectionId && p.DocStatus == "O" && p.OrderStatus == "O");
                var section_new = await _context.Sections.FirstOrDefaultAsync(s => s.Id == transfer.ToSectionId);
                var section_old = await _context.Sections.FirstOrDefaultAsync(s => s.Id == transfer.FromSectionId);

                if (section_old.BookingId != 0) {
                    var bookingSection = await _context.BookingSections.FirstOrDefaultAsync(b => b.SectionId == section_old.Id && b.LineStatus == "O");
                    section_new.BookingId = section_old.BookingId;
                    section_new.BookingStatus = section_old.BookingStatus;
                    section_new.BookingSection = section_old.BookingSection;

                    bookingSection.SectionId = section_new.Id;
                    bookingSection.SectionStr = section_new.SectionStr;

                    _context.Sections.Update(section_new);
                    _context.BookingSections.Update(bookingSection);
                    await _context.SaveChangesAsync();
                }
                checkin.TransferByStr = transfer.TransferByStr;
                checkin.TransferById = transfer.TransferById;
                checkin.TransferFromSectionId = checkin.SectionId;
                checkin.TransferFromSectionName = checkin.SectionStr;
                checkin.TransferFromSectionTypeId = checkin.TypeId;
                checkin.TransferFromSectionTypeStr = checkin.TypeStr;
            
                checkin.SectionId = transfer.ToSectionId;
                checkin.SectionStr = transfer.ToSectionStr;
                checkin.TransferToSectionTypeId = transfer.SectionTypeId;
                checkin.TransferToSectionTypeStr = transfer.SectionTypeStr;
                checkin.TransferToSectionId = transfer.ToSectionId;
                checkin.TransferToSectionStr = transfer.ToSectionStr;
            
                checkin.TransferDate = DateTime.Now;
                checkin.TransferTime = DateTime.Now;
                checkin.GSectionId = transfer.ToGroupSectionId;
                checkin.GSectionStr = transfer.ToGroupSectionStr;
                checkin.TypeId = transfer.SectionTypeId;
                checkin.TypeStr = transfer.SectionTypeStr;
                checkin.TransferStatus = "Y";
                checkin.Description += "#" + transfer.Description;

                if (order != null)
                {
                    order.SectionId = transfer.ToSectionId;
                    order.SectionStr = transfer.ToSectionStr;
                    _context.Orders.Update(order);
                }
                _context.SectionCheckIns.Update(checkin);
            
                await _context.SaveChangesAsync();
                return checkin.Id;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        public async Task<int> TransferSectionCheckIn(long id, Section section)
        {
            var sect = await _context.Sections.FirstOrDefaultAsync(p => p.Id == id);
            sect.LineStatus = section.LineStatus;
            sect.UpdatedById = section.UpdatedById;
            sect.UpdatedByStr = section.UpdatedByStr;
            //sect.BookingStatus = section.BookingStatus;
            sect.UpdatedDate=DateTime.Now;
            sect.CheckInId = section.CheckInId;
            
            _context.Sections.Update(sect);
            return await _context.SaveChangesAsync();
        }
    }
}