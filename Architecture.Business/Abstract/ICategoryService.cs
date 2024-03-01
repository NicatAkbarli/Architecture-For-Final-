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
        IResult UpdateCategory(int id, CategoryUpdateDto category);
		IResult DeleteCategory(int id);
		IDataResult<List<CategoryDto>> GetCategories();
		IDataResult<List<CategoryHomeDto>> GetHomeCagories();
		IDataResult<List<CategoryNavbarDto>> GetNavbarCategories();
		IResult TestMethodAll(int id);


        // Async method
        Task<IResult> CreateCategoryAsync(CategoryCreateDto categoryCreate);

    }
}