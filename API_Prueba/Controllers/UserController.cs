using API_Prueba.Commands.Users;
using API_Prueba.Models;
using API_Prueba.Results;
using API_Prueba.Results.UsersR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Prueba.Controllers;

public class UserController : ControllerBase
{
    private readonly repasoPContext _context;

    public UserController(repasoPContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/user/getAll")]
    public async Task<ActionResult<ResultUsers>> getUsers()
    {
        try
        {
            var result = new ResultUsers();
            var users = await _context.Usuarios.Include(c=>c.IdDeporteNavigation).Include(c=>c.IdPersonaNavigation).
            Include(c=>c.IdRolNavigation).ToListAsync();

            if (users != null)
            {
                foreach (var user in users)
                {
                    var resultAux = new ResultUserItem
                    {
                        Id = user.Id,
                        Username = user.Usuario1
                    };
                    result.userList.Add(resultAux);
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
    
    [HttpPost]
    [Route("api/user/create")]
    public async Task<ActionResult<bool>> createUser([FromBody] CreateUserCommand command)
    {
        try
        {
            //persona e insert de persona
            var persona = new Persona()
            {
                Id = Guid.NewGuid(),
                Nombre = command.Name,
                Apellido = command.Surname,
                Dni = command.IdNo,
                IdSexo = command.Gender,
                Calle = command.Adress,
                Numero = command.No
            };
            await _context.AddAsync(persona);
            _context.SaveChanges();

            var user = new Usuario()
            {
                Id = Guid.NewGuid(),
                Usuario1 = command.Username,
                Password = command.Password,
                FechaAlta = DateTime.Today,
                Activo = true,
                IdRol = command.Rol,
                IdDeporte = command.Sport,
                //id de persona insertada antes
                IdPersona = persona.Id
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(true);
        }
        catch (Exception e)
        {
            return BadRequest("Action can not be done");
        }
    }

    [HttpPost]
    [Route("api/user/login")]
    public async Task<ActionResult<ResultUserLogin>> login([FromBody] LoginCommand command)
    {
        try
        {
            var result = new ResultUserLogin();
            var user = await _context.Usuarios.Where(c => c.Activo && c.Usuario1.Equals(command.Username) &&
            c.Password.Equals(command.Password)).Include(c => c.IdRolNavigation).FirstOrDefaultAsync();

            if (user != null)
            {
                result.Username = user.Usuario1;
                result.RolName = user.IdRolNavigation.Rol;

                result.StatusCode = 200;
                return Ok(result);
            }
            else
            {
                result.setError("User not found");
                result.StatusCode = 400;
                return Ok(result);
            }
        }
        catch (Exception e)
        {
            return BadRequest("Action can not be done");
        }
    }

    [HttpPut]
    [Route("api/user/changePassword")]
    public async Task<ActionResult<BaseResult>> changePassword([FromBody] ChangePassCommand command)
    {
        try
        {
            var result = new BaseResult();

            if (command.Username.Equals(""))
            {
                result.setError("User can not be found");
                result.StatusCode = 400;
            }

            var user = await _context.Usuarios.Where(c => c.Usuario1.Equals(command.Username) &&
            c.Password.Equals(command.Password)).FirstOrDefaultAsync();

            if (user != null)
            {
                user.Password = command.NewPassword;

                _context.Update(user);
                await _context.SaveChangesAsync();
                result.StatusCode = 200;
            }
            else
            {
                result.setError("User can not be found");
                result.StatusCode = 400;
            }
            return result;
        }
        catch (Exception e)
        {
            return BadRequest("Action can not be done");
        }
    }

    [HttpDelete]
    [Route("api/people/delte")]
    public async Task<ActionResult<bool>> Borrar(Guid idUsuario)
    {
        try
        {
            var user = await _context.Usuarios.FindAsync(idUsuario);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        catch (Exception e)
        {
            return BadRequest("Action cannot be done");
        }
    }
}
