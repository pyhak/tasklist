using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasklist.Repo
{
    public interface IUnitOfWork
    {
        DbContext Context { get;  }
        void Commit();
        void Dispose();
    }
}
