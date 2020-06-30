using Application.Commands;
using Application.DataTransfer;
using Application.Email;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {       

        private readonly TruckloadContext context;
        private readonly RegisterUserValidator validator;
        private readonly IEmailSender sender;

        public EfRegisterUserCommand(TruckloadContext context, RegisterUserValidator validator, IEmailSender sender)
        {
            this.context = context;
            this.validator = validator;
            this.sender = sender;

        }

        public int Id => 100;
        public string Name => "Register user command.";



        public void Execute(RegisterUserDto request)
        {
            validator.ValidateAndThrow(request);

            context.Users.Add(new Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Phone=request.Phone
                
            });

            context.SaveChanges();

            sender.Send(new SendEmailDto
            {
                Content = "<h1>You have successfully registred</h1>",
                SendTo = request.Email,
                Subject = "Registration confirmation"
            });
        }
    }
}
