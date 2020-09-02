using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Products;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Employees
{
    public class List
    {
        public class Query: IRequest<List<EmployeesReturnDto>>
        {
        }
        public class Handler: IRequestHandler<Query, List<EmployeesReturnDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<EmployeesReturnDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employees = await _context.Employees.Include(x => x.Department).ToListAsync();
                return _mapper.Map<List<Employee>, List<EmployeesReturnDto>>(employees);
            }
        }
    }
}