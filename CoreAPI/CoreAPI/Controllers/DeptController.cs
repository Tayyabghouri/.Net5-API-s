using CoreAPI.Data;
using CoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptController : ControllerBase //IDisposable
    {
        masterContext _db;


        public DeptController(masterContext db)
        {

            //new way to pas or inject an object 
            _db = db;   

            //old way
            //_db  = new masterContext();
        }

        // GET: api/<DeptController>
        
        [HttpGet]
        
        //new way using statuts code
        //IActionResult is a runtime polimorphism example.
        public async Task<ActionResult<IEnumerable<Department>>> Get()
        {
            IEnumerable<Department> dept = await _db.Departments.ToListAsync();
            return Ok(dept);
        }
        
        //old way
        
        //public IEnumerable<Department> Get()
        //{
        //    IEnumerable<Department> dept = _db.Departments.ToList();
        //    return dept;
        //}

        // GET api/<DeptController>/5
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> Get(int id)
        {
            var data =await _db.Departments.FirstOrDefaultAsync(x => x.DeptId == id);
            if (data == null) 
            {
                return NotFound();
            }
            return Ok(data);
        }
        //old way
        
        //public Department Get(int id)
        //{
        //    var data = _db.Departments.FirstOrDefault(x => x.DeptId == id);
        //    if (data == null) 
        //    {
        //        return null;
        //    }
        //    return data;
        //}

        // POST api/<DeptController>
        
        [HttpPost]
        public async Task<IActionResult> Post(Department model)
        {
            if(model==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid) { 
            await _db.Departments.AddAsync(model);
            _db.SaveChanges();
            }
            else 
            {
                return BadRequest();
            }
            //created at action take 3 params including method id and object
            return CreatedAtAction("Get", new { id = model.DeptId }, model);
        }
        
        //old way
        
        //public void Post(Department model)
        //{
        //    if(model==null)
        //    {
               
        //    }
        //    _db.Departments.Add(model);
        //    _db.SaveChanges();
        //}

        // PUT api/<DeptController>/5
        
        [HttpPut("{id}")]
        public async  Task<IActionResult> Put(int id , Department model)
        {
            var data =await _db.Departments.FirstOrDefaultAsync(x => x.DeptId == id);
            if (data == null)
            {
                return NotFound();
            }
            _db.Departments.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        // DELETE api/<DeptController>/5
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Department data =await _db.Departments.FirstOrDefaultAsync(x => x.DeptId == id);
            if (data == null)
            {
                return NotFound();
            }
            _db.Departments.Remove(data);
            _db.SaveChanges();
            return NoContent();
        }

        //this method will be called automatically at the end after getting record.
        
        //public void Dispose()
        //{
        //    _db.Dispose();
        //}
    }
}
