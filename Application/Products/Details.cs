using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class Details
    {
        public class Query: IRequest<ProductReturnDto>
        {
            public int Id { get; set; }
        }

        public class Handler:IRequestHandler<Query, ProductReturnDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ProductReturnDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Products
                    .Include(x =>x.Category).FirstOrDefaultAsync(x => x.Id == request.Id);
                if(product == null) throw new RestException(HttpStatusCode.NotFound, new {Product = "product not found", Code = HttpStatusCode.NotFound});
                var map = _mapper.Map<Product, ProductReturnDto>(product);
                return map;
            }
        }
    }
}