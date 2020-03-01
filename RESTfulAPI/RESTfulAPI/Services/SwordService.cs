using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RESTfulAPI.Dto;
using RESTfulAPI.Infrastructure;
using RESTfulAPI.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTfulAPI.Services
{
    public class SwordService : ISwordService
    {
        private readonly SwordContext _swordContext;
        private readonly IMapper _mapper;

        public SwordService(SwordContext swordContext, IMapper mapper)
        {
            _swordContext = swordContext;
            _mapper = mapper;
        }

        public async Task<SwordDto> GetAsync(Guid id)
        {
            var sword = await _swordContext.Swords.Where(x=>x.Id == id).
                ProjectTo<SwordDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            return _mapper.Map<SwordDto>(sword);
        }

        public async Task<List<SwordDto>> FindAllAsync(Expression<Func<SwordDto, bool>> filter)
        {

            var mappedFilter = _mapper.Map<Expression<Func<Sword, bool>>>(filter);

            var swords =  await _swordContext.Swords.Where(mappedFilter)
                .ProjectTo<SwordDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return swords;
        }

        public async Task<SwordDto> CreateAsync(SwordDto swordDto)
        {

            var sword = _mapper.Map<Sword>(swordDto);

            await _swordContext.Swords.AddAsync(sword);
            _swordContext.SaveChanges();
            
            return swordDto;
        }

        public async Task<SwordDto> UpdateAsync(ISwordUpdate swordDto)
        {
            var sword = await _swordContext.Swords.FirstOrDefaultAsync(x => x.Id == swordDto.Id);

            if(sword == null)
            {
                return await CreateAsync(swordDto as SwordDto);
            }

            sword = _mapper.Map(swordDto, sword);
            sword.BlackSmithId = swordDto.BlackSmithId;

            //_swordContext.Swords.Update(sword);
            await _swordContext.SaveChangesAsync();

            return swordDto as SwordDto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var sword = await _swordContext.Swords.SingleOrDefaultAsync(x => x.Id == id);
            _swordContext.Swords.Remove(sword);
            return await _swordContext.SaveChangesAsync() >= 0;
        }
    }
}
