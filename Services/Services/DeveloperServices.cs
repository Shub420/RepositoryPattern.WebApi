using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Services.Iservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DeveloperServices : IDeveloperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeveloperServices(IUnitOfWork unitOfWork , IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool AddDto(DeveloperDto entity)
        {
            if (entity == null)
                return false;
            var dev = _mapper.Map<DeveloperDto, Developer>(entity);
            _unitOfWork.Developer.Add(dev);
            return true;
        }

        public DeveloperDto Get(int Id)
        {
            if (Id == 0)
                return null;
            var devIndb = _unitOfWork.Developer.Get(Id);
            if (devIndb == null)

                return null;

            var devDto = _mapper.Map<Developer, DeveloperDto>(devIndb);
            return devDto;


        }

        public IEnumerable<DeveloperDto> GetAll()
        {
            var devList = _unitOfWork.Developer.GetAll().Select(_mapper.Map<Developer,DeveloperDto >);
            return devList;
        }

        public bool Remove(int devDto)
        {
            if (devDto == 0)
                return false;
            var emp = _unitOfWork.Developer.Get(devDto);
            if (emp == null)
                return false;
            if (!_unitOfWork.Developer.Remove(emp))
            {
                return false;
            }
            return true;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(DeveloperDto devDto)
        {
            if (devDto == null)
                return false;
            var empDtos = _mapper.Map<DeveloperDto,Developer>(devDto);
            if (!_unitOfWork.Developer.update(empDtos))
            {
                return false;
            }
            return true;
        }
    }
}
