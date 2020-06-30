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
    public class LoadsController : ControllerBase

    {

        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public LoadsController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/Loads
        [HttpGet]
        public IActionResult Get([FromQuery] LoadSearch search, [FromServices] IGetLoadsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Loads/5
        [HttpGet("{id}", Name = "GetLoads")]
        public IActionResult Get(int id, [FromServices] IGetSingleLoad query)
        {
            var result = executor.ExecuteQuery(query, id);
            return Ok(result);
        }

        // POST: api/Loads
        [HttpPost]
        public void Post([FromBody] CreateLoadDto dto,
            [FromServices] ICreateLoadCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Loads/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateLoadDto dto,
            [FromServices] IUpdateLoadCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLoadCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
