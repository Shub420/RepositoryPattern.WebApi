using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Iservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/Developer")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IDeveloperService _developerService;
        private readonly ILogger<DeveloperController> _logger;
        public DeveloperController(IDeveloperService developerService, ILogger<DeveloperController> logger)
        {
            //_unitOfWork = unitOfWork;
            _developerService = developerService;
            _logger = logger;
        }

        /// <summary>
        /// All Developers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllDevelopers()
        {
            try
            {
                var devList = _developerService.GetAll();
                
                if (devList==null) return NotFound();

                throw new Exception("Error occured");
              
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
            
        }
        /// <summary>
        /// Add new Developer
        /// </summary>
        /// <param name="developer"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult AddDeveloper([FromBody]DeveloperDto developer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _developerService.AddDto(developer);
                }
            }
            catch(Exception)
            {
                
                _logger.LogInformation("Unable to save changes.");
                return BadRequest();
            }
            return Ok();

        }
        /// <summary>
        /// update developer 
        /// </summary>
        /// <param name="developer"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateDev([FromBody] DeveloperDto developer)
        {
            if (developer == null)
                return BadRequest(StatusCodes.Status500InternalServerError);
            if (ModelState.IsValid)
                try
                {
                    var dev = _developerService.Update(developer);
                    return Ok(dev);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            return BadRequest();



        }
        /// <summary>
        /// delete individual developer 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteDev(int id)
        {
            if (id == 0)
            {
               _logger.LogWarning($"Dev with id {id} not found");

                return NotFound();
            }
            try
            {
                var devDel = _developerService.Remove(id);
                //if(!devDel)
                //{
                //    return NotFound();
                //}
                return Ok(devDel);
            }
            catch (Exception)
            {
                // _logger.LogError($"Dev with id {id} not found");
               _logger.LogError($"please enter valid Id");
                return BadRequest();
            }



        }

        [HttpGet("{id:int}", Name = "GetDeveloper")]
        public IActionResult GetDeveloper (int id)
        {
            if (id <= 0 )
            {
                //throw new InvalidException("Invalid developer id");
            }
            
            var status = _developerService.Get(id);
            if(status==null)
                return NotFound();
            return Ok(status);
        }

        //[HttpGet("{id:int}", Name = "GetDev")]
        //public IActionResult GetDev(int id)
        //{
            
        //    if (id == 0)
        //        return BadRequest();
        //    var status = _developerService.Get(id);
        //    if (status == null)
        //        return NotFound();
        //    return Ok(status);
        //}
    }
}
