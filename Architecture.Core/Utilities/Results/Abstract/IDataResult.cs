using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Core.Utilities.Results.Abstract;

public interface IDataResult<T> : IResult
{
    public T Data { get; }
}
