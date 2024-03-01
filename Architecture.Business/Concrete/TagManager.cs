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
using Architecture.Entities.Dtos.TagDtos;
using Architecture.Entities.Dtos.WishlistDtos;
using AutoMapper;

namespace Architecture.Business.Concrete
{
    public class TagManager : ITagService
    {
        private readonly IMapper _mapper;
        private readonly ITagDal _tagDal;
        public TagManager(IMapper mapper, ITagDal tagDal)
        {
            _mapper = mapper;
            _tagDal = tagDal;
        }

       
        public IResult CreateTag(TagCreateDto tagCreate)
        {
           var maptag = _mapper.Map<Tag>(tagCreate);
            _tagDal.Add(maptag);
            return new SuccessResult();
        }
        

        public IResult DeleteTag(int id)
        {
           var tag = _tagDal.Get(x => x.Id == id);
            tag.IsDeleted = true;
            _tagDal.Update(tag);
            return new SuccessResult();
        }

        public IDataResult<List<TagHomeDto>> GetHomeTags()
        {
          
            var tags = _tagDal.GetAll(x => x.IsDeleted == false && x.IsFeatured == true);
            var mapTags = _mapper.Map<List<TagHomeDto>>(tags);
            return new SuccessDataResult<List<TagHomeDto>>(mapTags.Take(6).ToList());
        }

        public IDataResult<List<TagDto>> GetTags()
        {
             var tags = _tagDal.GetAll(x=>x.IsDeleted == false);
            var maptags = _mapper.Map<List<TagDto>>(tags);
            return new SuccessDataResult<List<TagDto>>(maptags);
        }

        public IResult UpdateTag(int id, TagUpdateDto tag)
        {
            var maptag = _mapper.Map<Tag>(tag);
            var findtag = _tagDal.Get(x => x.Id == id);
            findtag.TagName = maptag.TagName;
            findtag.CreatedDate = maptag.CreatedDate;
            findtag.IsFeatured = maptag.IsFeatured;
            _tagDal.Update(findtag);
            return new SuccessResult();
        }
    }
}