using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("palestrant")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        public readonly IProRepository _repo;
        public readonly IMapper _mapped;
        public PalestranteController(IProRepository repo, IMapper mapped)
        {
            _mapped = mapped;
            _repo = repo;
        }
        [HttpGet("{name}")]
        public async Task<ActionResult> Get(string name)
        {
            try
            {
                var pale = await _repo.GetAllPalestrantesAsyncByName(name, true);

                var result = _mapped.Map<IEnumerable<PalestranteDtos>>(pale);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var pale = await _repo.GetPalestrantesAsync(id, true);

                var result = _mapped.Map<IEnumerable<PalestranteDtos>>(pale);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou {ex.Message}");
            }
        }
    }
}