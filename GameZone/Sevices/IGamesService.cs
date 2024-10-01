using GameZone.ViewModels;

namespace GameZone.Sevices
{
    public interface IGamesService
    {
        Task Create(CreateGameFormVM game);
    }
}
