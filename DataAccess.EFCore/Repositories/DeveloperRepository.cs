using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationDbContext context):base(context)
        {

        }
        public bool update(Developer developer)
        {
            _context.Update(developer);
            return Save();
        }

    }
}
