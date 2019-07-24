using Microsoft.AspNetCore.Mvc;
using Model.OData;

namespace OData_Implementation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : BaseController<School>
    {
        public SchoolController(ODataContext context) : base(context)
        { }
    }
}