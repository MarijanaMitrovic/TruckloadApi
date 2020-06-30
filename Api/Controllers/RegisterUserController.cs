using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        public RegisterUserController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // POST: api/RegisterUser
        [HttpPost]
        public void Post([FromBody] RegisterUserDto dto,
            [FromServices] IRegisterUserCommand command)
        {
            executor.ExecuteCommand(command, dto);

        }

    }
}
