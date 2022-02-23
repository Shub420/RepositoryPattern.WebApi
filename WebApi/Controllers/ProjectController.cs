
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {

            var proList = _unitOfWork.Project.GetAll().Select(_mapper.Map<Project,ProjectDto>);
            return Ok(proList);
        }
        [HttpPost]
        public IActionResult AddProject([FromBody]ProjectDto projectDto)
        {
            if (projectDto == null)
                return BadRequest();
            var project = _mapper.Map<ProjectDto, Project>(projectDto);
            if (!_unitOfWork.Project.Add(project))
            {
                ModelState.AddModelError("", $"something went wrong while saving:{project.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
              
            }
            return Ok();       //200 status code 
        }
        [HttpPatch]
        public IActionResult UpdateProject([FromBody]ProjectDto projectDto)
        {
            if (projectDto == null)
                return BadRequest(StatusCodes.Status500InternalServerError);
            if (!ModelState.IsValid)
                return BadRequest();
            var proj = _mapper.Map<ProjectDto,Project>(projectDto);
            return Ok(proj);
        }

        [HttpDelete]
        public IActionResult DeleteProj(int id )
        {
            var proj = _unitOfWork.Project.Get(id);
            _unitOfWork.Project.Remove(proj);
            return NoContent();
        }
    }
}
