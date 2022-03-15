using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
   public class ProjectRepository:Repository<Project>,IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context):base(context)
        {

        }

        public bool update(Project project)
        {
            _context.Update(project);
            return Save();

        }
    }
}
    