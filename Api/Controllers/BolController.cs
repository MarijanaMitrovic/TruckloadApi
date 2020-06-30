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
 

        public class BolController : ControllerBase
        {

            private readonly UseCaseExecutor executor;
            private readonly IApplicationActor actor;

            public BolController(UseCaseExecutor executor, IApplicationActor actor)
            {
                this.executor = executor;
                this.actor = actor;
            }


            // GET: api/Bol
        [HttpGet]
        public IActionResult Get([FromQuery] BolSearch search, [FromServices] IGetBolsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Bol/5
        [HttpGet("{id}", Name = "GetBols")]
        public IActionResult Get(int id, [FromServices] IGetSingleBol query)
        {
            var result = executor.ExecuteQuery(query, id);
            return Ok(result);
        }

        // POST: api/Bol
        [HttpPost]
            public void Post([FromForm] UploadBolDto dto, [FromServices] IUploadBolCommand command)
            {

                executor.ExecuteCommand(command, dto);
            }
         
        }
    }

