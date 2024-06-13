using CqrsCrudDemo.Application.Interfaces;
using CqrsCrudDemo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsCrudDemo.Application.Products.Queries
{
    public class GetProductQuery:IRequest<IEnumerable<Product>>
    {
        internal class GetProductsQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
        {
            private readonly IApplicationDbContext _context;    
            public GetProductsQueryHandler(IApplicationDbContext context)
            {
                    _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                return await _context.Products.ToListAsync(cancellationToken);
            }
        }
    }
}
