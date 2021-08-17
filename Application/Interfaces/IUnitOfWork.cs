using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        public IShortLinkRepository ShortLinkRepository();
        void Commit();

    }
}
