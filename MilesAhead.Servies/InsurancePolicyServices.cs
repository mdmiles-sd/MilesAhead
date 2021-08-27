using MilesAhead.Data;
using MilesAhead.Models;
using MilesAhead.Models.InsurancePolicyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Servies
{
    public class InsurancePolicyServices
    {
        private readonly Guid _userId;

        public InsurancePolicyServices(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<InsurancePolicyDetailList> GetClientLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var InsurancePolicyQuery =
                    ctx
                        .InsurancePolicies                        
                        .Select(
                            e => new InsurancePolicyDetailList
                            {
                                CoverageAmount = e.CoverageAmount,
                                TypeOfPolicy = e.TypeOfPolicy,
                            });

                return InsurancePolicyQuery.ToArray();
            }
        }

        public bool CreateInsurancePolicy(InsurancePolicyCreate model)
        {
            var entity =
                new InsurancePolicy  
                {
                    TypeOfPolicy = model.TypeOfPolicy,
                    CoverageAmount = model.CoverageAmount,                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.InsurancePolicies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public InsurancePolicyDetailList GetClientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .InsurancePolicies
                        .SingleOrDefault(e => e.InsurancePolicyID == id );

                return
                    new InsurancePolicyDetailList
                    {
                        InsurancePolicyID = entity.InsurancePolicyID,
                        CoverageAmount = entity.CoverageAmount,
                        TypeOfPolicy = entity.TypeOfPolicy,                        
                    };
            }
        }

        public bool UpdateInsurancePolicy(InsurancePolicyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .InsurancePolicies
                        .SingleOrDefault(e => e.InsurancePolicyID == model.InsurancePolicyID );

                entity.InsurancePolicyID = model.InsurancePolicyID;
                entity.CoverageAmount = model.CoverageAmount;
                
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInsurancePolicy(int InsurancePolicyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .InsurancePolicies
                        .SingleOrDefault(e => e.InsurancePolicyID == InsurancePolicyID );

                ctx.InsurancePolicies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

