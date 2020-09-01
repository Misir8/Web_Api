using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using WebApp.Controllers;
using Xunit;

namespace WebApp.Tests
{
    public class ProductsControllerTest:IDisposable
    {
        private DataContext _context;
        private IMapper _mapper;
        private Product _product;
        private Category _category;
        private ProductsController _controller;
        private IMediator _mediator;
        public ProductsControllerTest()
        {
            _context = ServiceLocator.ResolveRequired<DataContext>();
            _mediator = ServiceLocator.ResolveRequired<IMediator>();
            _mapper = ServiceLocator.ResolveRequired<IMapper>();
            _controller = new ProductsController(_mediator);
            _category = new Category{Id = 5, Name = "Test"};
            _product = new Product{Id = 6, Name = "TestName", Description = "Desc", Price = 200, CategoryId = 4};
            _context.Products.Add(_product);
            _context.Categories.Add(_category);
            _context.SaveChanges();

        }
        
        [Fact]
        public async Task GetProduct()
        {
            var result = await _controller.GetProductsAsync();
            var value = result.Value;
            Assert.True(value.Count() > 0);
        }

        public void Dispose()
        {
             if (_category != null)
                 _context.Categories.Remove(_category);
             
             if (_product != null)
                 _context.Products.Remove(_product);
             
             _context.SaveChanges();
        }
        
    }
}