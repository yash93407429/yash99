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
    public class GroceryController : ControllerBase
    {
        private readonly DB_Context _context;

        public GroceryController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TblDesignations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grocery>>> GettblDesignations()
        {
            return await _context.tblDesignations.ToListAsync();
        }

        // GET: api/TblDesignations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grocery>> GetTblDesignation(int id)
        {
            var tblDesignation = await _context.tblDesignations.FindAsync(id);

            if (tblDesignation == null)
            {
                return NotFound();
            }

            return tblDesignation;
        }

        

        

       
    }
}
