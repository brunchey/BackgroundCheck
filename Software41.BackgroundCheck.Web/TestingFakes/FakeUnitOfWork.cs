using Software41.BackgroundCheck.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software41.BackgroundCheck.Web.TestingFakes
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            //nothing
        }
    }
}