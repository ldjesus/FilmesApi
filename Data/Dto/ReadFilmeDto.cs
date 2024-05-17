using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace FilmesApi.Data.Dto
{
    public class ReadFilmeDto
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
        public ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}
