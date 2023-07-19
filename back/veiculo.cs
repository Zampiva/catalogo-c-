using System.ComponentModel.DataAnnotations;

namespace CatalogoVeiculos.API.Models
{
    public class Veiculo
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Foto { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}
