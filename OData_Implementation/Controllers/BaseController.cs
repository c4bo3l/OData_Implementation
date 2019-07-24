using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Model.OData;

namespace OData_Implementation.Controllers
{
    public abstract class BaseController<T> : ControllerBase
        where T : BaseEntity
    {
        private readonly ODataContext _Context;
        public BaseController(ODataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 10)]
        public IActionResult Get()
        {
            return Ok(_Context.Set<T>());
        }
    }
}