using Hackathon.UserService.Models;

namespace Hackathon.UserService.Repositories
{
    public interface IMedicoRepository
    {
        Task Adicionar(Medico medico);
        Task<List<Medico>> ListarTodosAsync();
    }
}
