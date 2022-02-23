using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
   public interface IUnitOfWork:IDisposable
    {
        IDeveloperRepository Developer { get; }
        IProjectRepository Project { get; }
        //IDeveloperRepository IDeveloper { get; }
        int Complete();
    }
}
