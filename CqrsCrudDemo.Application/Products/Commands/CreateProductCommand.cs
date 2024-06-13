using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsCrudDemo.Domain.Entities;
using CqrsCrudDemo.Application.Interfaces;

namespace CqrsCrudDemo.Application.Products.Commands
{
    public class CreateProductCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;       
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            await _context.Products.AddAsync(product,cancellationToken);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
