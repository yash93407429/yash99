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
    public class BuyController : ControllerBase
    {
        private readonly DB_Context _context;

        public BuyController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TblEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buy>>> GettblEmployees()
        {
            //return await _context.tblEmployees.ToListAsync();
            var employees = (from e in _context.tblEmployees
                             join d in _context.tblDesignations


                             on e.DesignationID equals d.Id


                             select new Buy
                             {
                                 Id = e.Id,
                                 Name = e.Name,
                                
                                 DesignationID = e.DesignationID,
                                 Designation = d.Designation
                             }).ToListAsync();
            return await employees;
        }

        // GET: api/TblEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buy>> GetTblEmployee(int id)
        {
            var tblEmployee = await _context.tblEmployees.FindAsync(id);

            if (tblEmployee == null)
            {
                return NotFound();
            }

            return tblEmployee;
        }

        // PUT: api/TblEmployees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEmployee(int id, Buy tblEmployee)
        {
            if (id != tblEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblEmployees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Buy>> PostTblEmployee(Buy tblEmployee)
        {
            _context.tblEmployees.Add(tblEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEmployee", new { id = tblEmployee.Id }, tblEmployee);
        }

        // DELETE: api/TblEmployees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Buy>> DeleteTblEmployee(int id)
        {
            var tblEmployee = await _context.tblEmployees.FindAsync(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            _context.tblEmployees.Remove(tblEmployee);
            await _context.SaveChangesAsync();

            return tblEmployee;
        }

        private bool TblEmployeeExists(int id)
        {
            return _context.tblEmployees.Any(e => e.Id == id);
        }
    }
}
