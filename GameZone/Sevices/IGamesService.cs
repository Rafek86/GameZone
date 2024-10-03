using GameZone.Models;
using GameZone.ViewModels;

namespace GameZone.Sevices
{
    public interface IGamesService
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create(CreateGameFormVM game);
        Task<Game?> Update(EditGameFormVM game);
        bool Delete(int id);    
    }
}
