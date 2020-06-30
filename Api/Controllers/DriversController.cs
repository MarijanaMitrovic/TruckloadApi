using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {

        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public DriversController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/Drivers
        [HttpGet]
        public IActionResult Get([FromQuery] DriverSearch search, [FromServices] IGetDriversQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Drivers/5
        [HttpGet("{id}", Name = "GetDrivers")]
        public IActionResult Get(int id, [FromServices] IGetSingleDriver query)
        {
            var result = executor.ExecuteQuery(query, id);
            return Ok(result);
        }
        // POST: api/Drivers
        [HttpPost]
        public void Post([FromBody] CreateDriverDto dto,
            [FromServices] ICreateDriverCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Drivers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateDriverDto dto,
            [FromServices] IUpdateDriverCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteDriverCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
