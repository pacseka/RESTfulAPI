using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RESTfulAPI.Dto;
using RESTfulAPI.DTO;
using RESTfulAPI.Filter;
using RESTfulAPI.Services;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SwordsController : ControllerBase
    {
        private readonly ISwordService _swordService;
        private readonly IMapper _mapper;

        public SwordsController(ISwordService swordService, IMapper mapper)
        {
            _swordService = swordService;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            var sword = await _swordService.GetAsync(id);

            return Ok(sword);
        }

        [HttpGet]
        public async Task<IActionResult> FilterFromQuery([FromQuery] SwordFilter filter)
        {
            var swords = await _swordService.FindAllAsync(x =>
            (filter.Name == null || x.Name == filter.Name)
            &&
            (filter.Type == null || x.Type == filter.Type)
            &&
            (filter.BlackSmithName == null || x.BlackSmithName == filter.BlackSmithName)
            &&
            (filter.BlackSmithRace == null || x.BlackSmithRace == filter.BlackSmithRace)
            );

            return Ok(swords);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UpsertSword sword)
        {
            var swordDto = _mapper.Map<SwordDto>(sword);
            swordDto.Id = Guid.NewGuid();
            swordDto = await _swordService.CreateAsync(swordDto);

            return Created($"/swords/{swordDto.Id}", swordDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Upsert([FromRoute] Guid id, [FromBody]UpsertSword sword)
        {
            var swordDto = _mapper.Map<SwordDto>(sword);
            swordDto.Id = id;

            swordDto = await _swordService.UpdateAsync(swordDto);

            return Ok(swordDto);
        }

        //https://docs.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-3.1
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Patch([FromRoute]Guid id, [FromBody]JsonPatchDocument<SwordDto> patch)
        {

            var sword = await _swordService.GetAsync(id);

            patch.ApplyTo(sword, ModelState);

            if (!TryValidateModel(sword))
            {
                return BadRequest(ModelState);
            }

            sword = await _swordService.UpdateAsync(sword);

            return Ok(sword);
        }
    }
}
