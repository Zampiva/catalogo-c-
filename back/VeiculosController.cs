using System.Collections.Generic;
using System.Linq;
using CatalogoVeiculos.API.Data;
using CatalogoVeiculos.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoVeiculos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly DataContext _context;

        public VeiculosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Veiculo> GetVeiculos()
        {
            return _context.Veiculos.OrderBy(v => v.Valor);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVeiculos), new { id = veiculo.Id }, veiculo);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateVeiculo(int id, Veiculo veiculo)
        {
            var existingVeiculo = _context.Veiculos.Find(id);
            if (existingVeiculo == null)
            {
                return NotFound();
            }

            existingVeiculo.Nome = veiculo.Nome;
            existingVeiculo.Marca = veiculo.Marca;
            existingVeiculo.Modelo = veiculo.Modelo;
            existingVeiculo.Foto = veiculo.Foto;
            existingVeiculo.Valor = veiculo.Valor;

            _context.SaveChanges();

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteVeiculo(int id)
        {
            var existingVeiculo = _context.Veiculos.Find(id);
            if (existingVeiculo == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(existingVeiculo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
