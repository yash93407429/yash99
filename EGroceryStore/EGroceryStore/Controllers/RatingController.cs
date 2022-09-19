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
    public class RatingController : ControllerBase
    {
        private readonly DB_Context _context;

        public RatingController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/Rating
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRating()
        {
            //return await _context.Rating.ToListAsync();
            var rating = (from c in _context.Rating
                         join g in _context.tblDesignations





                         on c.GroceryId equals g.Id


                         select new Rating
                         {
                            RatingId = c.RatingId,
                            Ratings=c.Ratings,

                             GroceryId = c.GroceryId,
                             Groceryname = g.Designation
                         }).ToListAsync();
            return await rating;
        }

       

        

        // POST: api/Rating
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating(Rating rating)
        {
            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRating", new { id = rating.RatingId }, rating);
        }

        

       
    }
}
