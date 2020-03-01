using RESTfulAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTfulAPI.Services
{
    public interface ISwordService
    {
        Task<SwordDto> CreateAsync(SwordDto sword);
        Task<bool> DeleteAsync(Guid id);
        Task<List<SwordDto>> FindAllAsync(Expression<Func<SwordDto, bool>> filter);
        Task<SwordDto> GetAsync(Guid id);
        Task<SwordDto> UpdateAsync(ISwordUpdate sword);
    }
}