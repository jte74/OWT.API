using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace OWT.API
{
    public class ApiControllerBase : ControllerBase
    { 
   protected readonly IMapper Mapper;

    public ApiControllerBase(IMapper mapper)
    {
        Mapper = mapper;
    }
}
}
