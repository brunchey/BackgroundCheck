using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software41.BackgroundCheck.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
