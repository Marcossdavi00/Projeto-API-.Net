using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public readonly IProRepository _repo;
        public readonly IMapper _mapper;
        public EventController(IProRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            var events = await _repo.GetAllEventAsync(true);

            var result = _mapper.Map<EventDtos[]>(events);

            return Ok(result);

        }
        catch (System.Exception ex)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou {ex.Message}");
        }
        
    }

    [HttpGet("apiId/{EventId}")]
    public async Task<ActionResult> Get(int EventId)
    {
        try
        {
            var evento = await _repo.GetEventAsyncById(EventId, true);

            var result = _mapper.Map<EventDtos>(evento);

            return Ok(result);

        }
        catch (System.Exception ex)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou {ex.Message}");
        }
        
    }
    [HttpGet("apiTema/{tema}")]
    public async Task<ActionResult> Get(string tema)
    {
        try
        {
            var events = await _repo.GetAllEventAsyncByTema(tema, true);

            var result = _mapper.Map<EventDtos[]>(events);
            return Ok(result);

        }
        catch (System.Exception ex)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou {ex.Message}");
        }
        
    }
    [HttpPost]
    public async Task<ActionResult> Post(EventDtos model)
    {
        try
        {
            var eventos = _mapper.Map<Event>(model);

            _repo.add(eventos);

            if(await _repo.SaveChargesAsync())
            {
                return Created($"/event/{model.Id}", _mapper.Map<Event>(eventos));
            }else
            {
               return BadRequest(ModelState);
            }
        }
        catch (System.Exception ex)
        {  
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou {ex.Message}");
        }
    }
    [HttpPut("{EventId}")]
    public async Task<ActionResult> Put(int EventId, EventDtos model)
    {
        try
        {
            var ev =  await _repo.GetEventAsyncById(EventId, false);
            if ( ev == null) return NotFound();

            _mapper.Map(model, ev);

            _repo.uptdate(ev);

            if(await _repo.SaveChargesAsync())
            {
                return Created($"/event/{model.Id}", _mapper.Map<EventDtos>(ev));
            }else
            {
                return BadRequest(ModelState);
            }

        }
        catch (System.Exception)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
        }
    }
    [HttpDelete("{EventId}")]
    public async Task<ActionResult> Delete(int EventId)
    {
        try
        {
        var eve = await _repo.GetEventAsyncById(EventId, false);
        if(eve == null) return this.NotFound();


        _repo.delete(eve);

        if(await _repo.SaveChargesAsync())
        {
            return Ok();
        }else
        {
            return BadRequest();
        }
        }
        catch (System.Exception)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou");
        }

    }

    }
}