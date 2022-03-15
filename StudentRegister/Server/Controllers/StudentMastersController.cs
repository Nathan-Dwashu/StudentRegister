using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegister.Server.Models;

namespace StudentRegister.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMastersController : ControllerBase
    {
        private readonly StudentsDBContext _context;

        public StudentMastersController(StudentsDBContext context)
        {
            _context = context;
        }

        // GET: api/StudentMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentMaster>>> GetStudentMasters()
        {
            return await _context.StudentMasters.ToListAsync();
        }

        // GET: api/StudentMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentMaster>> GetStudentMaster(int id)
        {
            var studentMaster = await _context.StudentMasters.FindAsync(id);

            if (studentMaster == null)
            {
                return NotFound();
            }

            return studentMaster;
        }

        // PUT: api/StudentMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentMaster(int id, StudentMaster studentMaster)
        {
            if (id != studentMaster.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentMasterExists(id))
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

        // POST: api/StudentMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentMaster>> PostStudentMaster(StudentMaster studentMaster)
        {
            _context.StudentMasters.Add(studentMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentMaster", new { id = studentMaster.StudentId }, studentMaster);
        }

        // DELETE: api/StudentMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentMaster>> DeleteStudentMaster(int id)
        {
            var studentMaster = await _context.StudentMasters.FindAsync(id);
            if (studentMaster == null)
            {
                return NotFound();
            }

            _context.StudentMasters.Remove(studentMaster);
            await _context.SaveChangesAsync();

            return studentMaster;
        }

        private bool StudentMasterExists(int id)
        {
            return _context.StudentMasters.Any(e => e.StudentId == id);
        }
    }
}
