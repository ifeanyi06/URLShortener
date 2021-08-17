using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShortURLContext _dbContext;

        public UnitOfWork(ShortURLContext context)
        {
            _dbContext = context;    
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IShortLinkRepository ShortLinkRepository()
        {
            return new ShortLinkRepository(_dbContext);        
        }

    }
}
