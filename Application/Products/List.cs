using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class List
    {
        public class Query: IRequest<List<ProductReturnDto>>
        {
        }
        public class Handler: IRequestHandler<Query, List<ProductReturnDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<ProductReturnDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var products = await _context.Products
                    .Include(x => x.Category).ToListAsync();
                return _mapper.Map<List<Product>, List<ProductReturnDto>>(products);
            }
        }
    }
}