using Microsoft.AspNetCore.Mvc;
using Hackathon.ConsultationService.Data;
using Hackathon.ConsultationService.DTOs;
using Hackathon.ConsultationService.Models;

namespace ConsultationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultationsController : ControllerBase
{
    private readonly AppDbContext _context;
    public ConsultationsController(AppDbContext context) => _context = context;

    [HttpPost]
    public IActionResult Create(CreateConsultationDto dto)
    {
        var consulta = new Consultation
        {
            MedicoCRM = dto.MedicoCRM,
            PacienteDocumento = dto.PacienteDocumento,
            DataHora = dto.DataHora,
            Status = "pendente"
        };

        _context.Consultations.Add(consulta);
        _context.SaveChanges();

        return Ok(consulta);
    }

    [HttpPut("{id}/resposta")]
    public IActionResult Responder(int id, [FromQuery] string status)
    {
        var consulta = _context.Consultations.Find(id);
        if (consulta == null) return NotFound();

        if (status != "aceita" && status != "recusada")
            return BadRequest("Status inválido");

        consulta.Status = status;
        _context.SaveChanges();

        return Ok(consulta);
    }

    [HttpPut("{id}/cancelar")]
    public IActionResult Cancelar(int id, [FromQuery] string justificativa)
    {
        var consulta = _context.Consultations.Find(id);
        if (consulta == null) return NotFound();

        consulta.Status = "cancelada";
        consulta.JustificativaCancelamento = justificativa;
        _context.SaveChanges();

        return Ok(consulta);
    }

    [HttpGet("medico/{crm}")]
    public IActionResult GetByMedico(string crm)
    {
        var consultas = _context.Consultations
            .Where(c => c.MedicoCRM == crm)
            .ToList();

        return Ok(consultas);
    }
}
