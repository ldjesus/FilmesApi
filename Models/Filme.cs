﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="O título é obrigatório")]
        public string Titulo {  get; set; }

        [Required(ErrorMessage ="O gênero é obrigatório")]
        [MaxLength(50, ErrorMessage ="O tamanho máximo é de 50 caracteres")]
        public string Genero { get; set; }

        [Required]
        [Range(70,600, ErrorMessage ="A duração do filme deve estar entre 70 a 600 minutos")]
        public int Duracao { get; set; }
       
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
