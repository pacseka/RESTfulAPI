using RESTfulAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTfulAPI.Services
{
    public interface IBlackSmithService
    {
        Task<BlackSmithDto> CreateAsync(BlackSmithDto blackSmithDto);
        Task<bool> DeleteAsync(Guid id);
        Task<List<BlackSmithDto>> FindAllAsync(Expression<Func<BlackSmithDto, bool>> filter);
        Task<BlackSmithDto> GetAsync(Guid id);
        Task<BlackSmithDto> UpdateAsync(IBlackSmithUpdate blackSmithDto);
    }
}