using System;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Entities.Dtos.SpecificationDtos;

namespace Architecture.Business.Abstract
{
    public interface ISpecificationService
    {
        IResult CreateSpecifications(int productId, List<SpecificationCreateDto> specifications);

    }
}

