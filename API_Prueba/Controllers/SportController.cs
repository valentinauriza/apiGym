using API_Prueba.Models;
using API_Prueba.Results.SportsR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Prueba.Controllers;

public class SportController : ControllerBase
{
    private readonly repasoPContext _context;

    public SportController(repasoPContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/sports/getAll")]
    public async Task<ActionResult<ResultGetAllSports>> getSports()
    {
        try
        {
            var result = new ResultGetAllSports();
            var sports = await _context.Deportes.ToListAsync();

            if (sports != null)
            {
                foreach (var sport in sports)
                {
                    var resultAux = new ResultSportItem()
                    {
                        Id = sport.Id,
                        Sport = sport.Nombre
                    };
                    result.sportsList.Add(resultAux);
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