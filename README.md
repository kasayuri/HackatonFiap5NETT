# HackatonFiap5NETT

## Documentação:
- [Requisitos](./Requisitos.md)

## Microsserviços:

A solução é composta por quatro projetos:
- `Hackathon.AuthService` — autenticação e geração de tokens JWT
- `Hackathon.UserService` — cadastro e consulta de médicos e pacientes
- `Hackathon.ScheduleService` — gerenciamento de horários disponíveis
- `Hackathon.ConsultationService` — agendamento, cancelamento e aceite de consultas

## Tecnologias utilizadas:
- **.NET 8 (LTS) / C#**: Framework para desenvolvimento de aplicações.
- **ASP.NET Core Web API** : Framework para construção de APIs RESTful.
- **Docker**: Plataforma para desenvolvimento, envio e execução de aplicativos em contêineres.
- **Visual Studio 2022+ ou VS Code** : IDEs para desenvolvimento em C#.
- **SQL Server Express**: Sistema de gerenciamento de banco de dados relacional.
- **Entity Framework Core**: ORM para .NET.
- **Swagger (Swashbuckle.AspNetCore)**: Ferramenta para documentação de APIs.
- **JWT Bearer Authentication**: Protocolo de autenticação baseado em token.
- **Prometheus (.NET prometheus-net)**: Sistema de monitoramento e alerta.

## Requisitos para executar no Visual Studio:

- Visual Studio 2022+ (com suporte a .NET 8)
- SQL Server instalado localmente (`.\sqlexpress`)
- Docker Desktop (opcional para simular banco)- Altere as credenciais do banco de dados nos arquivos `appsettings.Development.json` de cada projeto.

## Para executar no Docker:

Altere as credenciais do banco de dados no arquivo `docker-compose.yml` e nos `appsettings.Production.json` de cada projeto.

### 1. Requisitos
- Docker Desktop instalado
- Terminal (cmd, PowerShell ou bash)

### 2. Subindo o sistema

Na raiz do projeto (onde está o `docker-compose.yml`), execute:

```bash
docker compose up --build
```

## Observações

- Cada serviço aplica as migrações automaticamente via `Database.Migrate()` com retry interno
- A autenticação JWT está habilitada e configurada no Swagger
- O Prometheus coleta métricas básicas via `/metrics` exposto automaticamente