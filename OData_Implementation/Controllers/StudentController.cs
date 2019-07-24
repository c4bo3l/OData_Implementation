using Microsoft.AspNetCore.Mvc;
using Model.OData;

namespace OData_Implementation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : BaseController<Student>
    {
        public StudentController(ODataContext context) : base(context)
        { }
    }
}