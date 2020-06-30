using Application.Commands;
using Application.DataTransfer;
using Bogus;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Faker
{
    public class FakeLoads : ILoadsFaker
    {
        private readonly TruckloadContext context;

        public FakeLoads(TruckloadContext context)
        {
            this.context = context;
        }

        public int Id => 2;

        public string Name => "Loads search";

        public void Execute(LoadDto request)
        {
            var loadsFaker = new Faker<Load>();
            loadsFaker.RuleFor(x => x.From, f => f.Address.City());
            loadsFaker.RuleFor(x => x.To, f => f.Address.City());
            loadsFaker.RuleFor(x => x.PickUp, f => f.Date.Past(2, null));
            loadsFaker.RuleFor(x => x.Delivery, f => f.Date.Past(2, null));
            loadsFaker.RuleFor(x => x.Weight, f => f.Random.Decimal(5, 42));
            loadsFaker.RuleFor(x => x.Miles, f => f.Random.Int(100, 2000));
            loadsFaker.RuleFor(x => x.Price, f => f.Random.Decimal(500, 5000));

            var loads = loadsFaker.Generate(100);
            context.Loads.AddRange(loads);
            context.SaveChanges();

        }
    }
}
