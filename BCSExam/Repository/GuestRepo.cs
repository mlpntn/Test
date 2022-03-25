using System.Collections.Generic;
using System.Threading.Tasks;
using BCSExam.Interface;
using BCSExam.Model;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace BCSExam.Repository
{
    public class GuestRepo : IGuestRepo
    {
        private readonly employeetestingdbContext _context;

        #region Constructor
        public GuestRepo(employeetestingdbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<IEnumerable<Talktoguest>> GetAll()
        {
            var customer = await _context.Talktoguests.ToListAsync();

            if (customer == null)
                return null;
            return customer;
        }


        public async Task<IEnumerable<dynamic>> GetSpoken()
        {

            var spoken = await (from a in _context.SpokenToGuests
                           join b in _context.Talktoguests on a.ResId equals b.ResId
                           select new
                           {
                               ReservationId = a.ResId,
                               GuestName = b.GuestName,
                               GuestMobile = b.GuestMobile,
                               Arrived = b.Arrived,
                               Depart = b.Depart,
                               Category = b.Category,
                               ParkingAttendeeEmail = a.UserEmail
                           }).ToListAsync();


            if (spoken == null)
                return null;
            return spoken;
        }


        public async Task<IEnumerable<Customer>> Customers (string parkCode, string arriving)
        {

            try
            {

                var res = await _context.Talktoguests.Where(_ => _.ParkCode == parkCode && _.Arrived == arriving)
                                                .ToListAsync();
                Customer customer = new Customer();
                List<Customer> cusResult = new List<Customer>();

                foreach (var item in res)
                {
                    customer.ReservationId = item.ResId;
                    customer.GuestName = item.GuestName;
                    customer.GuestMobile = item.GuestMobile;
                    customer.Arrived = item.Arrived;
                    customer.Depart = item.Depart;
                    customer.Category = item.Category;
                    customer.AreaName = item.AreaName;
                    customer.Nights = item.PriorNights;
                    //customer.PreviousNPS = Convert.ToInt32(item.PrevNps);
                    customer.PreviousNPCComment = item.PrevNpsComment;

                    cusResult.Add(customer);

                }
           
               return cusResult;

            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public async Task<dynamic> Response (SpokenToGuest spoken)
        {

            var res = await (
                                from a in _context.Talktoguests
                                .Where(x => x.ResId == spoken.ResId && x.PmEmail == spoken.UserEmail)
                                select new
                                {
                                    ReservationId = a.ResId,
                                    ParkingEmail = a.PmEmail

                                }).ToListAsync();

            if (res.Count == 0)
                return new
                {
                    Error = "Not Found in the Table"
                };


            _context.SpokenToGuests.Add(spoken);
                await _context.SaveChangesAsync();

            return "Successfully Added";


        }

    }
}
