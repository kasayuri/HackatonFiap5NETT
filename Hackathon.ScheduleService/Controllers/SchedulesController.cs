using Microsoft.AspNetCore.Mvc;
using Hackathon.ScheduleService.Data;
using Hackathon.ScheduleService.Models;
using Hackathon.ScheduleService.DTOs;

namespace Hackathon.ScheduleService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchedulesController : ControllerBase
{
    private readonly AppDbContext _context;
    public SchedulesController(AppDbContext context) => _context = context;

    [HttpPost]
    public IActionResult Create(CreateScheduleDto dto)
    {
        var horario = new Schedule
        {
            MedicoCRM = dto.MedicoCRM,
            DataHora = dto.DataHora
        };
        _context.Schedules.Add(horario);
        _context.SaveChanges();
        return Ok(horario);
    }

    [HttpPut("{id}")]
    public IActionResult Editar(int id, [FromBody] DateTime novaData)
    {
        var horario = _context.Schedules.Find(id);
        if (horario == null) return NotFound();

        horario.DataHora = novaData;
        _context.SaveChanges();
        return Ok(horario);
    }

    [HttpGet("medico/{crm}")]
    public IActionResult GetByMedico(string crm)
    {
        var horarios = _context.Schedules
            .Where(s => s.MedicoCRM == crm && s.Disponivel)
            .OrderBy(s => s.DataHora)
            .ToList();

        return Ok(horarios);
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var horario = _context.Schedules.Find(id);
        if (horario == null) return NotFound();

        _context.Schedules.Remove(horario);
        _context.SaveChanges();
        return Ok();
    }
}

