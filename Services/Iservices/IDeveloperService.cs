using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Iservices
{
   public interface IDeveloperService
    {
        DeveloperDto Get(int Id);

        IEnumerable<DeveloperDto> GetAll();

        bool AddDto(DeveloperDto entity);

        bool Remove(int id);

        bool Save();
        bool Update(DeveloperDto devDto);
    }
}
