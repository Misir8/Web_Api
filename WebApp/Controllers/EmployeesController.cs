using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<EmployeesReturnDto>>> GetEmployeesAsync()
        {
            return await _mediator.Send(new List.Query());
        }
    }
}