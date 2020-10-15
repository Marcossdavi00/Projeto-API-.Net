using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryInt : IProRepository
    {
        //Métodos Gerais
        private readonly RepositoryContext _context;

        public RepositoryInt(RepositoryContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void uptdate<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChargesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        //Get de Eventos
        public async Task<Event[]> GetAllEventAsync(bool includePalestrantes = false)
        {
            //Realizando uma Query no Banco de dados, incluindo na consulta os Lotes e RedeSociais
            IQueryable<Event> query = _context.Events
            .Include(c => c.Lotes)
            .Include(c => c.RedeSociais);
            //Validando o paramentro includePalestrantes, e usando o Then para incluir todos o palestrantes
            if(includePalestrantes)
            {
                query = query
                .Include(pe => pe.PalestrantesEvents)
                .ThenInclude(p => p.Palestrantes);
            }
            //OrderBy para saber como vai ser mostrado
            query = query.OrderByDescending(c => c.EventDate);
            //Retorando um Array com o resultado do Select
            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventAsyncByTema(string tema, bool includePalestrantes = false)
        {
            //Realizando uma Query no Banco de dados, incluindo na consulta os Lotes e RedeSociais
            IQueryable<Event> query = _context.Events
            .Include(c => c.Lotes)
            .Include(c => c.RedeSociais);
            //Validando o paramentro includePalestrantes, e usando o Then para incluir todos o palestrantes
            if(includePalestrantes)
            {
                query = query
                .Include(pe => pe.PalestrantesEvents)
                .ThenInclude(p => p.Palestrantes);
            }
            //OrderBy para saber como vai ser mostrado e os temas
            query = query.OrderByDescending(c => c.EventDate)
                    .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));
            //Retorando um Array com o resultado do Select

            return await query.ToArrayAsync();
        }
        public async Task<Event> GetEventAsyncById(int EventId, bool includePalestrantes = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(c => c.Lotes)
                .Include(c => c.RedeSociais);

            if(includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEvents)
                    .ThenInclude(p => p.Palestrantes);
            }
            query = query.OrderByDescending(c => c.EventDate)
                    .Where(c => c.Id == EventId);

            return await query.FirstOrDefaultAsync();
        }
        //GEt de Palestrantes
        public async Task<Palestrante> GetPalestrantesAsync(int PalestranteId, bool includeEvent = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedeSociais);

            if(includeEvent)
            {
                query = query
                    .Include(e => e.PalestrantesEvents)
                    .ThenInclude(ev => ev.Events);
            }
            query = query.OrderBy(c => c.Name)
                    .Where(c => c.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name,bool includeEvent = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedeSociais);

            if(includeEvent)
            {
                query = query
                    .Include(e => e.PalestrantesEvents)
                    .ThenInclude(ev => ev.Events);
            }
            query = query.Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }


    }
}