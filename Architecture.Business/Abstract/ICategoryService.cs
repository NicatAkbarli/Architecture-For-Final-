using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Entities.Dtos.CategoryDtos;

namespace Architecture.Business.Abstract
{
    public interface ICategoryService
    {
        
    IResult CreateCategory(CategoryCreateDto categoryCreate);
    IDataResult<List<CategoryHomeDto>> GetHomeCategories();

    }
}