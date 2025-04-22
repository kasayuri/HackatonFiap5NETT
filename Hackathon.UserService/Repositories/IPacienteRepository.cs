using Hackathon.UserService.Models;

namespace Hackathon.UserService.Repositories
{
    public interface IPacienteRepository
    {
        Task Adicionar(Paciente paciente);
        Task<List<Paciente>> ListarTodosAsync();
        Task<Paciente> ObterPorCpfAsync(string cpf);
    }
}
