using MilesAhead.Data;
using MilesAhead.Models;
using MilesAhead.Models.BeneficiaryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Servies
{
    public class BeneficiaryServices
    {
        private readonly Guid _userId;

        public BeneficiaryServices(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<BeneficiaryDetailList> GetBeneficiayDetailLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var beneficiaryQuery =
                    ctx
                        .Beneficiaries
                        .Select(
                            e => new BeneficiaryDetailList
                            {
                                BeneficiaryID = e.BeneficiaryID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Relationship = e.Relationship,
                                PhoneNumber = e.PhoneNumber
                            }) ;

                return beneficiaryQuery.ToArray();
            }
        }

        public bool CreateBeneficiary(BeneficiaryCreate model)
        {
            var entity =
                new Beneficiary
                {                    
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Relationship = model.Relationship
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Beneficiaries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public BeneficiaryDetailList GetBeneficiaryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beneficiaries
                        .SingleOrDefault(e => e.BeneficiaryID == id);

                return
                    new BeneficiaryDetailList
                    {
                        BeneficiaryID = entity.BeneficiaryID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Relationship = entity.Relationship,
                        
                    };
            }
        }

        public bool UpdateBeneficiary(BeneficiaryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beneficiaries
                        .SingleOrDefault(e => e.BeneficiaryID == model.BeneficiaryID);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Relationship = model.Relationship;
                entity.PhoneNumber = model.PhoneNumber;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBeneficiary(int beneficiaryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .SingleOrDefault(e => e.BeneficiaryID == beneficiaryID && e.OwnerID == _userId);

                ctx.Clients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

