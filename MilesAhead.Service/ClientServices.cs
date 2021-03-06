using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilesAhead.Models;

namespace MilesAhead.Services
{
   public class ClientServices
    {
        private readonly Guid _userId;
        
        public ClientServices(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ClientList> GetClientLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var noteQuery =
                    ctx
                        .Notes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e => new ClientList
                            {
                                NoteId = e.NoteId,
                                Title = e.Title,
                                IsStarred = e.IsStarred,
                                CreatedUtc = e.CreatedUtc,
                                CategoryId = e.CategoryId,
                                CategoryName = e.Category.Name
                            });

                return clientQuery.ToArray();
            }
        }

        public bool CreateClient(CreateClient model)
        {
            var entity =
                new Note
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CategoryId = model.CategoryId,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .SingleOrDefault(e => e.NoteId == id && e.OwnerId == _userId);

                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        Title = entity.Title,
                        Content = entity.Content,
                        IsStarred = entity.IsStarred,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        CategoryId = entity.CategoryId,
                        CategoryName = entity.Category.Name
                    };
            }
        }

        public bool UpdateNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .SingleOrDefault(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.IsStarred = model.IsStarred;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .SingleOrDefault(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
    //create
    //create model

    //read
    //list model

    //update


    //delete




}
}
