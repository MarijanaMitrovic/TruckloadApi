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
    public class TrucksController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public TrucksController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }


        // GET: api/Trucks
        [HttpGet]
        public IActionResult Get([FromQuery] TruckSearch search, [FromServices] IGetTrucksQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Trucks/5
        [HttpGet("{id}", Name = "GetTrucks")]
        public IActionResult Get(int id, [FromServices] IGetSingleTruck query)
        {
            var result = executor.ExecuteQuery(query, id);
            return Ok(result);
        }

        // POST: api/Trucks
        [HttpPost]
        public void Post([FromBody] CreateTruckDto dto,
            [FromServices] ICreateTruckCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Trucks/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateTruckDto dto,
            [FromServices] IUpdateTruckCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTruckCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
