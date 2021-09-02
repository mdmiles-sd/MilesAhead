using MilesAhead.Data;
using MilesAhead.Models;
using MilesAhead.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesAhead.Servies
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
                var clientQuery =
                    ctx
                        .Clients
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e => new ClientList
                            {
                                ClientID = e.ClientID,
                                OwnerID = e.OwnerID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                BirthDate = e.BirthDate,
                                Age = e.Age,
                                Sex = e.Sex,
                                InitalCreateUTC = e.InitalCreateUTC,
                                

                            });

                return clientQuery.ToArray();
            }
        }

        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client
                {
                    ClientID = model.ClientID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate,
                    Age = model.Age,
                    Sex = model.Sex,
                    InitalCreateUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ClientDetail GetClientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .SingleOrDefault(e => e.ClientID == id && e.OwnerID == _userId);

                return
                    new ClientDetail
                    {
                        ClientID = entity.ClientID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Age = entity.Age,
                        BirthDate = entity.BirthDate,
                        Sex = entity.Sex,                        
                    };
            }
        }

        public bool UpdateClient(ClientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .SingleOrDefault(e => e.ClientID == model.ClientID && e.OwnerID == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;                
                entity.Height = model.Height;
                entity.Weight = model.Weight;                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteClient(int clientID)
        {
            using (var ctx = new ApplicationDbContext())

            {
                var entity =
                    ctx
                        .Clients
                        .SingleOrDefault(e => e.ClientID == clientID && e.OwnerID == _userId);

                ctx.Clients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}

