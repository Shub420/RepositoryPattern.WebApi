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
            if(project==null)
            {
                throw new ArgumentNullException($"{nameof(update)} entity must not be null");
            }
            try
            {
                _context.Update(project);
                return Save();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(project)} could not be updated: {ex.Message}");
            }

        }
    }
}
    