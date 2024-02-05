using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Business.Abstract
{
    public interface ICategoryService
    {
        
    IResult CreateCategory(CategoryCreateDto categoryCreate);
    IDataResult<List<CategoryHomeDto>> GetHomeCategories();

    }
}