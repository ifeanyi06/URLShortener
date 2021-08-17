using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShortLinkRepository : GenericRepository<ShortLink>, IShortLinkRepository
    {
        private readonly DbSet<ShortLink> _shortLinks;

        public ShortLinkRepository(ShortURLContext dbContext) : base(dbContext)
        {
            _shortLinks = dbContext.Set<ShortLink>();
        }

       
    }
}
