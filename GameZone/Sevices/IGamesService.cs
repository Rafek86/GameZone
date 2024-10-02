using GameZone.Models;
using GameZone.ViewModels;

namespace GameZone.Sevices
{
    public interface IGamesService
    {
        IEnumerable<Game> GetAll();
        Task Create(CreateGameFormVM game);
    }
}
