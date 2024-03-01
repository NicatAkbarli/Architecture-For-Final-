using System;
using AutoMapper;
using Architecture.Business.Abstract;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Core.Utilities.Results.Concrete.SuccessResults;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.SpecificationDtos;

namespace Architecture.Business.Concrete
{
    public class SpecificationManager : ISpecificationService
    {
        private readonly ISpecificationDal _specificationDal;
        private readonly IMapper _mapper;

        public SpecificationManager(ISpecificationDal specificationDal, IMapper mapper)
        {
            _specificationDal = specificationDal;
            _mapper = mapper;
        }

        public IResult CreateSpecifications(int productId, List<SpecificationCreateDto> specifications)
        {
            var mapper = _mapper.Map<List<Specification>>(specifications);
            _specificationDal.AddSpecifications(productId,mapper);
            return new SuccessResult();
        }
    }
}

