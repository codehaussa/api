using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeHausAPI.Data;
using CodeHausAPI.Models;

namespace CodeHausAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly CMSContext _context;

        public FeaturesController(CMSContext context)
        {
            _context = context;
        }

        // GET: api/CompanyFeatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyFeature>>> GetCompanyFeatures()
        {
          if (_context.CompanyFeatures == null)
          {
              return NotFound();
          }
            return await _context.CompanyFeatures.ToListAsync();
        }

        // GET: api/CompanyFeatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyFeature>> GetCompanyFeature(int id)
        {
          if (_context.CompanyFeatures == null)
          {
              return NotFound();
          }
            var companyFeature = await _context.CompanyFeatures.FindAsync(id);

            if (companyFeature == null)
            {
                return NotFound();
            }

            return companyFeature;
        }

        // PUT: api/CompanyFeatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyFeature(int id, CompanyFeature companyFeature)
        {
            if (id != companyFeature.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyFeatureExists(id))
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

        // POST: api/CompanyFeatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyFeature>> PostCompanyFeature(CompanyFeature companyFeature)
        {
          if (_context.CompanyFeatures == null)
          {
              return Problem("Entity set 'CMSContext.CompanyFeatures'  is null.");
          }
            _context.CompanyFeatures.Add(companyFeature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyFeature", new { id = companyFeature.Id }, companyFeature);
        }

        // DELETE: api/CompanyFeatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyFeature(int id)
        {
            if (_context.CompanyFeatures == null)
            {
                return NotFound();
            }
            var companyFeature = await _context.CompanyFeatures.FindAsync(id);
            if (companyFeature == null)
            {
                return NotFound();
            }

            _context.CompanyFeatures.Remove(companyFeature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Get company Feature by companyCode
        [HttpGet("GetCompanyFeaturesByCompanyCode")]
        public async Task<IEnumerable<Feature?>> GetCompanyFeaturesByCompanyCode(string companyCode)
        {
            var features = from companyFeature in _context.CompanyFeatures
                           join companies in _context.Companies on companyFeature.CompanyId equals companies.Id
                           join feature in _context.Features on companyFeature.FeatureId equals feature.Id
                           where companies.CompanyCode == companyCode
                           select feature;

            return await features.ToListAsync();
        }

        private bool CompanyFeatureExists(int id)
        {
            return (_context.CompanyFeatures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
