using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private DeveloperRepository _DeveloperRepository { get; set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Developer = new DeveloperRepository(_context);
            Project = new ProjectRepository(_context);
        }

        //public IDeveloperRepository IDeveloper
        //=> _DeveloperRepository = _DeveloperRepository ?? new DeveloperRepository(_context);
       

        public IProjectRepository Project { get; private set; }

        public IDeveloperRepository Developer { get; private set; }

        //public IDeveloperRepository Developer => _DeveloperRepository = _DeveloperRepository ?? new DeveloperRepository(_context);

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
