using API_Prueba.Models;
using API_Prueba.Results.GendersR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Prueba.Controllers;

public class GenderController : ControllerBase
{
    private readonly repasoPContext _context;

    public GenderController(repasoPContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/gender/getAll")]
    public async Task<ActionResult<ResultGetGender>> getGenders()
    {
        try
        {
            var result = new ResultGetGender();
            var genders = await _context.Sexos.ToListAsync();

            if (genders != null)
            {
                foreach (var gen in genders)
                {
                    var resultAux = new ResultGenderItem()
                    {
                        Id = gen.Id,
                        Gender = gen.Sexo1
                    };
                    result.genderList.Add(resultAux);
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
