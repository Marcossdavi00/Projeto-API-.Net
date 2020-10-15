using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public interface IProRepository
    {
        //Interfases(Métodos) para a chamada da API
         void add<T>(T entity) where T: class;
        void uptdate<T>(T entity) where T: class;
        void delete<T>(T entity) where T: class;
        Task<bool> SaveChargesAsync();
        //Interfases para Get de Eventos
        Task<Event[]> GetAllEventAsyncByTema(string tema, bool includePalestrantes);
        Task<Event[]> GetAllEventAsync(bool includePalestrantes);
        Task<Event> GetEventAsyncById(int EventId, bool includePalestrantes);
        //Interfases para Get de Palestrantes
        Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name,bool includeEvents);
        Task<Palestrante> GetPalestrantesAsync(int PalestranteId,bool includeEvents);
    }
}