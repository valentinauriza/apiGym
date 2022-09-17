using API_Prueba.Commands.People;
using API_Prueba.Models;
using API_Prueba.Results;
using API_Prueba.Results.PeopleR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Prueba.Controllers;

public class PersonController : ControllerBase
{
    private readonly repasoPContext _context;

    public PersonController(repasoPContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/people/getAll")]
    public async Task<ActionResult<ResultGetAllPeople>> getPeople()
    {
        try
        {
            var result = new ResultGetAllPeople();
            var people = await _context.Personas.Include(c => c.IdSexoNavigation).ToListAsync();

            if (people != null)
            {
                foreach (var per in people)
                {
                    var resultAux = new ResultPersonItem()
                    {
                        Id = per.Id,
                        Name = per.Nombre,
                        Surname = per.Apellido,
                        IdNo = per.Dni,
                        Gender = per.IdSexoNavigation.Sexo1,
                        Adress = per.Calle,
                        No = per.Numero
                    };
                    result.peopleList.Add(resultAux);
                    result.StatusCode = 200;
                }
                return Ok(result);
            }
            else
            {
                return Ok(result);
            }
        }
        catch (Exception e)
        {
            return BadRequest("Action cannot be done");
        }
    }

    [HttpGet]
    [Route("api/people/getById/{idPerson}")]
    public async Task<ActionResult<ResultGetOnePerson>> getById(Guid idPerson)
    {
        try
        {
            var result = new ResultGetOnePerson();
            var person = await _context.Personas.Where(c => c.Id.Equals(idPerson)).Include(c => c.IdSexoNavigation).
            FirstOrDefaultAsync();

            if (person != null)
            {
                result.Id = person.Id;
                result.Name = person.Nombre;
                result.Surname = person.Apellido;
                result.IdNo = person.Dni;
                result.Gender = person.IdSexoNavigation.Sexo1;
                result.Adress = person.Calle;
                result.No = person.Numero;
            }
            else
            {
                result.setError("Person not found");
                result.StatusCode = 400;
            }
            return result;
        }
        catch (Exception e)
        {
            return BadRequest("Action cannot be done");
        }
    }

    [HttpPut]
    [Route("api/people/edit")]
    public async Task<ActionResult<BaseResult>> editPerson([FromBody] UpdatePersonCommand command)
    {
        try
        {
            var result = new BaseResult();
            if (command.Id.Equals(""))
            {
                result.setError("Persona not found");
                result.StatusCode = 400;
            }

            var person = await _context.Personas.Where(c => c.Id.Equals(command.Id)).Include(c => c.IdSexoNavigation)
            .FirstOrDefaultAsync();
            if (person != null)
            {
                person.Nombre = command.Name;
                person.Apellido = command.Surname;
                person.IdSexo = command.IdGender;
                person.Calle = command.Adress;
                person.Numero = command.No;


                _context.Update(person);
                await _context.SaveChangesAsync();
                result.StatusCode = 200;
            }
            else
            {
                result.setError("Persona no encontrada");
                result.StatusCode = 500;
            }
            return result;
        }
        catch (Exception e)
        {
            return BadRequest("Action cannot be done");
        }
    }


    
}
