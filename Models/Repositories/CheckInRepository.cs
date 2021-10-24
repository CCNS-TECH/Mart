using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class CheckInRepository:ICheckInSection<SectionCheckIn>,IBookingSection<BookingSection>
    {
        private readonly AppDbContext _context;

        public CheckInRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<long> InsertCheckIn(SectionCheckIn checkIn)
        {
            checkIn.Deleted = "N";
            checkIn.CancelStatus = "N";
            checkIn.TransferStatus = "N";
            
            await _context.SectionCheckIns.AddAsync(checkIn);
            await _context.SaveChangesAsync();
           
            return checkIn.Id;
        }
        public async Task<int> UpdateCheckIn(long id, SectionCheckIn checkin)
        {
            var chckin = await _context.SectionCheckIns.FirstOrDefaultAsync(p => p.Id == id);
            chckin.SectionId = checkin.SectionId;
            chckin.SectionStr = checkin.SectionStr;
            chckin.GSectionId = checkin.GSectionId;
            chckin.GSectionStr = checkin.GSectionStr;
            chckin.Floor = chckin.Floor;
            chckin.TypeId = chckin.TypeId;
            chckin.TypeStr = checkin.TypeStr;
            chckin.Pax = checkin.Pax;
            chckin.UpdatedDate = DateTime.Now;
            chckin.UpdatedInById = checkin.UpdatedInById;
            chckin.UpdatedByStr = checkin.CancelByStr;

            _context.SectionCheckIns.Update(chckin);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CancelCheckIn(long id, SectionCheckIn checkin)
        {
            var chckin = await _context.SectionCheckIns.FirstOrDefaultAsync(p => p.Id == id);
            chckin.CancelDate =DateTime.Now;
            chckin.CancelById = chckin.CancelById;
            chckin.CancelByStr = chckin.CancelByStr;
            chckin.CancelStatus = "Y";
            chckin.Description = chckin.Description;
            
            _context.SectionCheckIns.Update(chckin);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateSectionCheckInById(long id)
        {
            try
            {
                var section =
                    await _context.SectionCheckIns.FirstOrDefaultAsync(p => p.SectionId == id && p.LineStatus == "O");
                section.EndTime = DateTime.Now.TimeOfDay;
                section.EndDate = DateTime.Now;
                _context.SectionCheckIns.Update(section);

                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task<SectionCheckIn> GetCheckInSectionById(long id)
        {
            var chckin = await _context.SectionCheckIns.FirstOrDefaultAsync(p => p.Id == id);
            return chckin;
        }

        public async Task<List<SectionCheckIn>> GetCheckInSections()
        {
            var chckins = await _context.SectionCheckIns.Where(p => p.LineStatus=="O" && p.Deleted=="N" ).ToListAsync();
            return chckins;
        }

        public async Task<int> UpdateCheckInAfterPaid(SectionCheckIn sectionCheckIn)
        {
            var sectCheckIn = await _context.SectionCheckIns.FirstOrDefaultAsync(p =>
                p.SectionId == sectionCheckIn.SectionId && p.LineStatus == "O");
            sectCheckIn.LineStatus = "C";
            sectCheckIn.UpdatedDate=DateTime.Now;
            sectCheckIn.UpdatedInById = sectionCheckIn.UpdatedInById;
            sectCheckIn.UpdatedByStr = sectionCheckIn.UpdatedByStr;

            _context.SectionCheckIns.Update(sectCheckIn);
            return await _context.SaveChangesAsync();
        }

        public async Task<long> InsertBooking(BookingSection section)
        {
            await _context.BookingSections.AddAsync(section);
            await _context.SaveChangesAsync();

            return section.Id;
        }

        public async Task<int> UpdateBooking(long id, BookingSection booking)
        {
          var section =  await _context.BookingSections.FirstOrDefaultAsync(p=>p.Id==id);
          
          section.SectionId = booking.SectionId;
          section.SectionStr = booking.SectionStr;
          section.GSectionId = booking.GSectionId;
          section.GSectionStr = booking.GSectionStr;
          section.Pax = booking.Pax;
          section.UpdatedDate=DateTime.Now;
          section.UpdatedById = booking.UpdatedById;
          section.UpdatedByStr = booking.SectionStr;
          section.Description = booking.Description;
          section.CustomerId = booking.CustomerId;
          section.CustomerStr = booking.CustomerStr;
          section.TypeId = booking.TypeId;
          section.TypeStr = booking.TypeStr;
          section.Floor = booking.Floor;
          section.Phone1 = booking.Phone1;
          section.Gender = booking.Gender;
          section.StartDate = booking.StartDate;
          section.StartTime = booking.StartTime;
          section.BookedDate = booking.BookedDate;

          _context.BookingSections.Update(section);
          return await _context.SaveChangesAsync();
        }

        public async Task<int> CancelBooking(long id, BookingSection booking)
        {
            var section =  await _context.BookingSections.FirstOrDefaultAsync(p=>p.SectionId==id && p.LineStatus=="O");
            
            section.CancelById = booking.CancelById;
            section.CancelByStr = booking.CancelByStr;
            section.Description = booking.Description;
            section.CancelTime = booking.CancelTime;
            section.CancelDate = booking.CancelDate;
            section.LineStatus = booking.LineStatus;
            section.ConfirmStatus = "Y";
            section.CancelStatus = booking.CancelStatus;

            _context.BookingSections.Update(section);
            return await _context.SaveChangesAsync();
        }

        public async Task<BookingSection> GetBookingSectionById(long id)
        {
            var section =  await _context.BookingSections.FirstOrDefaultAsync(p=>p.SectionId==id && p.LineStatus=="O");
            return section;
        }
        
        public async Task<List<BookingSection>> GetBookingSections()
        {
            var bookings = await _context.BookingSections
                .Where(p => p.Deleted == "N" && p.LineStatus == "O" && p.ConfirmStatus == "N").ToListAsync();
            var sections = await _context.Sections.ToListAsync();
            var types = await _context.SectoinTypes.ToListAsync();
            var gsections = await _context.GroupSections.ToArrayAsync();
            var bookingsections = (from b in bookings
                select new BookingSection
                {
                    Id = b.Id,
                    SectionId = b.SectionId,
                    SectionStr = b.SectionStr,
                    GSectionId = b.GSectionId,
                    GSectionStr = b.GSectionStr,
                    Pax = b.Pax,
                    Description = b.Description,
                    CustomerId = b.CustomerId,
                    CustomerStr = b.CustomerStr,
                    TypeId = b.TypeId,
                    TypeStr = b.TypeStr,
                    Floor = b.Floor,
                    Phone1 = b.Phone1,
                    Gender = b.Gender,
                    StartDate = b.StartDate,
                    Hour = b.Hour,
                    Minute = b.Minute,
                    EndHour = b.EndHour,
                    EndMinute = b.EndMinute,
                    EndTime = b.EndTime,
                    StartTime = b.StartTime,
                    BookedDate = b.BookedDate,
                    Section = (from s in sections
                            where s.Id==b.SectionId
                                  select new Section
                                  {
                                      Id = s.Id,
                                      SectionEn = s.SectionEn,
                                      SectionStr = s.SectionStr,
                                      GSectionId = s.GSectionId,
                                      GSectionStr = s.GSectionStr,
                                      Price = s.Price,
                                      TypeId = s.TypeId,
                                      GroupSection = (from g in gsections
                                          where g.Id==s.GSectionId
                                                select new GroupSection()
                                                {
                                                   Id = g.Id,
                                                   GSectionEn = g.GSectionEn,
                                                   GSectionStr = g.GSectionStr,
                                                }).FirstOrDefault(),
                                      SectionType = (from t in types
                                              where t.Id==s.TypeId
                                                    select new SectionType()
                                                    {
                                                        Id = t.Id,
                                                        Type = t.Type
                                                    }).FirstOrDefault()
                                      
                                  }).FirstOrDefault()
                }).ToList();
            return bookingsections;
        }
        public async Task<int> ConfirmBooking(long id, BookingSection booking)
        {
            var section =
                await _context.BookingSections.FirstOrDefaultAsync(p => p.SectionId == id && p.LineStatus == "O");
            
            section.ConfirmStatus = "Y";
            section.ConfirmById = booking.ConfirmById;
            section.ConfirmByStr= booking.ConfirmByStr;
            section.ConfirmDate = DateTime.Now;
            section.Description = booking.Description;
            
            _context.BookingSections.Update(section);
            return await _context.SaveChangesAsync();
            
        }
        public async Task<int> CheckSectionBooking(long id, Section section)
        {
            var sect = await _context.Sections.FirstOrDefaultAsync(p => p.Id == id); /// old section

            sect.LineStatus = section.LineStatus;
            sect.UpdatedById = section.UpdatedById;
            sect.UpdatedByStr = section.UpdatedByStr;
            sect.BookingStatus = section.BookingStatus;
            sect.BookingId = section.BookingId;
            sect.CheckInId = section.CheckInId;
            sect.UpdatedDate = DateTime.Now;
            
            _context.Sections.Update(sect);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CheckSectionPrintBill(long id, Section section)
        {
            try
            {
                 var sect = await _context.Sections.FirstOrDefaultAsync(p => p.Id == id);
                    sect.LineStatus = section.LineStatus;
                    sect.UpdatedById = section.UpdatedById;
                    sect.UpdatedByStr = section.UpdatedByStr;
                    sect.UpdatedDate=DateTime.Now;
                    _context.Sections.Update(sect);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
        }
    }
}