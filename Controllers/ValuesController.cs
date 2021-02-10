using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await _mediator.Send(new WebApplicationMediator.Queries.GetValuesQuery.Query());
        }
        
        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            await _mediator.Send(new WebApplicationMediator.Commands.AddValueCommand.Command
            {
                Value = value
            });
        }
        
    }
}