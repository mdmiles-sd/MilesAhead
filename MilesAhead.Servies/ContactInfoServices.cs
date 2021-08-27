using MilesAhead.Data;
using MilesAhead.Models;
using MilesAhead.Models.ContactInfoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Servies
{
    public class ContactInfoServices
    {

        private readonly Guid _userId;

        public ContactInfoServices(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ContactInfoDetailList> GetClientLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var contactInfoQuery =
                    ctx
                        .ContactInfos
                        .Select(
                            e => new ContactInfoDetailList
                            {
                                ContactInfoID = e.ContactInfoID,
                                Address = e.Address,
                                City = e.City,
                                State = e.State,
                                ZipCode = e.ZipCode,
                                PhoneNumber = e.PhoneNumber,
                                Email = e.Email,
                                BestTimeToCall = e.BestTimeToCall

                            });

                return contactInfoQuery.ToArray();
            }
        }

        public bool CreateContactInfo(ContactinfoCreate model)
        {
            var entity =
                new ContactInfo
                {
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    BestTimeToCall = model.BestTimeToCall
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ContactInfos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ContactInfo GetContactInfoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ContactInfos
                        .SingleOrDefault(e => e.ContactInfoID == id);

                return
                    new ContactInfo
                    {
                        ContactInfoID = entity.ContactInfoID,
                        BestTimeToCall = entity.BestTimeToCall
                    };
            }
        }

        public bool UpdateContactInfo(ContactInfoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ContactInfos
                        .SingleOrDefault(e => e.ContactInfoID == model.ContactInfoID);

                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.BestTimeToCall = model.BestTimeToCall;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteContactInfo(int contactInfo)
        {
            using (var ctx = new ApplicationDbContext())

            {
                var entity =
                    ctx
                        .ContactInfos
                        .SingleOrDefault(e => e.ContactInfoID == contactInfo);

                ctx.ContactInfos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

