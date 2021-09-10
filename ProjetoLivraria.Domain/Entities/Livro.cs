using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLivraria.Domain.Entities
{
    public class Livro : Base
    {
        //[Column(TypeName = "int")]
        //public int ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string ISBN { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Autor { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Nome { get; set; }
        
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Preco { get; set; }
        public DateTime DataPublicacao { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string ImagemCapa { get; set; }

        ////[Column(TypeName = "nvarchar(500)")]
        //public byte[] Foto { get; set; }
    }
}
