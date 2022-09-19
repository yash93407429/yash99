using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EGroceryStore.DataAccess;
using EGroceryStore.Models;

namespace EGroceryStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DB_Context _context;

        public OrderController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            //return await _context.Order.ToListAsync();
            var order = (from c in _context.Order
                         join g in _context.tblDesignations





                         on c.GroceryId equals g.Id


                         select new Order
                         {
                            OrderId = c.OrderId,


                             GroceryId = c.GroceryId,
                             Groceryname = g.Designation
                         }).ToListAsync();
            return await order;
        }

       

        

        // POST: api/Order
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        
    
    }
}
