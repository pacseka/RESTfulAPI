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
    public class BlackSmithService : IBlackSmithService
    {
        private readonly SwordContext _swordContext;
        private readonly IMapper _mapper;

        public BlackSmithService(SwordContext swordContext, IMapper mapper)
        {
            _swordContext = swordContext;
            _mapper = mapper;
        }

        public async Task<BlackSmithDto> GetAsync(Guid id)
        {
            var blackSmith = await _swordContext.BlackSimths
                .Where(x => x.Id == id)
                .ProjectTo<BlackSmithDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            var blackSmithDto = _mapper.Map<BlackSmithDto>(blackSmith);

            return blackSmithDto;
        }

        public async Task<List<BlackSmithDto>> FindAllAsync(Expression<Func<BlackSmithDto, bool>> filter)
        {
            var mappedFilter = _mapper.Map<Expression<Func<BlackSmith, bool>>>(filter);

            var blackSmiths = await _swordContext.BlackSimths
                .Where(mappedFilter)
                .ProjectTo<BlackSmithDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return blackSmiths;
        }

        public async Task<BlackSmithDto> CreateAsync(BlackSmithDto blackSmithDto)
        {
            var blackSmith = _mapper.Map<BlackSmith>(blackSmithDto);

            await _swordContext.BlackSimths.AddAsync(blackSmith);

            return blackSmithDto;

        }

        public async Task<BlackSmithDto> UpdateAsync(IBlackSmithUpdate blackSmithDto)
        {
            var blackSmith = await _swordContext.BlackSimths.FirstOrDefaultAsync(x => x.Id == blackSmithDto.Id);

            if (blackSmith == null)
            {
                return await CreateAsync(blackSmithDto as BlackSmithDto);
            }

            blackSmith = _mapper.Map(blackSmithDto, blackSmith);

            _swordContext.Update(blackSmith);
            await _swordContext.SaveChangesAsync();

            blackSmithDto = _mapper.Map<BlackSmithDto>(blackSmith);

            return blackSmithDto as BlackSmithDto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var blackSmith = await _swordContext.BlackSimths.SingleOrDefaultAsync(x => x.Id == id);

            _swordContext.BlackSimths.Remove(blackSmith);

            return await _swordContext.SaveChangesAsync() >= 0;
        }


    }
}
