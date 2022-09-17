using API_Prueba.Models;
using API_Prueba.Results.RolesR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Prueba.Controllers;

public class RolController : ControllerBase
{
    private readonly repasoPContext _context;

    public RolController(repasoPContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/roles/getAll")]
    public async Task<ActionResult<ResultGetRoles>> getRoles()
    {
        try
        {
            var result = new ResultGetRoles();
            var roles = await _context.Roles.ToListAsync();

            if (roles != null)
            {
                foreach (var rol in roles)
                {
                    var resultAux = new ResultRolItem
                    {
                        Id = rol.Id,
                        Rol = rol.Rol
                    };
                    result.rolesList.Add(resultAux);
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
}
