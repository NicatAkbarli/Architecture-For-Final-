using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Core.Utilities.Results.Concrete.ErrorResults;
using Architecture.Core.Utilities.Results.Concrete.SuccessResults;

namespace Architecture.Core.Utilities.Business;

public class BusinessRule
{
    public static IResult Run(params IResult[] results)
    {
        foreach (var result in results)
        {
            if (!result.Success)
            {
                return new ErrorResult();
            }
        }
        return new SuccessResult();
    }
}
