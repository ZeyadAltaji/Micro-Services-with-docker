using AutoMapper;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repo.Interface;
using System.Collections.Generic;
using System;
using Models;
using platformWebAPIs.SyncDataServices.http;
using System.Threading.Tasks;

namespace platformWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatfromsReop _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _dataClient;
        public PlatformsController(IPlatfromsReop repository, IMapper mapper,ICommandDataClient dataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _dataClient = dataClient;
        }
        // GET: api/<PlatformsController>
        [HttpGet]
        public ActionResult<IEnumerable<PlatfromsReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms....");

            var platformItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatfromsReadDto>>(platformItem));
        }
        // GET api/<PlatformsController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PlatfromsReadDto>> GetPlatformsbyId(int id)
        {
            var getbyId = _repository.GetPlatformById(id);
            if (getbyId != null)
                return Ok(_mapper.Map<PlatfromsReadDto>(getbyId));
            return BadRequest(404);
        }

        // POST api/<PlatformsController>
        [HttpPost]
        public async Task<ActionResult<PlatfromsReadDto>> creatplatfroms(PlatfromCreateDTO platfromCreate)
        {
            var platfromModel = _mapper.Map<Platfrom>(platfromCreate);
            _repository.CreatePlatform(platfromModel);
            _repository.SaveChanges();
            var platformRead = _mapper.Map<PlatfromsReadDto>(platfromModel);
            try
            {
                await _dataClient.SendplatformsCommand(platformRead);
            }catch (Exception ex)
            {
               Console.WriteLine($"--> could not send synchronously :{ex.Message}");
            }
            var itemCreate = CreatedAtRoute(nameof(GetPlatformsbyId), new { id = platformRead.Id }, platformRead);
            return Ok(itemCreate);
            //return CreatedAtRoute(nameof(GetPlatformsbyId), new { id = platformRead.Id }, platformRead);
        }
    }
}
