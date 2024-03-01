using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.TagDtos;
using Architecture.Entities.Dtos.WishlistDtos;

namespace Architecture.Business.Abstract
{
    public interface ITagService
    {
       
         IResult CreateTag(TagCreateDto tagCreate);
        IResult UpdateTag(int id, TagUpdateDto category);
		IResult DeleteTag(int id);
		IDataResult<List<TagDto>> GetTags();
		IDataResult<List<TagHomeDto>> GetHomeTags();
    }
}