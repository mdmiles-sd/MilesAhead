using MilesAhead.Data;
using MilesAhead.Models;
using MilesAhead.Models.BasicHealthQuestionModels;
using MilesAhead.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Servies
{
    public class HealthQuestionsServices
    {
        private readonly Guid _userId;

        public HealthQuestionsServices(Guid userId)
        {
            _userId = userId;
        } 

        public IEnumerable<BasicHealthQuestionList> GetBasicHealthQuestionLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var BasicHealthQuestionQuery =
                    ctx
                        .BasicHealthQuestions                        
                        .Select(
                            e => new BasicHealthQuestionList
                            {
                                BasicHealthQuestionID = e.BasicHealthQuestionID,
                                IsSmoker = e.IsSmoker,                               
                               
                            });

                return BasicHealthQuestionQuery.ToArray();
            }
        }

        public bool CreateBasicHealthQuestion(BasicHealthQuestionCreate model)
        {
            var entity =
                new BasicHealthQuestion
                {
                    
                    IsTakingMedication = model.IsTakingMedication,
                    IsSmoker = model.IsSmoker,
                    IsDiabetic = model.IsDiabetic,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.BasicHealthQuestions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public BasicHealthQuestionDetail GetBasicHealthQuestionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BasicHealthQuestions
                        .SingleOrDefault(e => e.BasicHealthQuestionID == id );

                return
                    new BasicHealthQuestionDetail
                    {
                        BasicHealthQuestionID = entity.BasicHealthQuestionID,
                        IsDiabetic = entity.IsDiabetic,
                        IsSmoker = entity.IsSmoker,
                        IsTakingMedication = entity.IsTakingMedication,
                        
                    };
            }
        }

        public bool UpdateBasicHealthQuestion(BasicHealthQuestionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BasicHealthQuestions
                        .SingleOrDefault(e => e.BasicHealthQuestionID == model.BasicHealthQuestionID );

                entity.IsTakingMedication = model.IsTakingMedication;
                entity.IsSmoker = model.IsSmoker;
                entity.IsDiabetic = model.IsDiabetic;
                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBasicHealthQuestion(int BasicHealthQuestionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BasicHealthQuestions
                        .SingleOrDefault(e => e.BasicHealthQuestionID == BasicHealthQuestionID);

                ctx.BasicHealthQuestions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

