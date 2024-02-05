using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Core.Utilities.Results.Concrete.ErrorResults;
using Architecture.Core.Utilities.Results.Concrete.SuccessResults;
using Architecture.Entities.Concrete;
using AutoMapper;

namespace Architecture.Business.Concrete
{
    public class CategoryManager
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
        try
        {
            var map = _mapper.Map<Category>(categoryCreate);
            map.SeoUrl = "telefonlar";
            map.CreatedDate = DateTime.Now;
            _categoryDal.Add(map);
            return new SuccessResult("Elave olundu");
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message.ToString());
        }
    }


    public IDataResult<List<CategoryHomeDto>> GetHomeCategories()
    {
        return new SuccessDataResult<List<CategoryHomeDto>>(null, "elave olundu");
    }
    }
}