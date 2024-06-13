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
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;       
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
           var product= _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();
            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                await _context.SaveChangesAsync();
                return product.Id;
            }
            return default;
        }
    }
}
