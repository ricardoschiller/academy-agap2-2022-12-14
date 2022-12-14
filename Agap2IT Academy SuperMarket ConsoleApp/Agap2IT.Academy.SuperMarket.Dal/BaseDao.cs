using Agap2IT.Academy.SuperMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Academy.SuperMarket.Dal
{
    public class BaseDao
    {

        protected AcademyAgap213122022Context CreateContext()
        {
            var context = new AcademyAgap213122022Context();

            context.ChangeTracker.AutoDetectChangesEnabled = false;

            return context;
        }



    }
}
