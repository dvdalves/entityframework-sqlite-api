using CrudAPI_Sqlite.Data;
using CrudAPI_Sqlite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI_Sqlite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController(Context context) : ControllerBase
{
    // GET: api/People
    [HttpGet]
    public IActionResult Get()
    {
        var people = context.People.ToList();
        return Ok(people);
    }

    // GET: api/People/5
    [HttpGet("{id}", Name = "GetPerson")]
    public IActionResult Get(int id)
    {
        var person = context.People.Find(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    // POST: api/People
    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        if (person == null)
        {
            return BadRequest("Invalid data.");
        }

        if (string.IsNullOrWhiteSpace(person.FullName))
        {
            return BadRequest("Person's name is required.");
        }

        person.IsActive = true;

        context.People.Add(person);
        context.SaveChanges();

        return CreatedAtRoute("GetPerson", new { id = person.Id }, person);
    }

    // PUT: api/People/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Person person)
    {
        if (person == null || person.Id != id)
        {
            return BadRequest("Invalid data.");
        }

        var existingPerson = context.People.Find(id);
        if (existingPerson == null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(person.FullName))
        {
            return BadRequest("Person's name is required.");
        }

        existingPerson.FullName = person.FullName;
        existingPerson.RegistrationDate = person.RegistrationDate;
        existingPerson.IsActive = person.IsActive;

        context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/People/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var person = context.People.Find(id);
        if (person == null)
        {
            return NotFound();
        }

        context.People.Remove(person);
        context.SaveChanges();
        return NoContent();
    }
}