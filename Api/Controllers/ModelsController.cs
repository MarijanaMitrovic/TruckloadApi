using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{ 
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {

        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public ModelsController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
            
        }
        // GET: api/Models
        [HttpGet]
        public IActionResult Get([FromQuery] ModelSearch search, [FromServices] IGetModelsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Models/5
        [HttpGet("{id}", Name = "GetModel")]
        public IActionResult Get(int id, [FromServices] IGetSingleModel query)
        {
            var result = executor.ExecuteQuery(query, id);
            return Ok(result);
        }

        // POST: api/Models
        [HttpPost]
        public void Post([FromBody] CreateModelDto dto,
            [FromServices] ICreateModelCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Models/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateModelDto dto,
            [FromServices] IUpdateModelCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteModelCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
