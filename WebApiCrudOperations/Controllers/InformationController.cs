using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCrudOperations.Models;

namespace WebApiCrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public InformationController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetDetails")]
        public IActionResult GetDetails()
        {
            var Info = _context.datas.ToList();
            return Ok(Info);
        }

        [HttpGet]
        [Route("GetDetailsById")]
        public IActionResult GetDetailsById(int id)
        {
            var Info = _context.datas.FirstOrDefault(x => x.Id == id);
            return Ok(Info);
        }

        [HttpPost]
        [Route("CreateDetails")]
        public IActionResult CreateDetails(Data data)
        {
            var Info = _context.datas.Add(data);
            _context.SaveChanges();
            return Ok("successfully created!");
        }

        [HttpPut]
        [Route("EditDetails")]
        public IActionResult EditDetailsById(Data data,int id)
        {
            var Details = _context.datas.Where(x => x.Id == id).FirstOrDefault();
            if(Details== null) 
            {
                return NotFound();
            };
            Details.Name = data.Name;
            Details.Description = data.Description; 

            _context.SaveChanges();
            return Ok("successfully Updated!");
        }

        //Product prodItem = DbContext.Products.Where(p => p.ProductId == productItem.ProductId).FirstOrDefault();
        //    if (prodItem != null)
        //    {
        //        prodItem.ProductName = productItem.ProductName;
        //        prodItem.Quantity = productItem.Quantity;
        //        prodItem.Price = productItem.Price;
        //        DbContext.SaveChanges();
        //    }


    [HttpDelete]
        [Route("DeleteDetailsById")]
        public IActionResult DeleteDetailsById(int id)
        {
            var Info = _context.datas.FirstOrDefault(x => x.Id == id);
            _context.datas.Remove(Info);
            _context.SaveChanges();
            return Ok("successfully Deleted!");
        }
    }
}
