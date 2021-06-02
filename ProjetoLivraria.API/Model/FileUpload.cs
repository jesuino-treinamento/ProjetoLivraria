using Microsoft.AspNetCore.Http;

namespace ProjetoLivraria.API
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
    }
}