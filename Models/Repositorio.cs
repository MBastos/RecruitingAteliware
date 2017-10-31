using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitingAteliware.Models
{
    [Table("repositorio")]
    public class Repositorio
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_repositorio")]
        [Required]
        public int RepositorioId { get; set; }

        [Column("ordem")]
        [Required]
        public int Ordem { get; set; }
        
        [Column("linguagem")]
        [MaxLength(10)]
        [Required]
        public string Linguagem { get; set; }

        [Column("nome")]
        [MaxLength(45)]
        [Required]
        public string Nome { get; set; }

        [Column("descricao")]        
        [Required]
        public string Descricao { get; set; }

        [Column("proprietario")]        
        [Required]
        public string Proprietario { get; set; }
        
        [Column("data_criacao")]        
        [Required]
        public DateTime DataCriacao { get; set; }

        [Column("data_atualizacao")]        
        [Required]
        public DateTime DataAtualizacao { get; set; }

        [Column("data_cadastro")]                
        public DateTime? DataCadastro { get; set; }
    }
}