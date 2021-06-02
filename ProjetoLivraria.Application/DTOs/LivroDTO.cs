using System;

namespace ProjetoLivraria.Application.DTOs
{
    public class LivroDTO
    {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string ImagemCapa { get; set; }
        
        //public byte[] Foto { get; set; }
    }
}