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
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }  
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;       
        }
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           var product= _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();
            if (product == null)
            {
                return default;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return default;           
        }
    }
}
