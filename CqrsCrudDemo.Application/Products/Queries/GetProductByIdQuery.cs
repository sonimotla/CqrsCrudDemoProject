﻿using CqrsCrudDemo.Application.Interfaces;
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
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IApplicationDbContext _context;
            public GetProductByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
