using Hackathon.UserService.Repositories;

namespace Hackathon.UserService.Data;

public interface IUnitOfWork
{
    IMedicoRepository Medicos { get; }
    IPacienteRepository Pacientes { get; }
    Task CommitAsync();
}
