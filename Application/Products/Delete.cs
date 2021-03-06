﻿using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class Delete
    {
        public class Command:IRequest
        {
            public int Id { get; set; }
        }
        
        public class Handler:IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
                if(product == null)  throw new RestException(HttpStatusCode.NotFound, new {Product = "not found"});
                _context.Products.Remove(product);
                
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}