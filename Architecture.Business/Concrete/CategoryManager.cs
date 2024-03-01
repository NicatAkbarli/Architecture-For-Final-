using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Business.Abstract;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Core.Utilities.Results.Concrete.ErrorResults;
using Architecture.Core.Utilities.Results.Concrete.SuccessResults;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.CategoryDtos;
using AutoMapper;

namespace Architecture.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
    private readonly ICategoryDal _categoryDal;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
    {
        _categoryDal = categoryDal;
        _mapper = mapper;
    }

        public IResult CreateCategory(CategoryCreateDto categoryCreate)
        {
            // business ruless => CheckCategoryName
            var mapCategory = _mapper.Map<Category>(categoryCreate);
            _categoryDal.Add(mapCategory);
            return new SuccessResult();
        }

        public Task<IResult> CreateCategoryAsync(CategoryCreateDto categoryCreate)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteCategory(int id)
        {
            var category = _categoryDal.Get(x => x.Id == id);
            category.IsDeleted = true;
            _categoryDal.Update(category);
            return new SuccessResult();
        }

        public IDataResult<List<CategoryDto>> GetCategories()
        {
            var categories = _categoryDal.GetAll(x=>x.IsDeleted == false);
            var mapCategories = _mapper.Map<List<CategoryDto>>(categories);
            return new SuccessDataResult<List<CategoryDto>>(mapCategories);
}

        public IDataResult<List<CategoryHomeDto>> GetHomeCagories()
        {
            var categories = _categoryDal.GetAll(x => x.IsDeleted == false && x.IsFeatured == true);
            var mapCategories = _mapper.Map<List<CategoryHomeDto>>(categories);
            return new SuccessDataResult<List<CategoryHomeDto>>(mapCategories.Take(6).ToList());
        }

        public IDataResult<List<CategoryHomeDto>> GetHomeCategories()
    {
        return new SuccessDataResult<List<CategoryHomeDto>>(null, "elave olundu");
    }

        public IDataResult<List<CategoryNavbarDto>> GetNavbarCategories()
        {
            var categories = _categoryDal.GetAll(x => x.IsDeleted == false && x.IsNavbar == true);
            var mapCategories = _mapper.Map<List<CategoryNavbarDto>>(categories);
            return new SuccessDataResult<List<CategoryNavbarDto>>(mapCategories);
         }

        public IResult TestMethodAll(int id)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateCategory(int id, CategoryUpdateDto category)
        {
            var mapCategory = _mapper.Map<Category>(category);
            var findCategory = _categoryDal.Get(x => x.Id == id);
            findCategory.CategoryName = mapCategory.CategoryName;
            findCategory.CreatedDate = mapCategory.CreatedDate;
            findCategory.PhotoUrl = mapCategory.PhotoUrl;
            findCategory.IsNavbar = mapCategory.IsNavbar;
            findCategory.IsFeatured = mapCategory.IsFeatured;
            _categoryDal.Update(findCategory);
            return new SuccessResult();
        }
    }
}